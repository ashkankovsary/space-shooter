using System.Drawing;

namespace Space_Shooter_game
{
    public class StandardEnemy : Enemy
    {
        public StandardEnemy(float x, float y)
            : base(x, y, speed: 2f, collisionRadius: 10f, maxHP: 10, scoreValue: 10)
        {
        }

        public override void Shoot()
        {
        }

        public override void Draw(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(Color.Red))
            {
                g.FillEllipse(brush, X - CollisionRadius, Y - CollisionRadius, CollisionRadius * 2, CollisionRadius * 2);
            }
        }
    }
}