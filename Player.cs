using System.Drawing;

namespace Space_Shooter_game
{
    public class Player : Combatant
    {
        public int Score;
        public int Coins;

        public bool MovingUp;
        public bool MovingDown;
        public bool MovingLeft;
        public bool MovingRight;

        public Player(float x, float y)
            : base(x, y, speed: 4f, collisionRadius: 10f, maxHP: 100)
        {
        }

        public override void Move()
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

        public override void Draw(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(Color.LimeGreen))
            {
                g.FillEllipse(brush, X - CollisionRadius, Y - CollisionRadius, CollisionRadius * 2, CollisionRadius * 2);
            }
        }
    }
}