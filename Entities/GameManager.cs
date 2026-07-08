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
        }

        public void Draw(Graphics g)
        {
            player.Draw(g);
        }
    }
}
