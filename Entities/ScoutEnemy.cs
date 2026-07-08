using System.Drawing;

namespace Space_Shooter_game
{
    public class ScoutEnemy : Enemy
    {
        private float centerX;
        private float angle;
        private float amplitude;
        private float frequency;
        public ScoutEnemy(float x, float y)
    : base(x, y, speed: GameSettings.ScoutEnemy.Speed, collisionRadius: GameSettings.ScoutEnemy.CollisionRadius, maxHP: GameSettings.ScoutEnemy.MaxHP, scoreValue: GameSettings.ScoutEnemy.ScoreValue)
        {
            angle = 0;
            centerX = x;
            amplitude = GameSettings.ScoutEnemy.Amplitude;
            frequency = GameSettings.ScoutEnemy.Frequency;
        }

        public override void Shoot()
        {
        }

        public override void Move()
        {
            Y += Speed;
            angle += frequency;
            X = centerX + ((float)Math.Sin(angle) * amplitude);
        }

        public override void Draw(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(Color.Orange))
            {
                g.FillEllipse(brush, X - CollisionRadius, Y - CollisionRadius, CollisionRadius * 2, CollisionRadius * 2);
            }
        }
    }
}
