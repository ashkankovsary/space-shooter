namespace Space_Shooter_game.Forms
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            audio_btn = new Button();
            guide_btn = new Button();
            options_back_btn = new Button();
            guide_panel = new Panel();
            back_guide_btn = new Button();
            audio_panel = new Panel();
            sfx_on = new PictureBox();
            music_on = new PictureBox();
            audio_back_btn = new Button();
            sfx_off = new PictureBox();
            music_off = new PictureBox();
            sfx_label = new Label();
            music_label = new Label();
            guide_panel.SuspendLayout();
            audio_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfx_on).BeginInit();
            ((System.ComponentModel.ISupportInitialize)music_on).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sfx_off).BeginInit();
            ((System.ComponentModel.ISupportInitialize)music_off).BeginInit();
            SuspendLayout();
            // 
            // audio_btn
            // 
            audio_btn.Anchor = AnchorStyles.None;
            audio_btn.BackColor = Color.DeepPink;
            audio_btn.Cursor = Cursors.Hand;
            audio_btn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            audio_btn.Location = new Point(488, 80);
            audio_btn.Name = "audio_btn";
            audio_btn.Size = new Size(244, 71);
            audio_btn.TabIndex = 0;
            audio_btn.Text = "Audio Controls";
            audio_btn.UseVisualStyleBackColor = false;
            audio_btn.Click += audio_btn_Click;
            // 
            // guide_btn
            // 
            guide_btn.Anchor = AnchorStyles.None;
            guide_btn.BackColor = Color.DeepPink;
            guide_btn.Cursor = Cursors.Hand;
            guide_btn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guide_btn.Location = new Point(488, 214);
            guide_btn.Name = "guide_btn";
            guide_btn.Size = new Size(244, 71);
            guide_btn.TabIndex = 1;
            guide_btn.Text = "Controls Guide";
            guide_btn.UseVisualStyleBackColor = false;
            guide_btn.Click += guide_btn_Click;
            // 
            // options_back_btn
            // 
            options_back_btn.BackColor = Color.DeepPink;
            options_back_btn.Cursor = Cursors.Hand;
            options_back_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            options_back_btn.Location = new Point(12, 12);
            options_back_btn.Name = "options_back_btn";
            options_back_btn.Size = new Size(74, 29);
            options_back_btn.TabIndex = 2;
            options_back_btn.Text = "<=";
            options_back_btn.UseVisualStyleBackColor = false;
            options_back_btn.Click += options_back_btn_Click;
            // 
            // guide_panel
            // 
            guide_panel.BackgroundImage = (Image)resources.GetObject("guide_panel.BackgroundImage");
            guide_panel.BackgroundImageLayout = ImageLayout.Stretch;
            guide_panel.Controls.Add(back_guide_btn);
            guide_panel.Dock = DockStyle.Fill;
            guide_panel.Location = new Point(0, 0);
            guide_panel.Name = "guide_panel";
            guide_panel.Size = new Size(1221, 608);
            guide_panel.TabIndex = 3;
            guide_panel.Visible = false;
            // 
            // back_guide_btn
            // 
            back_guide_btn.BackColor = Color.DeepPink;
            back_guide_btn.Cursor = Cursors.Hand;
            back_guide_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            back_guide_btn.Location = new Point(12, 12);
            back_guide_btn.Name = "back_guide_btn";
            back_guide_btn.Size = new Size(74, 29);
            back_guide_btn.TabIndex = 0;
            back_guide_btn.Text = "<=";
            back_guide_btn.UseVisualStyleBackColor = false;
            back_guide_btn.Click += back_guide_btn_Click;
            // 
            // audio_panel
            // 
            audio_panel.BackgroundImage = (Image)resources.GetObject("audio_panel.BackgroundImage");
            audio_panel.BackgroundImageLayout = ImageLayout.Stretch;
            audio_panel.Controls.Add(sfx_on);
            audio_panel.Controls.Add(music_on);
            audio_panel.Controls.Add(audio_back_btn);
            audio_panel.Controls.Add(sfx_off);
            audio_panel.Controls.Add(music_off);
            audio_panel.Controls.Add(sfx_label);
            audio_panel.Controls.Add(music_label);
            audio_panel.Dock = DockStyle.Fill;
            audio_panel.Location = new Point(0, 0);
            audio_panel.Name = "audio_panel";
            audio_panel.Size = new Size(1221, 608);
            audio_panel.TabIndex = 1;
            audio_panel.Visible = false;
            // 
            // sfx_on
            // 
            sfx_on.Anchor = AnchorStyles.None;
            sfx_on.BackColor = Color.Transparent;
            sfx_on.Cursor = Cursors.Hand;
            sfx_on.Image = (Image)resources.GetObject("sfx_on.Image");
            sfx_on.Location = new Point(662, 223);
            sfx_on.Name = "sfx_on";
            sfx_on.Size = new Size(82, 41);
            sfx_on.TabIndex = 6;
            sfx_on.TabStop = false;
            sfx_on.Click += sfx_on_Click;
            // 
            // music_on
            // 
            music_on.Anchor = AnchorStyles.None;
            music_on.BackColor = Color.Transparent;
            music_on.Cursor = Cursors.Hand;
            music_on.Image = (Image)resources.GetObject("music_on.Image");
            music_on.Location = new Point(662, 149);
            music_on.Name = "music_on";
            music_on.Size = new Size(82, 39);
            music_on.TabIndex = 5;
            music_on.TabStop = false;
            music_on.Click += music_on_Click;
            // 
            // audio_back_btn
            // 
            audio_back_btn.BackColor = Color.DeepPink;
            audio_back_btn.Cursor = Cursors.Hand;
            audio_back_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            audio_back_btn.Location = new Point(12, 12);
            audio_back_btn.Name = "audio_back_btn";
            audio_back_btn.Size = new Size(74, 29);
            audio_back_btn.TabIndex = 4;
            audio_back_btn.Text = "<=";
            audio_back_btn.UseVisualStyleBackColor = false;
            audio_back_btn.Click += audio_back_btn_Click;
            // 
            // sfx_off
            // 
            sfx_off.Anchor = AnchorStyles.None;
            sfx_off.BackColor = Color.Transparent;
            sfx_off.Cursor = Cursors.Hand;
            sfx_off.Image = (Image)resources.GetObject("sfx_off.Image");
            sfx_off.Location = new Point(662, 223);
            sfx_off.Name = "sfx_off";
            sfx_off.Size = new Size(82, 41);
            sfx_off.TabIndex = 3;
            sfx_off.TabStop = false;
            sfx_off.Click += sfx_off_Click;
            // 
            // music_off
            // 
            music_off.Anchor = AnchorStyles.None;
            music_off.BackColor = Color.Transparent;
            music_off.Cursor = Cursors.Hand;
            music_off.Image = (Image)resources.GetObject("music_off.Image");
            music_off.Location = new Point(662, 149);
            music_off.Name = "music_off";
            music_off.Size = new Size(84, 38);
            music_off.TabIndex = 2;
            music_off.TabStop = false;
            music_off.Click += music_off_Click;
            // 
            // sfx_label
            // 
            sfx_label.Anchor = AnchorStyles.None;
            sfx_label.AutoSize = true;
            sfx_label.BackColor = Color.Transparent;
            sfx_label.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            sfx_label.ForeColor = Color.White;
            sfx_label.Location = new Point(525, 211);
            sfx_label.Name = "sfx_label";
            sfx_label.Size = new Size(107, 62);
            sfx_label.TabIndex = 1;
            sfx_label.Text = "SFX";
            // 
            // music_label
            // 
            music_label.Anchor = AnchorStyles.None;
            music_label.AutoSize = true;
            music_label.BackColor = Color.Transparent;
            music_label.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            music_label.ForeColor = Color.White;
            music_label.Location = new Point(488, 135);
            music_label.Name = "music_label";
            music_label.Size = new Size(154, 62);
            music_label.TabIndex = 0;
            music_label.Text = "Music";
            // 
            // OptionsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1221, 608);
            Controls.Add(audio_panel);
            Controls.Add(guide_panel);
            Controls.Add(options_back_btn);
            Controls.Add(guide_btn);
            Controls.Add(audio_btn);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "OptionsForm";
            Text = "OptionsForm";
            WindowState = FormWindowState.Maximized;
            guide_panel.ResumeLayout(false);
            audio_panel.ResumeLayout(false);
            audio_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sfx_on).EndInit();
            ((System.ComponentModel.ISupportInitialize)music_on).EndInit();
            ((System.ComponentModel.ISupportInitialize)sfx_off).EndInit();
            ((System.ComponentModel.ISupportInitialize)music_off).EndInit();
            ResumeLayout(false);
        }

        private void Audio_btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Guide_btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button audio_btn;
        private Button guide_btn;
        private Button options_back_btn;
        private Panel guide_panel;
        private Button back_guide_btn;
        private Panel audio_panel;
        private Label music_label;
        private PictureBox music_off;
        private Label sfx_label;
        private PictureBox sfx_off;
        private Button audio_back_btn;
        private PictureBox music_on;
        private PictureBox sfx_on;
    }
}