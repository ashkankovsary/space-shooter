namespace Space_Shooter_game
{
    partial class PlayForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayForm));
            hpbar = new HPbar();
            pause_panel = new OverlayPanel();
            exit_btn = new Button();
            restart_btn = new Button();
            resume_btn = new Button();
            paused_lable = new Label();
            bottom_panel = new Panel();
            powerup3 = new HPbar();
            powerup1 = new HPbar();
            powerup3_icon = new PictureBox();
            powerup2 = new HPbar();
            powerup2_icon = new PictureBox();
            powerup1_icon = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            top_panel = new Panel();
            EX_icon = new PictureBox();
            pic_coin = new PictureBox();
            coin = new Label();
            hp_label = new Label();
            score = new Label();
            wave_label = new Label();
            wave_banner = new Label();
            victory_panel = new OverlayPanel();
            victory_menu_btn = new Button();
            victory_restart_btn = new Button();
            victory_coins_label = new Label();
            victory_score_label = new Label();
            victory_label = new Label();
            gameover_panel = new OverlayPanel();
            gameover_menu_btn = new Button();
            gameover_restart_btn = new Button();
            gameover_coins_label = new Label();
            gameover_score_label = new Label();
            gameover_wave_label = new Label();
            gameover_label = new Label();
            pause_panel.SuspendLayout();
            bottom_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)powerup3_icon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)powerup2_icon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)powerup1_icon).BeginInit();
            top_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EX_icon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_coin).BeginInit();
            victory_panel.SuspendLayout();
            gameover_panel.SuspendLayout();
            SuspendLayout();
            // 
            // hpbar
            // 
            hpbar.CurrentHP = 100;
            hpbar.Location = new Point(550, 20);
            hpbar.MaxHP = 100;
            hpbar.Name = "hpbar";
            hpbar.Size = new Size(250, 24);
            hpbar.TabIndex = 1;
            // 
            // pause_panel
            // 
            pause_panel.BackColor = Color.Transparent;
            pause_panel.Controls.Add(exit_btn);
            pause_panel.Controls.Add(restart_btn);
            pause_panel.Controls.Add(resume_btn);
            pause_panel.Controls.Add(paused_lable);
            pause_panel.Dock = DockStyle.Fill;
            pause_panel.Location = new Point(0, 0);
            pause_panel.Name = "pause_panel";
            pause_panel.Size = new Size(1221, 608);
            pause_panel.TabIndex = 0;
            pause_panel.Visible = false;
            // 
            // exit_btn
            // 
            exit_btn.Anchor = AnchorStyles.None;
            exit_btn.BackColor = Color.DeepPink;
            exit_btn.Cursor = Cursors.Hand;
            exit_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exit_btn.Location = new Point(550, 369);
            exit_btn.Name = "exit_btn";
            exit_btn.Size = new Size(150, 60);
            exit_btn.TabIndex = 3;
            exit_btn.Text = "Exit";
            exit_btn.UseVisualStyleBackColor = false;
            // 
            // restart_btn
            // 
            restart_btn.Anchor = AnchorStyles.None;
            restart_btn.BackColor = Color.DeepPink;
            restart_btn.Cursor = Cursors.Hand;
            restart_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            restart_btn.Location = new Point(550, 269);
            restart_btn.Name = "restart_btn";
            restart_btn.Size = new Size(150, 60);
            restart_btn.TabIndex = 2;
            restart_btn.Text = "Restart";
            restart_btn.UseVisualStyleBackColor = false;
            // 
            // resume_btn
            // 
            resume_btn.Anchor = AnchorStyles.None;
            resume_btn.BackColor = Color.DeepPink;
            resume_btn.Cursor = Cursors.Hand;
            resume_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            resume_btn.Location = new Point(550, 169);
            resume_btn.Name = "resume_btn";
            resume_btn.Size = new Size(150, 60);
            resume_btn.TabIndex = 1;
            resume_btn.Text = "Resume";
            resume_btn.UseVisualStyleBackColor = false;
            // 
            // paused_lable
            // 
            paused_lable.Anchor = AnchorStyles.None;
            paused_lable.AutoSize = true;
            paused_lable.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            paused_lable.ForeColor = Color.Violet;
            paused_lable.Location = new Point(555, 88);
            paused_lable.Name = "paused_lable";
            paused_lable.Size = new Size(139, 50);
            paused_lable.TabIndex = 0;
            paused_lable.Text = "Paused";
            paused_lable.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bottom_panel
            // 
            bottom_panel.BackColor = Color.FromArgb(40, 40, 40);
            bottom_panel.Controls.Add(powerup3);
            bottom_panel.Controls.Add(powerup1);
            bottom_panel.Controls.Add(powerup3_icon);
            bottom_panel.Controls.Add(powerup2);
            bottom_panel.Controls.Add(powerup2_icon);
            bottom_panel.Controls.Add(powerup1_icon);
            bottom_panel.Dock = DockStyle.Bottom;
            bottom_panel.Location = new Point(0, 538);
            bottom_panel.Name = "bottom_panel";
            bottom_panel.Size = new Size(1221, 70);
            bottom_panel.TabIndex = 4;
            //
            // 
            //
            int eachPowerUp = 400;
            int space = 100;
            // 
            // powerup3
            // 
            powerup3.TabIndex = 2;
            powerup3.CurrentHP = 100;
            powerup3.Location = new Point(powerup3.TabIndex * (eachPowerUp + space) + space + 45, 18);
            powerup3.MaxHP = 100;
            powerup3.Name = "powerup3";
            powerup3.Size = new Size(eachPowerUp - 66, 36);
            powerup3.Text = "hPbar2";
            powerup3.Visible = false;
            // 
            // powerup2
            // 
            powerup2.TabIndex = 1;
            powerup2.CurrentHP = 100;
            powerup2.Location = new Point(powerup2.TabIndex * (eachPowerUp + space) + space + 45, 18);
            powerup2.MaxHP = 100;
            powerup2.Name = "powerup2";
            powerup2.Size = new Size(eachPowerUp - 66, 36);
            powerup2.Text = "hPbar1";
            powerup2.Visible = false;
            // 
            // powerup1
            // 
            powerup1.TabIndex = 0;
            powerup1.CurrentHP = 100;
            powerup1.Location = new Point(powerup1.TabIndex * (eachPowerUp + space) + space + 45, 18);
            powerup1.MaxHP = 100;
            powerup1.Name = "powerup1";
            powerup1.Size = new Size(eachPowerUp - 66, 36);
            powerup1.Text = "hPbar1";
            // 
            // powerup3_icon
            // 
            powerup3_icon.Location = new Point(powerup3.TabIndex * (eachPowerUp + space) + space, 18);
            powerup3_icon.Name = "powerup3_icon";
            powerup3_icon.Size = new Size(36, 36);
            powerup3_icon.SizeMode = PictureBoxSizeMode.Zoom;
            powerup3_icon.TabIndex = 3;
            powerup3_icon.TabStop = false;
            powerup3_icon.Visible = false;
            // 
            // powerup2_icon
            // 
            powerup2_icon.Location = new Point(powerup2.TabIndex * (eachPowerUp + space) + space, 18);
            powerup2_icon.Name = "powerup2_icon";
            powerup2_icon.Size = new Size(36, 36);
            powerup2_icon.SizeMode = PictureBoxSizeMode.Zoom;
            powerup2_icon.TabIndex = 4;
            powerup2_icon.TabStop = false;
            powerup2_icon.Visible = false;
            // 
            // powerup1_icon
            // 
            powerup1_icon.Location = new Point(powerup1.TabIndex * (eachPowerUp + space) + space, 18);
            powerup1_icon.Name = "powerup1_icon";
            powerup1_icon.Size = new Size(36, 36);
            powerup1_icon.SizeMode = PictureBoxSizeMode.Zoom;
            powerup1_icon.TabIndex = 5;
            powerup1_icon.TabStop = false;
            powerup1_icon.Visible = false;
            // 
            // timer
            // 
            timer.Interval = 16;
            timer.Tick += timer_Tick;
            // 
            // top_panel
            // 
            top_panel.BackColor = Color.FromArgb(40, 40, 40);
            top_panel.Controls.Add(EX_icon);
            top_panel.Controls.Add(pic_coin);
            top_panel.Controls.Add(coin);
            top_panel.Controls.Add(hp_label);
            top_panel.Controls.Add(score);
            top_panel.Controls.Add(hpbar);
            top_panel.Controls.Add(wave_label);
            top_panel.Dock = DockStyle.Top;
            top_panel.Location = new Point(0, 0);
            top_panel.Name = "top_panel";
            top_panel.Size = new Size(1221, 70);
            top_panel.TabIndex = 4;
            // 
            // EX_icon
            // 
            EX_icon.Image = Properties.Resources.ex;
            EX_icon.Location = new Point(22, 17);
            EX_icon.Name = "EX_icon";
            EX_icon.Size = new Size(36, 36);
            EX_icon.TabIndex = 6;
            EX_icon.TabStop = false;
            // 
            // pic_coin
            // 
            pic_coin.Image = Properties.Resources.coin;
            pic_coin.InitialImage = Properties.Resources.coin;
            pic_coin.Location = new Point(162, 17);
            pic_coin.Name = "pic_coin";
            pic_coin.Size = new Size(36, 36);
            pic_coin.TabIndex = 4;
            pic_coin.TabStop = false;
            // 
            // coin
            // 
            coin.AutoSize = true;
            coin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            coin.ForeColor = Color.Gold;
            coin.Location = new Point(204, 21);
            coin.Name = "coin";
            coin.Size = new Size(24, 28);
            coin.TabIndex = 3;
            coin.Text = "0";
            // 
            // hp_label
            // 
            hp_label.AutoSize = true;
            hp_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hp_label.ForeColor = Color.White;
            hp_label.Location = new Point(510, 15);
            hp_label.Name = "hp_label";
            hp_label.Size = new Size(39, 28);
            hp_label.TabIndex = 2;
            hp_label.Text = "HP";
            // 
            // score
            // 
            score.AutoSize = true;
            score.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            score.ForeColor = Color.Cyan;
            score.Location = new Point(64, 21);
            score.Name = "score";
            score.Size = new Size(24, 28);
            score.TabIndex = 0;
            score.Text = "0";
            // 
            // wave_label
            // 
            wave_label.AutoSize = true;
            wave_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            wave_label.ForeColor = Color.White;
            wave_label.Location = new Point(560, 21);
            wave_label.Name = "wave_label";
            wave_label.Size = new Size(82, 28);
            wave_label.TabIndex = 7;
            wave_label.Text = "Wave 1";
            // 
            // wave_banner
            // 
            wave_banner.AutoSize = true;
            wave_banner.BackColor = Color.FromArgb(40, 40, 40);
            wave_banner.Font = new Font("Segoe UI", 40F, FontStyle.Bold, GraphicsUnit.Point, 0);
            wave_banner.ForeColor = Color.Gold;
            wave_banner.Location = new Point(0, 0);
            wave_banner.Name = "wave_banner";
            wave_banner.Padding = new Padding(30, 15, 30, 15);
            wave_banner.Size = new Size(326, 119);
            wave_banner.TabIndex = 8;
            wave_banner.Text = "Wave 1";
            wave_banner.Visible = false;
            // 
            // victory_panel
            // 
            victory_panel.BackColor = Color.Transparent;
            victory_panel.Controls.Add(victory_menu_btn);
            victory_panel.Controls.Add(victory_restart_btn);
            victory_panel.Controls.Add(victory_coins_label);
            victory_panel.Controls.Add(victory_score_label);
            victory_panel.Controls.Add(victory_label);
            victory_panel.Dock = DockStyle.Fill;
            victory_panel.Location = new Point(0, 0);
            victory_panel.Name = "victory_panel";
            victory_panel.Size = new Size(1221, 608);
            victory_panel.TabIndex = 5;
            victory_panel.Visible = false;
            // 
            // victory_menu_btn
            // 
            victory_menu_btn.Anchor = AnchorStyles.None;
            victory_menu_btn.BackColor = Color.DeepPink;
            victory_menu_btn.Cursor = Cursors.Hand;
            victory_menu_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            victory_menu_btn.Location = new Point(550, 330);
            victory_menu_btn.Name = "victory_menu_btn";
            victory_menu_btn.Size = new Size(150, 60);
            victory_menu_btn.TabIndex = 4;
            victory_menu_btn.Text = "Menu";
            victory_menu_btn.UseVisualStyleBackColor = false;
            // 
            // victory_restart_btn
            // 
            victory_restart_btn.Anchor = AnchorStyles.None;
            victory_restart_btn.BackColor = Color.DeepPink;
            victory_restart_btn.Cursor = Cursors.Hand;
            victory_restart_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            victory_restart_btn.Location = new Point(550, 250);
            victory_restart_btn.Name = "victory_restart_btn";
            victory_restart_btn.Size = new Size(150, 60);
            victory_restart_btn.TabIndex = 3;
            victory_restart_btn.Text = "Restart";
            victory_restart_btn.UseVisualStyleBackColor = false;
            // 
            // victory_coins_label
            // 
            victory_coins_label.Anchor = AnchorStyles.None;
            victory_coins_label.AutoSize = true;
            victory_coins_label.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            victory_coins_label.ForeColor = Color.Gold;
            victory_coins_label.Location = new Point(545, 190);
            victory_coins_label.Name = "victory_coins_label";
            victory_coins_label.Size = new Size(105, 32);
            victory_coins_label.TabIndex = 2;
            victory_coins_label.Text = "Coins: 0";
            // 
            // victory_score_label
            // 
            victory_score_label.Anchor = AnchorStyles.None;
            victory_score_label.AutoSize = true;
            victory_score_label.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            victory_score_label.ForeColor = Color.Cyan;
            victory_score_label.Location = new Point(545, 150);
            victory_score_label.Name = "victory_score_label";
            victory_score_label.Size = new Size(105, 32);
            victory_score_label.TabIndex = 1;
            victory_score_label.Text = "Score: 0";
            // 
            // victory_label
            // 
            victory_label.Anchor = AnchorStyles.None;
            victory_label.AutoSize = true;
            victory_label.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
            victory_label.ForeColor = Color.Gold;
            victory_label.Location = new Point(535, 70);
            victory_label.Name = "victory_label";
            victory_label.Size = new Size(222, 60);
            victory_label.TabIndex = 0;
            victory_label.Text = "VICTORY!";
            victory_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gameover_panel
            // 
            gameover_panel.BackColor = Color.Transparent;
            gameover_panel.Controls.Add(gameover_menu_btn);
            gameover_panel.Controls.Add(gameover_restart_btn);
            gameover_panel.Controls.Add(gameover_coins_label);
            gameover_panel.Controls.Add(gameover_score_label);
            gameover_panel.Controls.Add(gameover_wave_label);
            gameover_panel.Controls.Add(gameover_label);
            gameover_panel.Dock = DockStyle.Fill;
            gameover_panel.Location = new Point(0, 0);
            gameover_panel.Name = "gameover_panel";
            gameover_panel.Size = new Size(1221, 608);
            gameover_panel.TabIndex = 6;
            gameover_panel.Visible = false;
            // 
            // gameover_menu_btn
            // 
            gameover_menu_btn.Anchor = AnchorStyles.None;
            gameover_menu_btn.BackColor = Color.DeepPink;
            gameover_menu_btn.Cursor = Cursors.Hand;
            gameover_menu_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gameover_menu_btn.Location = new Point(550, 340);
            gameover_menu_btn.Name = "gameover_menu_btn";
            gameover_menu_btn.Size = new Size(150, 60);
            gameover_menu_btn.TabIndex = 5;
            gameover_menu_btn.Text = "Menu";
            gameover_menu_btn.UseVisualStyleBackColor = false;
            // 
            // gameover_restart_btn
            // 
            gameover_restart_btn.Anchor = AnchorStyles.None;
            gameover_restart_btn.BackColor = Color.DeepPink;
            gameover_restart_btn.Cursor = Cursors.Hand;
            gameover_restart_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gameover_restart_btn.Location = new Point(550, 260);
            gameover_restart_btn.Name = "gameover_restart_btn";
            gameover_restart_btn.Size = new Size(150, 60);
            gameover_restart_btn.TabIndex = 4;
            gameover_restart_btn.Text = "Restart";
            gameover_restart_btn.UseVisualStyleBackColor = false;
            // 
            // gameover_coins_label
            // 
            gameover_coins_label.Anchor = AnchorStyles.None;
            gameover_coins_label.AutoSize = true;
            gameover_coins_label.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gameover_coins_label.ForeColor = Color.Gold;
            gameover_coins_label.Location = new Point(545, 200);
            gameover_coins_label.Name = "gameover_coins_label";
            gameover_coins_label.Size = new Size(105, 32);
            gameover_coins_label.TabIndex = 3;
            gameover_coins_label.Text = "Coins: 0";
            // 
            // gameover_score_label
            // 
            gameover_score_label.Anchor = AnchorStyles.None;
            gameover_score_label.AutoSize = true;
            gameover_score_label.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gameover_score_label.ForeColor = Color.Cyan;
            gameover_score_label.Location = new Point(545, 165);
            gameover_score_label.Name = "gameover_score_label";
            gameover_score_label.Size = new Size(105, 32);
            gameover_score_label.TabIndex = 2;
            gameover_score_label.Text = "Score: 0";
            // 
            // gameover_wave_label
            // 
            gameover_wave_label.Anchor = AnchorStyles.None;
            gameover_wave_label.AutoSize = true;
            gameover_wave_label.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gameover_wave_label.ForeColor = Color.White;
            gameover_wave_label.Location = new Point(545, 130);
            gameover_wave_label.Name = "gameover_wave_label";
            gameover_wave_label.Size = new Size(199, 32);
            gameover_wave_label.TabIndex = 1;
            gameover_wave_label.Text = "Reached Wave 1";
            // 
            // gameover_label
            // 
            gameover_label.Anchor = AnchorStyles.None;
            gameover_label.AutoSize = true;
            gameover_label.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gameover_label.ForeColor = Color.Crimson;
            gameover_label.Location = new Point(520, 60);
            gameover_label.Name = "gameover_label";
            gameover_label.Size = new Size(255, 60);
            gameover_label.TabIndex = 0;
            gameover_label.Text = "Game Over";
            gameover_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PlayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1221, 608);
            Controls.Add(bottom_panel);
            Controls.Add(top_panel);
            Controls.Add(wave_banner);
            Controls.Add(victory_panel);
            Controls.Add(gameover_panel);
            Controls.Add(pause_panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PlayForm";
            Text = "PlayForm";
            WindowState = FormWindowState.Maximized;
            pause_panel.ResumeLayout(false);
            pause_panel.PerformLayout();
            bottom_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)powerup3_icon).EndInit();
            ((System.ComponentModel.ISupportInitialize)powerup2_icon).EndInit();
            ((System.ComponentModel.ISupportInitialize)powerup1_icon).EndInit();
            top_panel.ResumeLayout(false);
            top_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)EX_icon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_coin).EndInit();
            victory_panel.ResumeLayout(false);
            victory_panel.PerformLayout();
            gameover_panel.ResumeLayout(false);
            gameover_panel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private HPbar hpbar;
        private OverlayPanel pause_panel;
        private Label paused_lable;
        private Button resume_btn;
        private Button exit_btn;
        private Button restart_btn;
        private System.Windows.Forms.Timer timer;
        private Panel top_panel;
        private Panel bottom_panel;
        private Label score;
        private Label hp_label;
        private Label coin;
        private Label wave_label;
        private Label wave_banner;
        private PictureBox pic_coin;
        private PictureBox EX_icon;
        private HPbar powerup1;
        private HPbar powerup2;
        private HPbar powerup3;
        private PictureBox powerup1_icon;
        private PictureBox powerup2_icon;
        private PictureBox powerup3_icon;
        private OverlayPanel victory_panel;
        private Label victory_label;
        private Label victory_score_label;
        private Label victory_coins_label;
        private Button victory_restart_btn;
        private Button victory_menu_btn;
        private OverlayPanel gameover_panel;
        private Label gameover_label;
        private Label gameover_wave_label;
        private Label gameover_score_label;
        private Label gameover_coins_label;
        private Button gameover_restart_btn;
        private Button gameover_menu_btn;
    }
}