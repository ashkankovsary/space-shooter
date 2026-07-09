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

        private int Width;
        private int Height;

        public GameManager(int width, int height)
        {
            Width = width;
            Height = height;

            player = new Player(600, 800);
            enemyList = new List<Enemy>();
            bulletList = new List<Bullet>();

            enemyList.Add(new StandardEnemy(600, 200));
            enemyList.Add(new ScoutEnemy(900, 200));
            enemyList.Add(new ShooterEnemy(1200, 200));
            enemyList.Add(new TerroristEnemy(1100, 200));
        }

        public void Update()
        {
            player.Move(player);
            if (player.Shoot())
            {
                bulletList.Add(new Bullet(player.X, player.Y - player.CollisionRadius, 0, -1, BulletOwner.Player, GameSettings.Player.bulletDamage));
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
            CheckCollision();
            Cleanup();
        }
        public void CheckCollision()
        {
            foreach(Enemy enemy in enemyList)
            {
                if (enemy.IsCollidingWith(player))
                {
                    player.TakeDamage(player.CurrentHP);
                    enemy.TakeDamage(enemy.CurrentHP);
                }
            }
            foreach(Bullet bullet in bulletList)
            {
                if(bullet.Owner == BulletOwner.Enemy)
                {
                    if (bullet.IsCollidingWith(player))
                    {
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
        }
        public void Cleanup()
        {
            bulletList.RemoveAll(bullet => bullet.Removed || bullet.X < 0 || bullet.X > Width || bullet.Y < 0 || bullet.Y > Height);
            enemyList.RemoveAll(enemy => enemy.IsDead || enemy.X < 0 || enemy.X > Width || enemy.Y > Height);
        }
        public void Draw(Graphics g)
        {
            player.Draw(g);
            foreach(Enemy enemy in enemyList)
                enemy.Draw(g);
            foreach(Bullet bullet in bulletList)
                bullet.Draw(g);
        }
    }
}
