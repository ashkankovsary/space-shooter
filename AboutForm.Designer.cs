namespace Space_Shooter_game
{
    partial class AboutForm
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
            backButton = new Button();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.Cursor = Cursors.Hand;
            backButton.Location = new Point(347, 42);
            backButton.Name = "backButton";
            backButton.Size = new Size(46, 29);
            backButton.TabIndex = 0;
            backButton.Text = "<-";
            backButton.UseVisualStyleBackColor = true;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 325);
            Controls.Add(backButton);
            Name = "AboutForm";
            Text = "AboutForm";
            ResumeLayout(false);
        }

        #endregion

        private Button backButton;
    }
}