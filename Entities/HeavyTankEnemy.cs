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
        public float ShotAngleOffsetDeg { get; private set; } = 0f;

        public bool IsInvulnerable =>
            Phase == BossPhase.Retreating || Phase == BossPhase.MiniWaveWait || Phase == BossPhase.Returning;

        private static readonly float[] RetreatThresholds =
        {
            GameSettings.HeavyTankEnemy.Phase2Threshold,
            GameSettings.HeavyTankEnemy.Phase3Threshold,
            GameSettings.HeavyTankEnemy.RetreatThreshold
        };
        private int retreatStage = 0;

        private readonly float centerX;
        private readonly float targetY;
        private readonly Random random = new Random();

        private float oscillationAngle;
        private float wobbleAngle;
        private int shootTimer;
        private int explosionTimer;

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

            if ((Phase == BossPhase.Fighting || Phase == BossPhase.Enraged) &&
                retreatStage < RetreatThresholds.Length &&
                CurrentHP <= MaxHP * RetreatThresholds[retreatStage])
            {
                retreatStage++;
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

        public void ConsumeMiniWaveRequest()
        {
            MiniWaveSpawnRequested = false;
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
                int shift = random.Next(
                    (int)GameSettings.HeavyTankEnemy.MinShotAngleShiftDeg,
                    (int)GameSettings.HeavyTankEnemy.MaxShotAngleShiftDeg + 1);
                ShotAngleOffsetDeg = (ShotAngleOffsetDeg + shift) % 360f;
                return true;
            }
            return false;
        }

        public override void Draw(Graphics g)
        {
            Image img = GetCurrentSprite();
            g.DrawImage(img, X - img.Width / 2f, Y - img.Height / 2f, img.Width, img.Height);

            if (Phase != BossPhase.Dying)
                DrawHealthBar(g, img);
        }

        private void DrawHealthBar(Graphics g, Image img)
        {
            float barWidth = 300f, barHeight = 18f;
            float barX = X - barWidth / 2f;
            float barY = Y - img.Height / 2f - barHeight - 10f;

            float percent = (float)CurrentHP / MaxHP;
            Color hpColor = percent >= 0.65f ? Color.LimeGreen : percent >= 0.30f ? Color.Gold : Color.Red;

            g.FillRectangle(Brushes.DarkGray, barX, barY, barWidth, barHeight);
            using (SolidBrush brush = new SolidBrush(hpColor))
                g.FillRectangle(brush, barX, barY, barWidth * percent, barHeight);
            g.DrawRectangle(Pens.Black, barX, barY, barWidth, barHeight);
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