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

            enemyList.Add(new StandardEnemy(600, 200));
            enemyList.Add(new ScoutEnemy(900, 200));
            enemyList.Add(new ShooterEnemy(1200, 200));
            enemyList.Add(new TerroristEnemy(1100, 200));
        }

        public void Update()
        {
            player.Move(player);
            player.CheckTripleShot();
            player.CheckFireRateBooster();
            player.CheckShield();

            if (player.Shoot())
            {
                if (player.FireRateBoosterTimer > 0)
                    player.shootCooldown = GameSettings.Player.ShootCooldown / 2;
                bulletList.Add(new Bullet(player.X, player.Y - player.CollisionRadius, 0, -1, BulletOwner.Player, GameSettings.Player.bulletDamage));
                if(player.TripleShotTimer > 0)
                {
                    bulletList.Add(new Bullet(player.X, player.Y - player.CollisionRadius, -0.6f, -0.8f, BulletOwner.Player, GameSettings.Player.bulletDamage));
                    bulletList.Add(new Bullet(player.X, player.Y - player.CollisionRadius, 0.6f, -0.8f, BulletOwner.Player, GameSettings.Player.bulletDamage));
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
                    else player.TakeDamage(player.CurrentHP);
                    enemy.TakeDamage(enemy.CurrentHP);
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
                    }
                    else if(powerUp.Type == PowerUpType.TripleShot)
                    {
                        if(player.TripleShotTimer == 0)
                            player.ActivePowerUps.Add(PowerUpType.TripleShot);
                        player.TripleShotTimer = 300;
                    }
                    else if(powerUp.Type == PowerUpType.FireRateBooster)
                    {
                        if (player.FireRateBoosterTimer == 0)
                            player.ActivePowerUps.Add(PowerUpType.FireRateBooster);
                        player.FireRateBoosterTimer = 300;
                    }
                    else if(powerUp.Type == PowerUpType.Shield)
                    {
                        if (player.ShieldTimer == 0)
                            player.ActivePowerUps.Add(PowerUpType.Shield);
                        player.ShieldTimer = 150;
                    }
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
                }
            }
            player.ActivePowerUps.RemoveAll(p => p == PowerUpType.TripleShot && player.TripleShotTimer == 0);
            player.ActivePowerUps.RemoveAll(p => p == PowerUpType.FireRateBooster && player.FireRateBoosterTimer == 0);
            player.ActivePowerUps.RemoveAll(p => p == PowerUpType.Shield && player.ShieldTimer == 0);

            bulletList.RemoveAll(bullet => bullet.Removed || bullet.X < 0 || bullet.X > Width || bullet.Y < 0 || bullet.Y > Height);
            enemyList.RemoveAll(enemy => enemy.IsDead || enemy.X < 0 || enemy.X > Width || enemy.Y > Height);
            powerUpList.RemoveAll(powerUp => powerUp.Removed || powerUp.Y > Height);
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
        }
    }
}
