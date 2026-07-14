using NAudio.Wave;
using Space_Shooter_game.Config;
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
            AudioManager.music = Database.IsMusicEnabled();
            AudioManager.sfx = Database.IsSfxEnabled();
            if (AudioManager.music)
            {
                music_on.Visible = true;
                music_off.Visible = false;
            }
            else
            {
                music_on.Visible = false;
                music_off.Visible = true;
            }
            if (AudioManager.sfx)
            {
                sfx_on.Visible = true;
                sfx_off.Visible = false;
            }
            else
            {
                sfx_on.Visible = false;
                sfx_off.Visible = true;
            }
        }

        private void options_back_btn_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            Database.SetMusicEnabled(music_on.Visible);
            Database.SetSfxEnabled(sfx_on.Visible);
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
            AudioManager.music = false;
        }

        private void sfx_on_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            sfx_on.Visible = false;
            sfx_off.Visible = true;
            AudioManager.sfx = false;
        }

        private void music_off_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            music_on.Visible = true;
            music_off.Visible = false;
            AudioManager.music = true;
        }

        private void sfx_off_Click(object sender, EventArgs e)
        {
            AudioManager.PlaySfx(Sounds.ClickButton);
            sfx_on.Visible = true;
            sfx_off.Visible = false;
            AudioManager.sfx = true;
        }
    }
}
