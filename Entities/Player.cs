using System.Drawing;

namespace Space_Shooter_game
{
    public class Player : Combatant
    {
        public int Score;
        public int Coins;
        private int shootCooldown;
        private int shootTimer;

        public bool MovingUp;
        public bool MovingDown;
        public bool MovingLeft;
        public bool MovingRight;
        public bool Shooting;

        public Player(float x, float y) : base(x, y, speed: GameSettings.Player.Speed, 
        collisionRadius: GameSettings.Player.CollisionRadius, maxHP: GameSettings.Player.MaxHP)
        {
            shootTimer = 0;
            shootCooldown = GameSettings.Player.ShootCooldown;
        }

        public override void Move(Player player)
        {
            float dx = 0, dy = 0;
            if (MovingUp) dy -= 1;
            if (MovingDown) dy += 1;
            if (MovingLeft) dx -= 1;
            if (MovingRight) dx += 1;

            if (dx != 0 || dy != 0)
            {
                float length = (float)System.Math.Sqrt(dx * dx + dy * dy);
                X += (dx / length) * Speed;
                Y += (dy / length) * Speed;
            }
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

        public override void Draw(Graphics g)
        {
            Image img = Properties.Resources.player_ship;
            g.DrawImage(img, X - img.Width / 2f, Y - img.Height / 2f, img.Width, img.Height);
        }
    }
}