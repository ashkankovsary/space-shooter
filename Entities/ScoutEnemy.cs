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

        public override bool Shoot()
        {
            return false;
        }

        public override void Move(Player player)
        {
            float prevX = X;
            Y += Speed;
            angle += frequency;
            X = centerX + ((float)Math.Sin(angle) * amplitude);
            ApplyTilt(X - prevX);
        }

        public override void Draw(Graphics g)
        {
            Image img = Properties.Resources.enemy_scout;

            var state = g.Save();
            g.TranslateTransform(X, Y);
            g.RotateTransform(-RotationAngle);
            g.DrawImage(img, -img.Width / 2f, -img.Height / 2f, img.Width, img.Height);
            g.Restore(state);
        }
    }
}
