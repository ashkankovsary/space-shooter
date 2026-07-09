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
        public bool Removed;

        public Bullet(float x, float y, float dirX, float dirY, BulletOwner owner, int damage)
    : base(x, y, GameSettings.Bullet.Speed, collisionRadius: GameSettings.Bullet.CollisionRadius)
        {
            DirX = dirX;
            DirY = dirY;
            Owner = owner;
            Damage = damage;
            Removed = false;
        }

        public override void Move(Player player)
        {
            X += DirX * Speed;
            Y += DirY * Speed;
        }

        public override void Draw(Graphics g)
        {
            Image img = Owner == BulletOwner.Player ? Properties.Resources.player_bullet : Properties.Resources.enemy_bullet;
            g.DrawImage(img, X - img.Width / 2f, Y - img.Height / 2f, img.Width, img.Height);
        }
    }
}