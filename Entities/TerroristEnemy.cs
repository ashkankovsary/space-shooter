using Microsoft.VisualBasic;
using System.Drawing;
using static Space_Shooter_game.GameSettings;

namespace Space_Shooter_game
{
    public class TerroristEnemy : Enemy
    {
        private float dX;
        private float dY;
        private int updateCounter;
        private float explosionRadius;
        private bool passageCheck;

        public TerroristEnemy(float x, float y) 
        : base(x, y, speed: GameSettings.TerroristEnemy.Speed,
        collisionRadius: GameSettings.TerroristEnemy.CollisionRadius,
        maxHP: GameSettings.TerroristEnemy.MaxHP, scoreValue: GameSettings.TerroristEnemy.ScoreValue)
        {
            dX = 0; dY = 1; passageCheck = false;
            updateCounter = GameSettings.TerroristEnemy.UpdateInterval;
            explosionRadius = GameSettings.TerroristEnemy.ExplosionRadius;
        }

        public override bool Shoot()
        {
            return false;
        }

        public override void Move(Player player)
        {
            updateCounter--;
            if (player.Y <= Y) passageCheck = true;
            if (updateCounter <= 0 && !passageCheck)
            {
                float dx = player.X - X;
                float dy = player.Y - Y;
                float length = MathF.Sqrt(dx * dx + dy * dy);

                if (length <= 0.01f) return;

                dX = dx / length;
                dY = dy / length;
                updateCounter = GameSettings.TerroristEnemy.UpdateInterval;
            }
            X += dX * Speed;
            Y += dY * Speed;
        }

        public override void Draw(Graphics g)
        {
            Image img = Properties.Resources.enemy_terrorist;
            g.DrawImage(img, X - img.Width / 2f, Y - img.Height / 2f, img.Width, img.Height);
        }
    }
}
