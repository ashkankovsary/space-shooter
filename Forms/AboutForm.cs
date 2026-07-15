using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace Space_Shooter_game
{
    public partial class AboutForm : ManagedForm
    {
        public AboutForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            backButton.Click += (s, e) => AudioManager.PlaySfx(Sounds.ClickButton);

            descriptionBox.BorderStyle = BorderStyle.None;
            descriptionBox.Cursor = Cursors.Default;
            descriptionBox.TabStop = false;
        }

        protected override bool SyncsLocationWithParent => false;
        protected override void ApplyLayout() { }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
