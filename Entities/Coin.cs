using System.Drawing;

namespace Space_Shooter_game
{
    public enum CoinType
    {
        Gold,
        Silver
    }

    public class Coin : GameEntity
    {
        public CoinType Type;
        public int Value;
        public bool Removed;

        public Coin(float x, float y, CoinType type)
            : base(x, y, speed: GameSettings.Coin.Speed, collisionRadius: GameSettings.Coin.CollisionRadius)
        {
            Type = type;
            Value = type == CoinType.Gold ? GameSettings.Coin.GoldValue : GameSettings.Coin.SilverValue;
            Removed = false;
        }

        public override void Move(Player player)
        {
            Y += Speed;
        }

        public override void Draw(Graphics g)
        {
            Image img = Type == CoinType.Gold ? Properties.Resources.coin : Properties.Resources.coin_silver;
            g.DrawImage(img, X - img.Width / 2f, Y - img.Height / 2f, img.Width, img.Height);
        }
    }
}