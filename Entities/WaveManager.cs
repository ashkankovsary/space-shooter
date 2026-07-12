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
        /// <summary>
        /// ////////////////////////////////////////////////
        /// </summary>
        private bool miniWaveActive;
        private int miniWaveEnemiesRemaining;
        private int miniWaveSpawnTimer;
        private int miniWaveSpawnInterval;

        private int ambientSpawnTimer;
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
                boss = new HeavyTankEnemy(screenWidth / 2f, -150f, screenHeight);
                gameManager.enemyList.Add(boss);
                bossSpawned = true;
                ambientSpawnTimer = (int)GameSettings.HeavyTankEnemy.AmbientSpawnInterval;
            }

            if (boss.MiniWaveSpawnRequested && !miniWaveActive)
            {
                boss.ConsumeMiniWaveRequest();
                StartMiniWave();
                miniWaveActive = true;
            }

            if (miniWaveActive)
            {
                UpdateMiniWaveSpawning(gameManager);

                bool doneSpawningMiniWave = miniWaveEnemiesRemaining <= 0;
                bool noMiniWaveEnemiesLeft = gameManager.enemyList.All(e => e is HeavyTankEnemy);

                if (doneSpawningMiniWave && noMiniWaveEnemiesLeft && boss.Phase == BossPhase.MiniWaveWait)
                {
                    boss.NotifyMiniWaveCleared();
                    miniWaveActive = false;
                }
            }

            if (boss.Phase == BossPhase.Fighting || boss.Phase == BossPhase.Enraged)
            {
                ambientSpawnTimer--;
                if (ambientSpawnTimer <= 0)
                {
                    SpawnEnemy(gameManager);
                    ambientSpawnTimer = (int)GameSettings.HeavyTankEnemy.AmbientSpawnInterval;
                }
            }

            if (boss.DeathSequenceComplete)
            {
                State = WaveState.Victory;
            }
        }

        private void StartMiniWave()
        {
            int count = random.Next(GameSettings.HeavyTankEnemy.MiniWaveMinEnemies,
                GameSettings.HeavyTankEnemy.MiniWaveMaxEnemies + 1);

            miniWaveEnemiesRemaining = count;
            miniWaveSpawnInterval = (int)Math.Max(GameSettings.HeavyTankEnemy.MiniWaveMinSpawnInterval,
                GameSettings.HeavyTankEnemy.MiniWaveBaseSpawnInterval -
                GameSettings.HeavyTankEnemy.MiniWaveSpawnIntervalDecayPerEnemy * count);
            miniWaveSpawnTimer = 0;
        }

        private void UpdateMiniWaveSpawning(GameManager gameManager)
        {
            if (miniWaveEnemiesRemaining <= 0) return;

            miniWaveSpawnTimer--;
            if (miniWaveSpawnTimer <= 0)
            {
                EnemyType type = PickWeightedEnemyType();
                float x = random.Next(40, screenWidth - 40);
                Enemy enemy = CreateEnemy(type, x, -70f);
                ApplyWaveScaling(enemy);
                gameManager.enemyList.Add(enemy);

                miniWaveEnemiesRemaining--;
                miniWaveSpawnTimer = miniWaveSpawnInterval;
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