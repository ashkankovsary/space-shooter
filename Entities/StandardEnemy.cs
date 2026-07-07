using System.Drawing;

namespace Space_Shooter_game
{
    public class StandardEnemy : Enemy
    {
        public StandardEnemy(float x, float y)
    : base(x, y, speed: GameSettings.StandardEnemy.Speed, collisionRadius: GameSettings.StandardEnemy.CollisionRadius, maxHP: GameSettings.StandardEnemy.MaxHP, scoreValue: GameSettings.StandardEnemy.ScoreValue)
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