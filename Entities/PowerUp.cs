using System.Drawing;

namespace Space_Shooter_game
{
    public enum PowerUpType
    {
        TripleShot,
        Shield,
        HealthPack,
        FireRateBooster
    }
    public class PowerUp : GameEntity
    {
        public PowerUpType Type;
        public bool Removed;

        public PowerUp(float x, float y, float collisionRadius, PowerUpType type)
        : base(x, y, speed: GameSettings.PowerUp.Speed, collisionRadius)
        {
            Type = type;
            Removed = false;
        }

        public override void Move(Player player)
        {
            Y += Speed;
        }

        public override void Draw(Graphics g)
        {
            Brush brush = Brushes.White;
            if (Type == PowerUpType.TripleShot)
                brush = Brushes.DeepSkyBlue;
            if(Type == PowerUpType.Shield)
                brush = Brushes.LimeGreen;
            if (Type == PowerUpType.HealthPack)
                brush = Brushes.Pink;
            if (Type == PowerUpType.FireRateBooster)
                brush = Brushes.Red;
            g.FillEllipse(brush, X - CollisionRadius, Y - CollisionRadius, CollisionRadius * 2, CollisionRadius * 2);
        }
    }
}
