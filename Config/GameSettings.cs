namespace Space_Shooter_game
{
    public static class GameSettings
    {
        public static class Player
        {
            public static readonly float Speed = 10f;
            public static readonly float CollisionRadius = 40f;
            public static readonly int CollisionDamage = 40;
            public static readonly int MaxHP = 100;
            public static readonly int ShootCooldown = 12;
            public static readonly int bulletDamage = 15;
        }

        public static class Bullet
        {
            public static readonly float CollisionRadius = 5f;
            public static readonly float Speed = 10f;
        }

        public static class StandardEnemy
        {
            public static readonly float Speed = 1.5f;
            public static readonly float CollisionRadius = 25f;
            public static readonly int MaxHP = 20;
            public static readonly int ScoreValue = 10;

            public static readonly float TripleShotChance = 0.05f;
            public static readonly float ShieldChance = 0.02f;
            public static readonly float HealthPackChance = 0.1f;
            public static readonly float FireRateBoosterChance = 0.05f;
        }

        public static class ScoutEnemy
        {
            public static readonly float Speed = 2f;
            public static readonly float CollisionRadius = 28f;
            public static readonly int MaxHP = 20;
            public static readonly int ScoreValue = 20;
            public static readonly float Amplitude = 80f;
            public static readonly float Frequency = 0.08f;

            public static readonly float TripleShotChance = 0.07f;
            public static readonly float ShieldChance = 0.04f;
            public static readonly float HealthPackChance = 0.12f;
            public static readonly float FireRateBoosterChance = 0.07f;
        }

        public static class ShooterEnemy
        {
            public static readonly float Speed = 1f;
            public static readonly float CollisionRadius = 30f;
            public static readonly int MaxHP = 35;
            public static readonly int ScoreValue = 40;
            public static readonly int ShootCoolDown = 40;
            public static readonly int bulletDamage = 10;

            public static readonly float TripleShotChance = 0.09f;
            public static readonly float ShieldChance = 0.06f;
            public static readonly float HealthPackChance = 0.2f;
            public static readonly float FireRateBoosterChance = 0.09f;
        }

        public static class TerroristEnemy
        {
            public static readonly float Speed = 2f;
            public static readonly float CollisionRadius = 27f;
            public static readonly int MaxHP = 20;
            public static readonly int ScoreValue = 10;
            public static readonly int UpdateInterval = 25;
            public static readonly float ExplosionRadius = 50f;

            public static readonly float TripleShotChance = 0.11f;
            public static readonly float ShieldChance = 0.08f;
            public static readonly float HealthPackChance = 0.2f;
            public static readonly float FireRateBoosterChance = 0.11f;
        }

        public static class PowerUp
        {
            public static readonly float Speed = 4f;
            public static readonly float TripleShotRadius = 15f;
            public static readonly float SheildRadius = 15f;
            public static readonly float HealthPackRadius = 15f;
            public static readonly float FireRateBoosterRadius = 15f;
        }

        public static class Coin
        {
            public static readonly float Speed = 3f;
            public static readonly float CollisionRadius = 18f;
            public static readonly int GoldValue = 5;
            public static readonly int SilverValue = 1;
            public static readonly float DropChance = 0.05f;
            public static readonly float GoldChance = 0.2f;
        }

        public static class Wave
        {
            public static readonly int TotalWaves = 9;

            public static readonly int BaseEnemyCount = 20;
            public static readonly int EnemyCountPerWave = 5;

            public static readonly float BaseSpawnInterval = 66f;
            public static readonly float MinSpawnInterval = 30f;
            public static readonly float SpawnIntervalDecayPerWave = 4f;

            public static readonly float SpeedGrowthPerWave = 0.05f;
            public static readonly int HpGrowthPerWave = 1;
            public static readonly float PlayerBulletDamageGrowthPerWave = 0.08f;

            public static readonly int ScoreBonusPerWave = 50;

            public static readonly float BannerDisplaySeconds = 1f;
            public static readonly float ClearDelaySeconds = 1.5f;

            public static readonly int ScoutUnlockWave = 1;
            public static readonly int ShooterUnlockWave = 4;
            public static readonly int TerroristUnlockWave = 7;

            public static class StandardWeight
            {
                public static readonly float Base = 100f;
                public static readonly float GrowthPerWave = -8f;
                public static readonly float Min = 10f;
            }
            public static class ScoutWeight
            {
                public static readonly float Base = 60f;
                public static readonly float GrowthPerWave = 2f;
                public static readonly float Min = 0f;
            }
            public static class ShooterWeight
            {
                public static readonly float Base = 40f;
                public static readonly float GrowthPerWave = 6f;
                public static readonly float Min = 0f;
            }
            public static class TerroristWeight
            {
                public static readonly float Base = 30f;
                public static readonly float GrowthPerWave = 8f;
                public static readonly float Min = 0f;
            }
        }
    }
}