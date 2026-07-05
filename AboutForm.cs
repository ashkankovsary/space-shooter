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
        public AboutForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;


            descriptionBox.BorderStyle = BorderStyle.None;
            descriptionBox.Cursor = Cursors.Default;
            descriptionBox.TabStop = false;
        }

        public void ApplySizeFromMenu(Size menuSize)
        {
            int height = (int)(menuSize.Height * 0.55f);
            int width = 400;

            this.Size = new Size(width, height);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
