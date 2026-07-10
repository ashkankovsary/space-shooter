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
            Image img = Type switch
            {
                PowerUpType.TripleShot => Properties.Resources.triple_shoot,
                PowerUpType.Shield => Properties.Resources.shield,
                PowerUpType.HealthPack => Properties.Resources.health_pack,
                PowerUpType.FireRateBooster => Properties.Resources.fire_rate,
                _ => null
            };

            if (img != null)
                g.DrawImage(img, X - img.Width / 2f, Y - img.Height / 2f, img.Width, img.Height);
        }
    }
}
