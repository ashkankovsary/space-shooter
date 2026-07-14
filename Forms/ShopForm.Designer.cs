namespace Space_Shooter_game.Forms
{
    partial class ShopForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopForm));
            player = new Label();
            enemy = new Label();
            background = new Label();
            ship_skin = new Panel();
            ship3 = new ShopItemControl();
            ship2 = new ShopItemControl();
            ship1 = new ShopItemControl();
            ship_label = new Label();
            ship_bullet = new Panel();
            bullet2 = new ShopItemControl();
            bullet1 = new ShopItemControl();
            bullet = new Label();
            shop_back_btn = new Button();
            enemy_skin = new Panel();
            enemy3 = new ShopItemControl();
            enemy2 = new ShopItemControl();
            enemy1 = new ShopItemControl();
            enemy_label = new Label();
            enemy_bullet = new Panel();
            e_bullet2 = new ShopItemControl();
            e_bullet1 = new ShopItemControl();
            bullet_label = new Label();
            back_ground = new Panel();
            back3 = new ShopItemControl();
            back2 = new ShopItemControl();
            back1 = new ShopItemControl();
            back_label = new Label();
            ship_skin.SuspendLayout();
            ship_bullet.SuspendLayout();
            enemy_skin.SuspendLayout();
            enemy_bullet.SuspendLayout();
            back_ground.SuspendLayout();
            SuspendLayout();
            // 
            // player
            // 
            player.AutoSize = true;
            player.BackColor = Color.Transparent;
            player.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            player.ForeColor = Color.Cyan;
            player.Location = new Point(125, 0);
            player.Name = "player";
            player.Size = new Size(119, 46);
            player.TabIndex = 0;
            player.Text = "Player";
            player.Click += player_Click;
            // 
            // enemy
            // 
            enemy.AutoSize = true;
            enemy.BackColor = Color.Transparent;
            enemy.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            enemy.ForeColor = Color.White;
            enemy.Location = new Point(365, 0);
            enemy.Name = "enemy";
            enemy.Size = new Size(126, 46);
            enemy.TabIndex = 1;
            enemy.Text = "Enemy";
            enemy.Click += enemy_Click;
            // 
            // background
            // 
            background.AutoSize = true;
            background.BackColor = Color.Transparent;
            background.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            background.ForeColor = Color.White;
            background.Location = new Point(665, 0);
            background.Name = "background";
            background.Size = new Size(217, 46);
            background.TabIndex = 2;
            background.Text = "BackGround";
            background.Click += background_Click;
            // 
            // ship_skin
            // 
            ship_skin.Anchor = AnchorStyles.None;
            ship_skin.BackColor = Color.Transparent;
            ship_skin.Controls.Add(ship3);
            ship_skin.Controls.Add(ship2);
            ship_skin.Controls.Add(ship1);
            ship_skin.Controls.Add(ship_label);
            ship_skin.Location = new Point(125, 60);
            ship_skin.Name = "ship_skin";
            ship_skin.Size = new Size(1000, 350);
            ship_skin.TabIndex = 3;
            // 
            // ship3
            // 
            ship3.BackColor = Color.LightGreen;
            ship3.Isowned = false;
            ship3.ItemImage = (Image)resources.GetObject("ship3.ItemImage");
            ship3.Location = new Point(630, 35);
            ship3.Name = "ship3";
            ship3.Price = "0";
            ship3.Size = new Size(225, 300);
            ship3.TabIndex = 3;
            ship3.Click += ship3_Click;
            // 
            // ship2
            // 
            ship2.BackColor = Color.LightGreen;
            ship2.Isowned = false;
            ship2.ItemImage = (Image)resources.GetObject("ship2.ItemImage");
            ship2.Location = new Point(330, 35);
            ship2.Name = "ship2";
            ship2.Price = "0";
            ship2.Size = new Size(225, 300);
            ship2.TabIndex = 2;
            ship2.Click += ship2_Click;
            // 
            // ship1
            // 
            ship1.BackColor = Color.LightGreen;
            ship1.Isowned = false;
            ship1.ItemImage = (Image)resources.GetObject("ship1.ItemImage");
            ship1.Location = new Point(30, 35);
            ship1.Name = "ship1";
            ship1.Price = "0";
            ship1.Size = new Size(225, 300);
            ship1.TabIndex = 1;
            ship1.Click += ship1_Click;
            // 
            // ship_label
            // 
            ship_label.AutoSize = true;
            ship_label.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ship_label.ForeColor = Color.Gold;
            ship_label.Location = new Point(3, 0);
            ship_label.Name = "ship_label";
            ship_label.Size = new Size(61, 31);
            ship_label.TabIndex = 0;
            ship_label.Text = "Skin";
            // 
            // ship_bullet
            // 
            ship_bullet.BackColor = Color.Transparent;
            ship_bullet.Controls.Add(bullet2);
            ship_bullet.Controls.Add(bullet1);
            ship_bullet.Controls.Add(bullet);
            ship_bullet.Location = new Point(125, 60);
            ship_bullet.Name = "ship_bullet";
            ship_bullet.Size = new Size(1000, 350);
            ship_bullet.TabIndex = 4;
            // 
            // bullet2
            // 
            bullet2.BackColor = Color.MediumSlateBlue;
            bullet2.Isowned = false;
            bullet2.ItemImage = (Image)resources.GetObject("bullet2.ItemImage");
            bullet2.Location = new Point(330, 35);
            bullet2.Name = "bullet2";
            bullet2.Price = "0";
            bullet2.Size = new Size(225, 300);
            bullet2.TabIndex = 2;
            bullet2.Click += bullet2_Click;
            // 
            // bullet1
            // 
            bullet1.BackColor = Color.MediumSlateBlue;
            bullet1.Isowned = false;
            bullet1.ItemImage = (Image)resources.GetObject("bullet1.ItemImage");
            bullet1.Location = new Point(30, 35);
            bullet1.Name = "bullet1";
            bullet1.Price = "0";
            bullet1.Size = new Size(225, 300);
            bullet1.TabIndex = 1;
            bullet1.Click += bullet1_Click;
            // 
            // bullet
            // 
            bullet.AutoSize = true;
            bullet.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bullet.ForeColor = Color.Gold;
            bullet.Location = new Point(0, 0);
            bullet.Name = "bullet";
            bullet.Size = new Size(78, 31);
            bullet.TabIndex = 0;
            bullet.Text = "Bullet";
            // 
            // shop_back_btn
            // 
            shop_back_btn.BackColor = Color.DeepPink;
            shop_back_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            shop_back_btn.Location = new Point(12, 12);
            shop_back_btn.Name = "shop_back_btn";
            shop_back_btn.Size = new Size(75, 30);
            shop_back_btn.TabIndex = 5;
            shop_back_btn.Text = "<=";
            shop_back_btn.UseVisualStyleBackColor = false;
            shop_back_btn.Click += shop_back_btn_Click;
            // 
            // enemy_skin
            // 
            enemy_skin.BackColor = Color.Transparent;
            enemy_skin.Controls.Add(enemy3);
            enemy_skin.Controls.Add(enemy2);
            enemy_skin.Controls.Add(enemy1);
            enemy_skin.Controls.Add(enemy_label);
            enemy_skin.Location = new Point(125, 60);
            enemy_skin.Name = "enemy_skin";
            enemy_skin.Size = new Size(1000, 350);
            enemy_skin.TabIndex = 3;
            enemy_skin.Visible = false;
            // 
            // enemy3
            // 
            enemy3.BackColor = Color.Teal;
            enemy3.Isowned = false;
            enemy3.ItemImage = (Image)resources.GetObject("enemy3.ItemImage");
            enemy3.Location = new Point(630, 35);
            enemy3.Name = "enemy3";
            enemy3.Price = "0";
            enemy3.Size = new Size(225, 300);
            enemy3.TabIndex = 3;
            enemy3.Click += enemy3_Click;
            // 
            // enemy2
            // 
            enemy2.BackColor = Color.Teal;
            enemy2.Isowned = false;
            enemy2.ItemImage = (Image)resources.GetObject("enemy2.ItemImage");
            enemy2.Location = new Point(330, 35);
            enemy2.Name = "enemy2";
            enemy2.Price = "0";
            enemy2.Size = new Size(225, 300);
            enemy2.TabIndex = 2;
            enemy2.Click += enemy2_Click;
            // 
            // enemy1
            // 
            enemy1.BackColor = Color.Teal;
            enemy1.Isowned = false;
            enemy1.ItemImage = (Image)resources.GetObject("enemy1.ItemImage");
            enemy1.Location = new Point(30, 35);
            enemy1.Name = "enemy1";
            enemy1.Price = "0";
            enemy1.Size = new Size(225, 300);
            enemy1.TabIndex = 1;
            enemy1.Click += enemy1_Click;
            // 
            // enemy_label
            // 
            enemy_label.AutoSize = true;
            enemy_label.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            enemy_label.ForeColor = Color.Gold;
            enemy_label.Location = new Point(0, 1);
            enemy_label.Name = "enemy_label";
            enemy_label.Size = new Size(61, 31);
            enemy_label.TabIndex = 0;
            enemy_label.Text = "Skin";
            // 
            // enemy_bullet
            // 
            enemy_bullet.BackColor = Color.Transparent;
            enemy_bullet.Controls.Add(e_bullet2);
            enemy_bullet.Controls.Add(e_bullet1);
            enemy_bullet.Controls.Add(bullet_label);
            enemy_bullet.Location = new Point(125, 60);
            enemy_bullet.Name = "enemy_bullet";
            enemy_bullet.Size = new Size(1000, 350);
            enemy_bullet.TabIndex = 6;
            enemy_bullet.Visible = false;
            // 
            // e_bullet2
            // 
            e_bullet2.BackColor = Color.Salmon;
            e_bullet2.Isowned = false;
            e_bullet2.ItemImage = (Image)resources.GetObject("e_bullet2.ItemImage");
            e_bullet2.Location = new Point(330, 35);
            e_bullet2.Name = "e_bullet2";
            e_bullet2.Price = "0";
            e_bullet2.Size = new Size(225, 300);
            e_bullet2.TabIndex = 2;
            e_bullet2.Click += e_bullet2_Click;
            // 
            // e_bullet1
            // 
            e_bullet1.BackColor = Color.Salmon;
            e_bullet1.Isowned = false;
            e_bullet1.ItemImage = (Image)resources.GetObject("e_bullet1.ItemImage");
            e_bullet1.Location = new Point(30, 35);
            e_bullet1.Name = "e_bullet1";
            e_bullet1.Price = "0";
            e_bullet1.Size = new Size(225, 300);
            e_bullet1.TabIndex = 1;
            e_bullet1.Click += e_bullet1_Click;
            // 
            // bullet_label
            // 
            bullet_label.AutoSize = true;
            bullet_label.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bullet_label.ForeColor = Color.Gold;
            bullet_label.Location = new Point(0, 0);
            bullet_label.Name = "bullet_label";
            bullet_label.Size = new Size(78, 31);
            bullet_label.TabIndex = 0;
            bullet_label.Text = "Bullet";
            // 
            // back_ground
            // 
            back_ground.BackColor = Color.Transparent;
            back_ground.Controls.Add(back3);
            back_ground.Controls.Add(back2);
            back_ground.Controls.Add(back1);
            back_ground.Controls.Add(back_label);
            back_ground.Location = new Point(125, 60);
            back_ground.Name = "back_ground";
            back_ground.Size = new Size(1000, 350);
            back_ground.TabIndex = 7;
            back_ground.Visible = false;
            // 
            // back3
            // 
            back3.BackColor = Color.Khaki;
            back3.Isowned = false;
            back3.ItemImage = (Image)resources.GetObject("back3.ItemImage");
            back3.Location = new Point(630, 35);
            back3.Name = "back3";
            back3.Price = "0";
            back3.Size = new Size(225, 300);
            back3.TabIndex = 3;
            back3.Click += back3_Click;
            // 
            // back2
            // 
            back2.BackColor = Color.Khaki;
            back2.Isowned = false;
            back2.ItemImage = (Image)resources.GetObject("back2.ItemImage");
            back2.Location = new Point(330, 35);
            back2.Name = "back2";
            back2.Price = "0";
            back2.Size = new Size(225, 300);
            back2.TabIndex = 2;
            back2.Click += back2_Click;
            // 
            // back1
            // 
            back1.BackColor = Color.Khaki;
            back1.Isowned = false;
            back1.ItemImage = (Image)resources.GetObject("back1.ItemImage");
            back1.Location = new Point(30, 35);
            back1.Name = "back1";
            back1.Price = "0";
            back1.Size = new Size(225, 300);
            back1.TabIndex = 1;
            back1.Click += back1_Click;
            // 
            // back_label
            // 
            back_label.AutoSize = true;
            back_label.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            back_label.ForeColor = Color.Gold;
            back_label.Location = new Point(0, 0);
            back_label.Name = "back_label";
            back_label.Size = new Size(146, 31);
            back_label.TabIndex = 0;
            back_label.Text = "BackGround";
            // 
            // ShopForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1221, 608);
            Controls.Add(back_ground);
            Controls.Add(enemy_bullet);
            Controls.Add(enemy_skin);
            Controls.Add(shop_back_btn);
            Controls.Add(ship_bullet);
            Controls.Add(ship_skin);
            Controls.Add(background);
            Controls.Add(enemy);
            Controls.Add(player);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "ShopForm";
            Text = "ShopForm";
            WindowState = FormWindowState.Maximized;
            ship_skin.ResumeLayout(false);
            ship_skin.PerformLayout();
            ship_bullet.ResumeLayout(false);
            ship_bullet.PerformLayout();
            enemy_skin.ResumeLayout(false);
            enemy_skin.PerformLayout();
            enemy_bullet.ResumeLayout(false);
            enemy_bullet.PerformLayout();
            back_ground.ResumeLayout(false);
            back_ground.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label player;
        private Label enemy;
        private Label background;
        private Panel ship_skin;
        private Label ship_label;
        private ShopItemControl ship2;
        private ShopItemControl ship1;
        private ShopItemControl ship3;
        private Panel ship_bullet;
        private Label bullet;
        private ShopItemControl bullet1;
        private ShopItemControl bullet2;
        private Button shop_back_btn;
        private Panel enemy_skin;
        private ShopItemControl enemy2;
        private ShopItemControl enemy1;
        private Label enemy_label;
        private ShopItemControl enemy3;
        private Panel enemy_bullet;
        private Label bullet_label;
        private ShopItemControl e_bullet2;
        private ShopItemControl e_bullet1;
        private Panel back_ground;
        private Label back_label;
        private ShopItemControl back3;
        private ShopItemControl back2;
        private ShopItemControl back1;
    }
}