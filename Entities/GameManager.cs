using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using static Space_Shooter_game.GameSettings;

namespace Space_Shooter_game
{
    public class GameManager
    {
        public Player player {get;}
        public List<Enemy> enemyList;
        public List<Bullet> bulletList;
        public List<PowerUp> powerUpList;
        public List<Coin> coinList;
        public WaveManager waveManager { get; private  set; }

        private int Width;
        private int Height;

        private Random random = new Random();

        public GameManager(int width, int height)
        {
            Width = width;
            Height = height;

            player = new Player(600, 800);
            enemyList = new List<Enemy>();
            bulletList = new List<Bullet>();
            powerUpList = new List<PowerUp>();
            coinList = new List<Coin>();
            waveManager = new WaveManager(width);
        }

        public void Update()
        {
            waveManager.Update(this);

            player.Move(player);
            player.CheckTripleShot();
            player.CheckFireRateBooster();
            player.CheckShield();

            if (player.Shoot())
            {
                if (player.FireRateBoosterTimer > 0)
                    player.shootCooldown = GameSettings.Player.ShootCooldown / 2;

                int playerDamage = (int)(GameSettings.Player.bulletDamage * 
                    (1f - GameSettings.Wave.PlayerBulletDamageGrowthPerWave * (waveManager.CurrentWave - 1)));

                bulletList.Add(new Bullet(player.X, player.Y - player.CollisionRadius, 0, -1, BulletOwner.Player, playerDamage));
                if(player.TripleShotTimer > 0)
                {
                    bulletList.Add(new Bullet(player.X, player.Y - player.CollisionRadius, -0.6f, -0.8f, BulletOwner.Player, playerDamage));
                    bulletList.Add(new Bullet(player.X, player.Y - player.CollisionRadius, 0.6f, -0.8f, BulletOwner.Player, playerDamage));
                }
            }
            foreach (Enemy enemy in enemyList)
            {
                enemy.Move(player);
                if(enemy is ShooterEnemy shooter)
                {
                    if (shooter.Shoot())
                    {
                        bulletList.Add(new Bullet(enemy.X, enemy.Y + enemy.CollisionRadius, 0, 1, BulletOwner.Enemy, GameSettings.ShooterEnemy.bulletDamage));
                        shooter.ResetShootTimer();
                    }
                }
            }
            foreach(Bullet bullet in bulletList)
            {
                bullet.Move(player);
            }
            foreach (PowerUp powerUp in powerUpList)
            {
                powerUp.Move(player);
            }
            foreach(Coin coin in coinList)
            {
                coin.Move(player);
            }
            CheckCollision();
            Cleanup();
        }
        public void CheckCollision()
        {
            foreach(Enemy enemy in enemyList)
            {
                if (enemy.IsCollidingWith(player))
                {
                    if (player.ShieldTimer > 0)
                        player.ShieldTimer = 0;
                    else player.TakeDamage(GameSettings.Player.CollisionDamage);
                    enemy.TakeDamage(enemy.CurrentHP);
                    AudioManager.PlaySfx(Sounds.ShipCollision);
                }
            }
            foreach(Bullet bullet in bulletList)
            {
                if(bullet.Owner == BulletOwner.Enemy)
                {
                    if (bullet.IsCollidingWith(player))
                    {
                        if(player.ShieldTimer == 0)
                            player.TakeDamage(bullet.Damage);
                        bullet.Removed = true;
                        AudioManager.PlaySfx(Sounds.PlayerBulletHit);
                    }
                }
                if(bullet.Owner == BulletOwner.Player)
                {
                    foreach (Enemy enemy in enemyList)
                    {
                        if (bullet.IsCollidingWith(enemy))
                        {
                            enemy.TakeDamage(bullet.Damage);
                            bullet.Removed = true;
                            AudioManager.PlaySfx(Sounds.EnemyBulletHit);
                        }
                    }
                }
            }
            foreach(PowerUp powerUp in powerUpList)
            {
                if (powerUp.IsCollidingWith(player))
                {
                    powerUp.Removed = true;
                    if(powerUp.Type == PowerUpType.HealthPack)
                    {
                        if (player.CurrentHP >= 50)
                            player.CurrentHP = 100;
                        else player.CurrentHP += 50;
                        AudioManager.PlaySfx(Sounds.HealthPackUse);
                    }
                    else if(powerUp.Type == PowerUpType.TripleShot)
                    {
                        if(player.TripleShotTimer == 0)
                            player.ActivePowerUps.Add(PowerUpType.TripleShot);
                        player.TripleShotTimer = 300;
                        AudioManager.PlaySfx(Sounds.PowerUpPickup);
                    }
                    else if(powerUp.Type == PowerUpType.FireRateBooster)
                    {
                        if (player.FireRateBoosterTimer == 0)
                            player.ActivePowerUps.Add(PowerUpType.FireRateBooster);
                        player.FireRateBoosterTimer = 300;
                        AudioManager.PlaySfx(Sounds.PowerUpPickup);
                    }
                    else if(powerUp.Type == PowerUpType.Shield)
                    {
                        if (player.ShieldTimer == 0)
                            player.ActivePowerUps.Add(PowerUpType.Shield);
                        player.ShieldTimer = 150;
                        AudioManager.PlaySfx(Sounds.PowerUpPickup);
                    }
                }
            }
            foreach(Coin coin in coinList)
            {
                if (coin.IsCollidingWith(player))
                {
                    coin.Removed = true;
                    player.Coins += coin.Value;
                    AudioManager.PlaySfx(Sounds.CoinDrop);
                }
            }
        }
        public void Cleanup()
        {
            foreach (Enemy enemy in enemyList)
            {
                if (enemy.IsDead)
                {
                    player.Score += enemy.ScoreValue;

                    float coinRoll = (float)random.Next(1, 101) / 100;
                    if(coinRoll <= GameSettings.Coin.DropChance)
                    {
                        float typeRoll = (float)random.Next(1,101) / 100;
                        CoinType type = typeRoll <= GameSettings.Coin.GoldChance? CoinType.Gold: CoinType.Silver;
                        coinList.Add(new Coin(enemy.X , enemy.Y + 2 * enemy.CollisionRadius, type));
                    }

                    int num = random.Next(1, 101);
                    float chance = (float)num / 100;
                    if(enemy is  StandardEnemy)
                    {
                        if (chance <= GameSettings.StandardEnemy.ShieldChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.SheildRadius, PowerUpType.Shield));
                        }
                        else if (chance <= GameSettings.StandardEnemy.ShieldChance +
                            GameSettings.StandardEnemy.TripleShotChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.TripleShotRadius, PowerUpType.TripleShot));
                        }
                        else if(chance <= GameSettings.StandardEnemy.ShieldChance +
                            GameSettings.StandardEnemy.TripleShotChance + 
                            GameSettings.StandardEnemy.FireRateBoosterChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.FireRateBoosterRadius, PowerUpType.FireRateBooster));
                        }
                        else if(chance <= GameSettings.StandardEnemy.ShieldChance +
                            GameSettings.StandardEnemy.TripleShotChance +
                            GameSettings.StandardEnemy.FireRateBoosterChance +
                            GameSettings.StandardEnemy.HealthPackChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.HealthPackRadius, PowerUpType.HealthPack));
                        }
                    }
                    else if(enemy is ScoutEnemy)
                    {
                        if (chance <= GameSettings.ScoutEnemy.ShieldChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.SheildRadius, PowerUpType.Shield));
                        }
                        else if (chance <= GameSettings.ScoutEnemy.ShieldChance +
                            GameSettings.ScoutEnemy.TripleShotChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.TripleShotRadius, PowerUpType.TripleShot));
                        }
                        else if (chance <= GameSettings.ScoutEnemy.ShieldChance +
                            GameSettings.ScoutEnemy.TripleShotChance +
                            GameSettings.ScoutEnemy.FireRateBoosterChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.FireRateBoosterRadius, PowerUpType.FireRateBooster));
                        }
                        else if (chance <= GameSettings.ScoutEnemy.ShieldChance +
                            GameSettings.ScoutEnemy.TripleShotChance +
                            GameSettings.ScoutEnemy.FireRateBoosterChance +
                            GameSettings.ScoutEnemy.HealthPackChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.HealthPackRadius, PowerUpType.HealthPack));
                        }
                    }
                    else if(enemy is ShooterEnemy)
                    {
                        if (chance <= GameSettings.ShooterEnemy.ShieldChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.SheildRadius, PowerUpType.Shield));
                        }
                        else if (chance <= GameSettings.ShooterEnemy.ShieldChance +
                            GameSettings.ShooterEnemy.TripleShotChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.TripleShotRadius, PowerUpType.TripleShot));
                        }
                        else if (chance <= GameSettings.ShooterEnemy.ShieldChance +
                            GameSettings.ShooterEnemy.TripleShotChance +
                            GameSettings.ShooterEnemy.FireRateBoosterChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.FireRateBoosterRadius, PowerUpType.FireRateBooster));
                        }
                        else if (chance <= GameSettings.ShooterEnemy.ShieldChance +
                            GameSettings.ShooterEnemy.TripleShotChance +
                            GameSettings.ShooterEnemy.FireRateBoosterChance +
                            GameSettings.ShooterEnemy.HealthPackChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.HealthPackRadius, PowerUpType.HealthPack));
                        }
                    }
                    else if(enemy is TerroristEnemy)
                    {
                        if (chance <= GameSettings.TerroristEnemy.ShieldChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.SheildRadius, PowerUpType.Shield));
                        }
                        else if (chance <= GameSettings.TerroristEnemy.ShieldChance +
                            GameSettings.TerroristEnemy.TripleShotChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.TripleShotRadius, PowerUpType.TripleShot));
                        }
                        else if (chance <= GameSettings.TerroristEnemy.ShieldChance +
                            GameSettings.TerroristEnemy.TripleShotChance +
                            GameSettings.TerroristEnemy.FireRateBoosterChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.FireRateBoosterRadius, PowerUpType.FireRateBooster));
                        }
                        else if (chance <= GameSettings.TerroristEnemy.ShieldChance +
                            GameSettings.TerroristEnemy.TripleShotChance +
                            GameSettings.TerroristEnemy.FireRateBoosterChance +
                            GameSettings.TerroristEnemy.HealthPackChance)
                        {
                            powerUpList.Add(new PowerUp(enemy.X, enemy.Y + 2 * enemy.CollisionRadius,
                                GameSettings.PowerUp.HealthPackRadius, PowerUpType.HealthPack));
                        }
                    }
                    AudioManager.PlaySfx(Sounds.EnemyDestroyed);
                }
            }
            player.ActivePowerUps.RemoveAll(p => p == PowerUpType.TripleShot && player.TripleShotTimer == 0);
            player.ActivePowerUps.RemoveAll(p => p == PowerUpType.FireRateBooster && player.FireRateBoosterTimer == 0);
            player.ActivePowerUps.RemoveAll(p => p == PowerUpType.Shield && player.ShieldTimer == 0);

            bulletList.RemoveAll(bullet => bullet.Removed || bullet.X < 0 || bullet.X > Width || bullet.Y < 0 || bullet.Y > Height);
            enemyList.RemoveAll(enemy => enemy.IsDead || enemy.X < 0 || enemy.X > Width || enemy.Y > Height);
            powerUpList.RemoveAll(powerUp => powerUp.Removed || powerUp.Y > Height);
            coinList.RemoveAll(coin => coin.Removed || coin.Y >  Height);
        }
        public void Draw(Graphics g)
        {
            player.Draw(g);
            foreach(Enemy enemy in enemyList)
                enemy.Draw(g);
            foreach(Bullet bullet in bulletList)
                bullet.Draw(g);
            foreach(PowerUp powerUp in powerUpList)
                powerUp.Draw(g);
            foreach(Coin coin in  coinList) 
                coin.Draw(g);
        }
    }
}
