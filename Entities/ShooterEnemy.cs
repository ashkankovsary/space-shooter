using System.Drawing;

namespace Space_Shooter_game
{
    public class ShooterEnemy : Enemy
    {
        private int shootCooldown;
        private int shootTimer;
        public ShooterEnemy(float x, float y) : base(x, y, speed: GameSettings.ShooterEnemy.Speed,
        collisionRadius: GameSettings.ShooterEnemy.CollisionRadius,
        maxHP: GameSettings.ShooterEnemy.MaxHP,scoreValue: GameSettings.ShooterEnemy.ScoreValue)
        {
            shootTimer = 0;
            shootCooldown = GameSettings.ShooterEnemy.ShootCoolDown;
        }

        public override bool Shoot()
        {
            shootTimer++;
            return shootTimer >= shootCooldown;
        }
        
        public void ResetShootTimer()
        {
            shootTimer = 0;
        }

        public override void Draw(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(Color.Blue))
            {
                g.FillEllipse(brush, X - CollisionRadius, Y - CollisionRadius, CollisionRadius * 2, CollisionRadius * 2);
            }
        }
    }
}
