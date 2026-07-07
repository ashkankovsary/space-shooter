using System.Drawing;

namespace Space_Shooter_game
{
    public enum BulletOwner
    {
        Player,
        Enemy
    }

    public class Bullet : GameEntity
    {
        public float DirX;
        public float DirY;
        public BulletOwner Owner;
        public int Damage;

        public Bullet(float x, float y, float dirX, float dirY, float speed, BulletOwner owner, int damage)
            : base(x, y, speed, collisionRadius: 3f)
        {
            DirX = dirX;
            DirY = dirY;
            Owner = owner;
            Damage = damage;
        }

        public override void Move()
        {
            X += DirX * Speed;
            Y += DirY * Speed;
        }

        public override void Draw(Graphics g)
        {
            Color color = Owner == BulletOwner.Player ? Color.Blue : Color.OrangeRed;
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillEllipse(brush, X - CollisionRadius, Y - CollisionRadius, CollisionRadius * 2, CollisionRadius * 2);
            }
        }
    }
}