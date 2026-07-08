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

        public GameManager()
        {
            player = new Player(600, 800);
            enemyList = new List<Enemy>();
            bulletList = new List<Bullet>();

            enemyList.Add(new StandardEnemy(600, 200));
            enemyList.Add(new ScoutEnemy(900, 200));
            enemyList.Add(new ShooterEnemy(1200, 200));
        }

        public void Update()
        {
            player.Move();
            foreach (Enemy enemy in enemyList)
            {
                enemy.Move();
                if(enemy is ShooterEnemy shooter)
                {
                    if (shooter.Shoot())
                    {
                        bulletList.Add(new Bullet(enemy.X, enemy.Y + enemy.CollisionRadius, 0, 1, 5, BulletOwner.Enemy, 20));
                        shooter.ResetShootTimer();
                    }
                }
            }
            foreach(Bullet bullet in bulletList)
            {
                bullet.Move();
            }
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
