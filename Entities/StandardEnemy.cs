using System.Drawing;

namespace Space_Shooter_game
{
    public class StandardEnemy : Enemy
    {
        public StandardEnemy(float x, float y)
    : base(x, y, speed: GameSettings.StandardEnemy.Speed, collisionRadius: GameSettings.StandardEnemy.CollisionRadius, maxHP: GameSettings.StandardEnemy.MaxHP, scoreValue: GameSettings.StandardEnemy.ScoreValue)
        {
        }

        public override bool Shoot()
        {
            return false;
        }

        public override void Draw(Graphics g)
        {
            Image img = Properties.Resources.enemy_standard;
            g.DrawImage(img, X - img.Width / 2f, Y - img.Height / 2f, img.Width, img.Height);
        }
    }
}