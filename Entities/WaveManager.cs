using System;
using System.Collections.Generic;
using System.Linq;

namespace Space_Shooter_game
{
    public enum EnemyType
    {
        Standard,
        Scout,
        Shooter,
        Terrorist
    }
    public enum WaveState
    {
        ShowingBanner,
        Spawning,
        WaitingForClear,
        BossFight,
        Victory
    }

    public class WaveManager
    {
        public int CurrentWave { get; private set; } = 1;
        public WaveState State { get; private set; }
        public string BannerText { get; private set; } = "";

        private readonly int screenWidth;
        private readonly int screenHeight;
        private int enemiesToSpawn;
        private int spawnTimer;
        private int spawnInterval;
        private int bannerTimer;
        private int clearTimer;

        private HeavyTankEnemy boss;
        private bool bossSpawned;
        private bool miniWaveHandled;

        private readonly Random random = new Random();

        public WaveManager(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            StartWave(1);
        }

        private void StartWave(int waveNumber)
        {
            CurrentWave = waveNumber;

            if (waveNumber > GameSettings.Wave.TotalWaves)
            {
                BannerText = "BOSS INCOMING";
                bannerTimer = (int)(GameSettings.Wave.BannerDisplaySeconds * 60);
                State = WaveState.ShowingBanner;
                return;
            }

            enemiesToSpawn = GameSettings.Wave.BaseEnemyCount + (waveNumber - 1) * GameSettings.Wave.EnemyCountPerWave;
            spawnInterval = (int)Math.Max(GameSettings.Wave.MinSpawnInterval,
                GameSettings.Wave.BaseSpawnInterval - (waveNumber - 1) * GameSettings.Wave.SpawnIntervalDecayPerWave);
            spawnTimer = 0;

            BannerText = $"Wave {waveNumber}";
            bannerTimer = (int)(GameSettings.Wave.BannerDisplaySeconds * 60);
            State = WaveState.ShowingBanner;
        }

        public void Update(GameManager gameManager)
        {
            switch (State)
            {
                case WaveState.ShowingBanner:
                    bannerTimer--;
                    if (bannerTimer <= 0)
                        State = CurrentWave > GameSettings.Wave.TotalWaves ? WaveState.BossFight : WaveState.Spawning;
                    break;

                case WaveState.Spawning:
                    if (enemiesToSpawn > 0)
                    {
                        spawnTimer--;
                        if (spawnTimer <= 0)
                        {
                            SpawnEnemy(gameManager);
                            enemiesToSpawn--;
                            spawnTimer = spawnInterval;
                        }
                    }
                    else if (gameManager.enemyList.Count == 0)
                    {
                        State = WaveState.WaitingForClear;
                        clearTimer = (int)(GameSettings.Wave.ClearDelaySeconds * 60);
                    }
                    break;

                case WaveState.WaitingForClear:
                    clearTimer--;
                    if (clearTimer <= 0)
                    {
                        gameManager.player.Score += GameSettings.Wave.ScoreBonusPerWave * CurrentWave;
                        StartWave(CurrentWave + 1);
                    }
                    break;

                case WaveState.BossFight:
                    UpdateBossFight(gameManager);
                    break;

                case WaveState.Victory:
                    break;
            }
        }

        private void UpdateBossFight(GameManager gameManager)
        {
            if (!bossSpawned)
            {
                boss = new HeavyTankEnemy(screenWidth / 2f, -GameSettings.HeavyTankEnemy.CollisionRadius, screenHeight);
                gameManager.enemyList.Add(boss);
                bossSpawned = true;
            }

            if (boss.MiniWaveSpawnRequested && !miniWaveHandled)
            {
                SpawnMiniWave(gameManager);
                miniWaveHandled = true;
            }

            if (miniWaveHandled && boss.Phase == BossPhase.MiniWaveWait &&
                gameManager.enemyList.All(e => e is HeavyTankEnemy))
            {
                boss.NotifyMiniWaveCleared();
            }

            if (boss.DeathSequenceComplete)
            {
                State = WaveState.Victory;
            }
        }

        private void SpawnEnemy(GameManager gameManager)
        {
            EnemyType type = PickWeightedEnemyType();
            float x = random.Next(40, screenWidth - 40);
            Enemy enemy = CreateEnemy(type, x, -70f);
            ApplyWaveScaling(enemy);
            gameManager.enemyList.Add(enemy);
        }

        private void SpawnMiniWave(GameManager gameManager)
        {
            int count = random.Next(GameSettings.HeavyTankEnemy.MiniWaveMinEnemies,
                GameSettings.HeavyTankEnemy.MiniWaveMaxEnemies + 1);

            for (int i = 0; i < count; i++)
            {
                EnemyType type = PickWeightedEnemyType();
                float x = random.Next(40, screenWidth - 40);
                float y = -70f - i * 40f;
                Enemy enemy = CreateEnemy(type, x, y);
                ApplyWaveScaling(enemy);
                gameManager.enemyList.Add(enemy);
            }
        }

        private Enemy CreateEnemy(EnemyType type, float x, float y)
        {
            return type switch
            {
                EnemyType.Standard => new StandardEnemy(x, y),
                EnemyType.Scout => new ScoutEnemy(x, y),
                EnemyType.Shooter => new ShooterEnemy(x, y),
                EnemyType.Terrorist => new TerroristEnemy(x, y),
                _ => new StandardEnemy(x, y)
            };
        }

        private void ApplyWaveScaling(Enemy enemy)
        {
            float speedMultiplier = 1f + GameSettings.Wave.SpeedGrowthPerWave * (CurrentWave - 1);
            int hpBonus = GameSettings.Wave.HpGrowthPerWave * (CurrentWave - 1);

            enemy.Speed *= speedMultiplier;
            enemy.MaxHP += hpBonus;
            enemy.CurrentHP = enemy.MaxHP;
        }

        private EnemyType PickWeightedEnemyType()
        {
            var weights = new List<(EnemyType type, float weight)>
            {
                (EnemyType.Standard, GetWeight(GameSettings.Wave.StandardWeight.Base, GameSettings.Wave.StandardWeight.GrowthPerWave, GameSettings.Wave.StandardWeight.Min, 1))
            };

            if (CurrentWave >= GameSettings.Wave.ScoutUnlockWave)
                weights.Add((EnemyType.Scout, GetWeight(GameSettings.Wave.ScoutWeight.Base, GameSettings.Wave.ScoutWeight.GrowthPerWave, GameSettings.Wave.ScoutWeight.Min, GameSettings.Wave.ScoutUnlockWave)));

            if (CurrentWave >= GameSettings.Wave.ShooterUnlockWave)
                weights.Add((EnemyType.Shooter, GetWeight(GameSettings.Wave.ShooterWeight.Base, GameSettings.Wave.ShooterWeight.GrowthPerWave, GameSettings.Wave.ShooterWeight.Min, GameSettings.Wave.ShooterUnlockWave)));

            if (CurrentWave >= GameSettings.Wave.TerroristUnlockWave)
                weights.Add((EnemyType.Terrorist, GetWeight(GameSettings.Wave.TerroristWeight.Base, GameSettings.Wave.TerroristWeight.GrowthPerWave, GameSettings.Wave.TerroristWeight.Min, GameSettings.Wave.TerroristUnlockWave)));

            float totalWeight = weights.Sum(w => w.weight);
            float roll = (float)random.NextDouble() * totalWeight;
            float cumulative = 0;

            foreach (var (type, weight) in weights)
            {
                cumulative += weight;
                if (roll <= cumulative) return type;
            }
            return weights[0].type;
        }

        private float GetWeight(float baseWeight, float growthPerWave, float min, int unlockWave)
        {
            float wavesSinceUnlock = CurrentWave - unlockWave;
            return Math.Max(min, baseWeight + growthPerWave * wavesSinceUnlock);
        }
    }
}