using Space_Shooter_game.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Space_Shooter_game.Forms
{
    public partial class ShopForm : ManagedForm
    {
        public ShopForm()
        {
            InitializeComponent();
            this.Shown += ShopForm_Shown;
        }

        private void ShopForm_Shown(object sender, EventArgs e)
        {
            ship_skin.Location = new Point(125, 60);
            ship_bullet.Location = new Point(125, 450);
            enemy_skin.Location = new Point(125, 60);
            enemy_bullet.Location = new Point(125, 450);
            back_ground.Location = new Point(125, 60);

            ship1.ItemId = 1;
            ship2.ItemId = 2;
            ship3.ItemId = 3;
            bullet1.ItemId = 4;
            bullet2.ItemId = 5;
            enemy1.ItemId = 6;
            enemy2.ItemId = 7;
            enemy3.ItemId = 8;
            e_bullet1.ItemId = 9;
            e_bullet2.ItemId = 10;
            back1.ItemId = 11;
            back2.ItemId = 12;
            back3.ItemId = 13;

            ship1.Category = "Ship";
            ship2.Category = "Ship";
            ship3.Category = "Ship";
            bullet1.Category = "PlayerBullet";
            bullet2.Category = "PlayerBullet";
            enemy1.Category = "Enemy";
            enemy2.Category = "Enemy";
            enemy3.Category = "Enemy";
            e_bullet1.Category = "EnemyBullet";
            e_bullet2.Category = "EnemyBullet";
            back1.Category = "Background";
            back2.Category= "Background";
            back3.Category = "Background";

            ship1.UpdateItem(1);
            ship2.UpdateItem(2);
            ship3.UpdateItem(3);
            bullet1.UpdateItem(4);
            bullet2.UpdateItem(5);
            enemy1.UpdateItem(6);
            enemy2.UpdateItem(7);
            enemy3.UpdateItem(8);
            e_bullet1.UpdateItem(9);
            e_bullet2.UpdateItem(10);
            back1.UpdateItem(11);
            back2.UpdateItem(12);
            back3.UpdateItem(13);
        }

        private void shop_back_btn_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            this.Close();
        }

        private void player_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            if (!ship_skin.Visible)
            {
                ship_skin.Visible = true;
                ship_bullet.Visible = true;
                enemy_skin.Visible = false;
                enemy_bullet.Visible = false;
                back_ground.Visible = false;
                player.ForeColor = Color.Cyan;
                enemy.ForeColor = Color.White;
                background.ForeColor = Color.White;
            }
        }

        private void enemy_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            if (!enemy_skin.Visible)
            {
                ship_skin.Visible = false;
                ship_bullet.Visible = false;
                enemy_skin.Visible = true;
                enemy_bullet.Visible = true;
                back_ground.Visible = false;
                player.ForeColor = Color.White;
                enemy.ForeColor = Color.Cyan;
                background.ForeColor = Color.White;
            }
        }

        private void background_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            if (!back_ground.Visible)
            {
                ship_skin.Visible = false;
                ship_bullet.Visible = false;
                enemy_skin.Visible = false;
                enemy_bullet.Visible = false;
                back_ground.Visible = true;
                player.ForeColor = Color.White;
                enemy.ForeColor = Color.White;
                background.ForeColor = Color.Cyan;
            }
        }

        private void HandleShopItemClick(ShopItemControl item)
        {
            item.IsBuyed = Database.IsOwned(item.ItemId);
            item.IsActived = Database.IsSelected(item.ItemId);

            if (!item.IsBuyed)
            {
                int price = Database.GetItemPrice(item.ItemId);
                if (Database.SpendCoins(price))
                {
                    Database.BuyItem(item.ItemId);
                    item.IsBuyed = true;
                    item.UpdateItem(item.ItemId);
                }
            }
            else if (!item.IsActived)
            {
                Database.SelectItem(item.ItemId);
                RefreshCategory(item.Category);
            }
        }

        private void RefreshCategory(string category)
        {
            foreach (Control c in Controls)
            {
                if (c is ShopItemControl item && item.Category == category)
                {
                    item.IsBuyed = Database.IsOwned(item.ItemId);
                    item.IsActived = Database.IsSelected(item.ItemId);
                    item.UpdateItem(item.ItemId);
                }
            }
        }
        private void ship1_Click(object sender, EventArgs e)
        {
            HandleShopItemClick(ship1);
        }

        private void ship2_Click(object sender, EventArgs e)
        {
            HandleShopItemClick(ship2);
        }

        private void ship3_Click(object sender, EventArgs e)
        {
            HandleShopItemClick(ship3);
        }

        private void bullet1_Click(object sender, EventArgs e)
        {
            HandleShopItemClick(bullet1);
        }

        private void bullet2_Click(object sender, EventArgs e)
        {
            HandleShopItemClick(bullet2);
        }

        private void enemy1_Click(object sender, EventArgs e)
        {
            HandleShopItemClick(enemy1);
        }

        private void enemy2_Click(object sender, EventArgs e)
        {
            HandleShopItemClick(enemy2);
        }

        private void enemy3_Click(object sender, EventArgs e)
        {
            HandleShopItemClick(enemy3);
        }

        private void e_bullet1_Click(object sender, EventArgs e)
        {
            HandleShopItemClick(e_bullet1);
        }

        private void e_bullet2_Click(object sender, EventArgs e)
        {
            HandleShopItemClick(e_bullet2);
        }

        private void back1_Click(object sender, EventArgs e)
        {
            HandleShopItemClick(back1);
        }

        private void back2_Click(object sender, EventArgs e)
        {
            HandleShopItemClick(back2);
        }

        private void back3_Click(object sender, EventArgs e)
        {
            HandleShopItemClick(back3);
        }
    }
}
