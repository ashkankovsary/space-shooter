using System;
using System.Drawing;

namespace Space_Shooter_game
{
    public enum BossPhase
    {
        Approaching,
        Fighting,
        Retreating,
        MiniWaveWait,
        Returning,
        Enraged,
        Dying
    }

    public class HeavyTankEnemy : Enemy
    {
        public BossPhase Phase { get; private set; } = BossPhase.Approaching;
        public bool MiniWaveSpawnRequested { get; private set; } = false;
        public bool DeathSequenceComplete { get; private set; } = false;

        public bool IsInvulnerable =>
            Phase == BossPhase.Retreating || Phase == BossPhase.MiniWaveWait || Phase == BossPhase.Returning;

        private readonly float centerX;
        private readonly float targetY;

        private float oscillationAngle;
        private float wobbleAngle;
        private int shootTimer;
        private int explosionTimer;
        private bool hasRetreatedOnce;

        public HeavyTankEnemy(float x, float y, int screenHeight)
            : base(x, y, speed: GameSettings.HeavyTankEnemy.Speed,
                   collisionRadius: GameSettings.HeavyTankEnemy.CollisionRadius,
                   maxHP: GameSettings.HeavyTankEnemy.MaxHP,
                   scoreValue: GameSettings.HeavyTankEnemy.ScoreValue)
        {
            centerX = x;
            targetY = screenHeight * GameSettings.HeavyTankEnemy.TargetYRatio;
            shootTimer = GameSettings.HeavyTankEnemy.ShootCooldown;
        }

        public override void TakeDamage(int amount)
        {
            if (IsInvulnerable || Phase == BossPhase.Dying) return;

            CurrentHP -= amount;

            if (CurrentHP <= 0)
            {
                CurrentHP = 1;              // زنده نگهش می‌داریم تا انیمیشن انفجار پخش بشه
                Phase = BossPhase.Dying;
                explosionTimer = 45;
                return;
            }

            if (!hasRetreatedOnce && Phase == BossPhase.Fighting &&
                CurrentHP <= MaxHP * GameSettings.HeavyTankEnemy.RetreatThreshold)
            {
                hasRetreatedOnce = true;
                Phase = BossPhase.Retreating;
            }
        }

        public override void Move(Player player)
        {
            switch (Phase)
            {
                case BossPhase.Approaching:
                    Y += Speed;
                    if (Y >= targetY)
                    {
                        Y = targetY;
                        Phase = BossPhase.Fighting;
                    }
                    break;

                case BossPhase.Fighting:
                case BossPhase.Enraged:
                    oscillationAngle += GameSettings.HeavyTankEnemy.OscillationFrequency;
                    wobbleAngle += GameSettings.HeavyTankEnemy.WobbleFrequency;
                    X = centerX + (float)Math.Sin(oscillationAngle) * GameSettings.HeavyTankEnemy.OscillationAmplitude;
                    Y = targetY + (float)Math.Sin(wobbleAngle) * GameSettings.HeavyTankEnemy.WobbleAmplitude;
                    shootTimer--;
                    break;

                case BossPhase.Retreating:
                    Y -= GameSettings.HeavyTankEnemy.RetreatSpeed;
                    if (Y < -CollisionRadius * 2)
                    {
                        MiniWaveSpawnRequested = true;
                        Phase = BossPhase.MiniWaveWait;
                    }
                    break;

                case BossPhase.MiniWaveWait:
                    break;

                case BossPhase.Returning:
                    Y += GameSettings.HeavyTankEnemy.RetreatSpeed;
                    if (Y >= targetY)
                    {
                        Y = targetY;
                        Phase = BossPhase.Enraged;
                    }
                    break;

                case BossPhase.Dying:
                    explosionTimer--;
                    if (explosionTimer <= 0)
                    {
                        CurrentHP = 0;                  // حالا واقعاً می‌میره، Cleanup برش می‌داره
                        DeathSequenceComplete = true;
                    }
                    break;
            }
        }

        public void NotifyMiniWaveCleared()
        {
            if (Phase == BossPhase.MiniWaveWait)
                Phase = BossPhase.Returning;
        }

        public override bool Shoot()
        {
            if (Phase != BossPhase.Fighting && Phase != BossPhase.Enraged) return false;

            int cooldown = Phase == BossPhase.Enraged
                ? GameSettings.HeavyTankEnemy.EnragedShootCooldown
                : GameSettings.HeavyTankEnemy.ShootCooldown;

            if (shootTimer <= 0)
            {
                shootTimer = cooldown;
                return true;
            }
            return false;
        }

        public override void Draw(Graphics g)
        {
            Image img = GetCurrentSprite();
            g.DrawImage(img, X - img.Width / 2f, Y - img.Height / 2f, img.Width, img.Height);
        }

        private Image GetCurrentSprite()
        {
            if (Phase == BossPhase.Dying)
                return Properties.Resources.boss_explosion;

            float hpPercent = (float)CurrentHP / MaxHP;

            if (hpPercent > GameSettings.HeavyTankEnemy.Phase2Threshold)
                return Properties.Resources.heavy_tank_boss;
            if (hpPercent > GameSettings.HeavyTankEnemy.Phase3Threshold)
                return Properties.Resources.heavy_tank_boss2;
            if (hpPercent > GameSettings.HeavyTankEnemy.RetreatThreshold)
                return Properties.Resources.heavy_tank_boss3;

            return Properties.Resources.heavy_tank_boss4;
        }
    }
}