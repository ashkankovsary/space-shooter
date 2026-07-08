namespace Space_Shooter_game
{
    public static class GameSettings
    {
        public static class Player
        {
            public static readonly float Speed = 4f;
            public static readonly float CollisionRadius = 10f;
            public static readonly int MaxHP = 100;
        }

        public static class Bullet
        {
            public static readonly float CollisionRadius = 3f;
        }

        public static class StandardEnemy
        {
            public static readonly float Speed = 2f;
            public static readonly float CollisionRadius = 10f;
            public static readonly int MaxHP = 10;
            public static readonly int ScoreValue = 10;
        }

        public static class ScoutEnemy
        {
            public static readonly float Speed = 3f;
            public static readonly float CollisionRadius = 10f;
            public static readonly int MaxHP = 10;
            public static readonly int ScoreValue = 10;
            public static readonly float Amplitude = 80;
            public static readonly float Frequency = 0.08f;
        }
    }
}