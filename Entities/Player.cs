using System.Drawing;

namespace Space_Shooter_game
{
    public class Player : Combatant
    {
        public int Score;
        public int Coins;
        public int shootCooldown;
        private int shootTimer;
        public int TripleShotTimer;
        public int FireRateBoosterTimer;
        public int ShieldTimer;

        public bool MovingUp;
        public bool MovingDown;
        public bool MovingLeft;
        public bool MovingRight;
        public bool Shooting;

        public List<PowerUpType> ActivePowerUps;

        public Player(float x, float y) : base(x, y, speed: GameSettings.Player.Speed, 
        collisionRadius: GameSettings.Player.CollisionRadius, maxHP: GameSettings.Player.MaxHP)
        {
            shootTimer = 0;
            TripleShotTimer = 0;
            FireRateBoosterTimer = 0;
            ShieldTimer = 0;
            shootCooldown = GameSettings.Player.ShootCooldown;
            ActivePowerUps = new List<PowerUpType>();
        }

        public override void Move(Player player)
        {
            float dx = 0, dy = 0;
            if (MovingUp) dy -= 1;
            if (MovingDown) dy += 1;
            if (MovingLeft) dx -= 1;
            if (MovingRight) dx += 1;

            float horizontalMovement = 0f;
            if (dx != 0 || dy != 0)
            {
                int pacw = PlayForm.ActiveForm.ClientSize.Width;
                int pach = PlayForm.ActiveForm.ClientSize.Height;
                float length = (float)System.Math.Sqrt(dx * dx + dy * dy);
                horizontalMovement = (dx / length) * Speed;

                X += horizontalMovement;
                Y += (dy / length) * Speed;
                if (X < CollisionRadius) X = CollisionRadius;
                if (Y < CollisionRadius) Y = CollisionRadius;
                if (X > pacw - CollisionRadius) X = pacw - CollisionRadius;
                if (Y > pach - CollisionRadius) Y = pach - CollisionRadius;
            }
            ApplyTilt(horizontalMovement);
        }

        public bool Shoot()
        {
            if (Shooting)
            {
                if (shootTimer == 0)
                {
                    shootTimer++;
                    return true;
                }
                shootTimer++;
                if (shootTimer >= shootCooldown)
                    shootTimer = 0;
                return false;
            }
            shootTimer = 0;
            return false;
        }

        public void CheckTripleShot()
        {
            if (TripleShotTimer == 0) return;
            TripleShotTimer--;
        }

        public void CheckFireRateBooster()
        {
            if (FireRateBoosterTimer == 0)
            {
                shootCooldown = GameSettings.Player.ShootCooldown;
                return;
            }
            FireRateBoosterTimer--; 
        }

        public void CheckShield()
        {
            if (ShieldTimer == 0) return;
            ShieldTimer--;
        }

        public override void Draw(Graphics g)
        {
            Image img = Properties.Resources.player_ship;

            var state = g.Save();
            g.TranslateTransform(X, Y);
            g.RotateTransform(RotationAngle);
            g.DrawImage(img, -img.Width / 2f, -img.Height / 2f, img.Width, img.Height);
            g.Restore(state);

            if (ShieldTimer > 0)
            {
                Image shieldImg = Properties.Resources.player_shield;
                g.DrawImage(shieldImg, X - shieldImg.Width / 2f, Y - shieldImg.Height / 2f, shieldImg.Width, shieldImg.Height);
            }
        }
    }
}