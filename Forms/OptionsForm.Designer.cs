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
            guide_panel.SuspendLayout();
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
            // 
            // guide_btn
            // 
            guide_btn.Anchor = AnchorStyles.None;
            guide_btn.BackColor = Color.DeepPink;
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
            guide_panel.Visible = false;
            guide_panel.BackgroundImage = (Image)resources.GetObject("guide_panel.BackgroundImage");
            guide_panel.BackgroundImageLayout = ImageLayout.Stretch;
            guide_panel.Controls.Add(back_guide_btn);
            guide_panel.Dock = DockStyle.Fill;
            guide_panel.Location = new Point(0, 0);
            guide_panel.Name = "guide_panel";
            guide_panel.Size = new Size(1221, 608);
            guide_panel.TabIndex = 3;
            // 
            // back_guide_btn
            // 
            back_guide_btn.BackColor = Color.DeepPink;
            back_guide_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            back_guide_btn.Location = new Point(12, 12);
            back_guide_btn.Name = "back_guide_btn";
            back_guide_btn.Size = new Size(74, 29);
            back_guide_btn.TabIndex = 0;
            back_guide_btn.Text = "<=";
            back_guide_btn.UseVisualStyleBackColor = false;
            back_guide_btn.Click += back_guide_btn_Click;
            // 
            // OptionsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1221, 608);
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
            ResumeLayout(false);
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
    }
}