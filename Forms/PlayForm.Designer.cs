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
            pause_panel = new OverlayPanel();
            exit_btn = new Button();
            restart_btn = new Button();
            resume_btn = new Button();
            paused_lable = new Label();
            timer = new System.Windows.Forms.Timer(components);
            pause_panel.SuspendLayout();
            SuspendLayout();
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
            // timer
            // 
            timer.Interval = 16;
            timer.Tick += timer_Tick;
            // 
            // PlayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(pause_panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PlayForm";
            Text = "PlayForm";
            WindowState = FormWindowState.Maximized;
            pause_panel.ResumeLayout(false);
            pause_panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private OverlayPanel pause_panel;
        private Label paused_lable;
        private Button resume_btn;
        private Button exit_btn;
        private Button restart_btn;
        private System.Windows.Forms.Timer timer;
    }
}