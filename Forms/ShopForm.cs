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
    }
}
