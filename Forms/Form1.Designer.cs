namespace Space_Shooter_game
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            title = new Label();
            play = new Button();
            shop = new Button();
            options = new Button();
            about = new Button();
            exit = new Button();
            SuspendLayout();
            // 
            // title
            // 
            title.Anchor = AnchorStyles.None;
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            title.ForeColor = Color.LimeGreen;
            title.Location = new Point(220, 10);
            title.Margin = new Padding(0);
            title.Name = "title";
            title.Size = new Size(335, 62);
            title.TabIndex = 0;
            title.Text = "Space Shooter";
            title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // play
            // 
            play.Anchor = AnchorStyles.None;
            play.BackColor = Color.Crimson;
            play.Cursor = Cursors.Hand;
            play.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            play.Location = new Point(238, 128);
            play.Name = "play";
            play.Size = new Size(303, 50);
            play.TabIndex = 1;
            play.Text = "Play";
            play.UseVisualStyleBackColor = false;
            // 
            // shop
            // 
            shop.Anchor = AnchorStyles.None;
            shop.BackColor = Color.Crimson;
            shop.Cursor = Cursors.Hand;
            shop.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            shop.Location = new Point(238, 195);
            shop.Margin = new Padding(0);
            shop.Name = "shop";
            shop.Size = new Size(303, 50);
            shop.TabIndex = 2;
            shop.Text = "Shop";
            shop.UseVisualStyleBackColor = false;
            shop.Click += shop_Click;
            // 
            // options
            // 
            options.Anchor = AnchorStyles.None;
            options.BackColor = Color.Crimson;
            options.Cursor = Cursors.Hand;
            options.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            options.Location = new Point(238, 263);
            options.Margin = new Padding(0);
            options.Name = "options";
            options.Size = new Size(146, 50);
            options.TabIndex = 3;
            options.Text = "Options";
            options.UseVisualStyleBackColor = false;
            options.Click += options_Click;
            // 
            // about
            // 
            about.Anchor = AnchorStyles.None;
            about.BackColor = Color.Crimson;
            about.Cursor = Cursors.Hand;
            about.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            about.Location = new Point(400, 263);
            about.Margin = new Padding(0);
            about.Name = "about";
            about.Size = new Size(141, 50);
            about.TabIndex = 4;
            about.Text = "About";
            about.UseVisualStyleBackColor = false;
            // 
            // exit
            // 
            exit.Anchor = AnchorStyles.None;
            exit.BackColor = Color.Crimson;
            exit.Cursor = Cursors.Hand;
            exit.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exit.Location = new Point(320, 331);
            exit.Name = "exit";
            exit.Size = new Size(141, 50);
            exit.TabIndex = 5;
            exit.Text = "Exit";
            exit.UseVisualStyleBackColor = false;
            exit.Click += exit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Navy;
            ClientSize = new Size(800, 450);
            Controls.Add(exit);
            Controls.Add(about);
            Controls.Add(options);
            Controls.Add(shop);
            Controls.Add(play);
            Controls.Add(title);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private Button play;
        private Button shop;
        private Button options;
        private Button about;
        private Button exit;
    }
}
