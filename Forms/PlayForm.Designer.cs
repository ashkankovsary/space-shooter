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
            timer = new System.Windows.Forms.Timer(components);
            top_panel = new Panel();
            coin = new Label();
            hp_label = new Label();
            score = new Label();
            pause_panel.SuspendLayout();
            top_panel.SuspendLayout();
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
            pause_panel.Size = new Size(800, 450);
            pause_panel.TabIndex = 0;
            pause_panel.Visible = false;
            // 
            // exit_btn
            // 
            exit_btn.Anchor = AnchorStyles.None;
            exit_btn.BackColor = Color.DeepPink;
            exit_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exit_btn.Location = new Point(340, 290);
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
            restart_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            restart_btn.Location = new Point(340, 190);
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
            resume_btn.Location = new Point(340, 90);
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
            paused_lable.Location = new Point(345, 9);
            paused_lable.Name = "paused_lable";
            paused_lable.Size = new Size(139, 50);
            paused_lable.TabIndex = 0;
            paused_lable.Text = "Paused";
            paused_lable.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bottom_panel
            // 
            bottom_panel.BackColor = Color.FromArgb(40, 40, 40);
            bottom_panel.Dock = DockStyle.Bottom;
            bottom_panel.Location = new Point(0, 380);
            bottom_panel.Name = "bottom_panel";
            bottom_panel.Size = new Size(800, 70);
            bottom_panel.TabIndex = 4;
            // 
            // timer
            // 
            timer.Interval = 16;
            timer.Tick += timer_Tick;
            // 
            // top_panel
            // 
            top_panel.BackColor = Color.FromArgb(40, 40, 40);
            top_panel.Controls.Add(coin);
            top_panel.Controls.Add(hp_label);
            top_panel.Controls.Add(score);
            top_panel.Controls.Add(hpbar);
            top_panel.Dock = DockStyle.Top;
            top_panel.Location = new Point(0, 0);
            top_panel.Name = "top_panel";
            top_panel.Size = new Size(800, 70);
            top_panel.TabIndex = 4;
            top_panel.Paint += top_panel_Paint;
            // 
            // coin
            // 
            coin.AutoSize = true;
            coin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            coin.ForeColor = Color.Gold;
            coin.Location = new Point(220, 25);
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
            score.Location = new Point(20, 20);
            score.Name = "score";
            score.Size = new Size(93, 28);
            score.TabIndex = 0;
            score.Text = "Score : 0";
            // 
            // PlayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(bottom_panel);
            Controls.Add(top_panel);
            Controls.Add(pause_panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PlayForm";
            Text = "PlayForm";
            WindowState = FormWindowState.Maximized;
            pause_panel.ResumeLayout(false);
            pause_panel.PerformLayout();
            top_panel.ResumeLayout(false);
            top_panel.PerformLayout();
            ResumeLayout(false);
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
    }
}