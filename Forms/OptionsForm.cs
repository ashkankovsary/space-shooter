using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Space_Shooter_game.Forms
{
    public partial class OptionsForm : ManagedForm
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void options_back_btn_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            this.Close();
        }
        private void guide_btn_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            guide_panel.Visible = true;
        }
        private void back_guide_btn_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            guide_panel.Visible = false;
        }
    }
}
