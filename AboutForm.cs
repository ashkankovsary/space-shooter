using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace Space_Shooter_game
{
    public partial class AboutForm : Form
    {
        private int baseWidth = 500;
        private int baseHeight = 350;

        public AboutForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public void ApplySizeFromMenu(Size menuSize)
        {
            int width = 200;
            int height = (int)(menuSize.Height * 0.55f);

            this.Size = new Size(width, height);
            UpdateLayout();
        }

        private void UpdateLayout()
        {
            float heightRatio = (float)this.ClientSize.Height / baseHeight;

            backButton.Width = 50;
            backButton.Height = (int)(45 * heightRatio);
            backButton.Location = new Point(
                (this.ClientSize.Width - backButton.Width) / 2,
                this.ClientSize.Height - backButton.Height - (int)(20 * heightRatio)
            );
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
