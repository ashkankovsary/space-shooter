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
        private void audio_btn_Click(object sendr, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            audio_panel.Visible = true;
        }
        private void back_guide_btn_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            guide_panel.Visible = false;
        }

        private void audio_back_btn_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            audio_panel.Visible = false;
        }

        private void music_on_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            music_on.Visible = false;
            music_off.Visible = true;
        }

        private void sfx_on_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            sfx_on.Visible = false;
            sfx_off.Visible = true;
        }

        private void music_off_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            music_on.Visible = true;
            music_off.Visible = false;
        }

        private void sfx_off_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            sfx_on.Visible = true;
            sfx_off.Visible = false;
        }
    }
}
