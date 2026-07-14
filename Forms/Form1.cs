using System.Xml.Linq;
using System;
using System.Drawing;
using System.Windows.Forms;
using Space_Shooter_game.Forms;
using Space_Shooter_game.Config;

namespace Space_Shooter_game
{
    public partial class Form1 : ManagedForm
    {
        private int baseWidth = 800;
        private int baseHeight = 500;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            this.BackgroundImage = Properties.Resources.earth_view;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            int space = 20;
            int width_b = 600;
            int width_m = (width_b - space) / 2;
            int height = 70;
            int tx = 100;
            play.Height = height; play.Width = width_b;
            shop.Height = height; shop.Width = width_b;
            options.Height = height; options.Width = width_m;
            about.Height = height; about.Width = width_m;
            exit.Height = height; exit.Width = width_m;

            int sz = 50;
            title.Width = 200;
            title.Font = new Font(title.Font.FontFamily, sz, title.Font.Style);
            title.Location = new Point((int)((this.ClientSize.Width - title.Width) / 2), -100);
            play.Location = new Point((int)(this.ClientSize.Width - width_b) / 2, tx);
            shop.Location = new Point((int)(this.ClientSize.Width - width_b) / 2, tx + space + height);
            options.Location = new Point((int)(this.ClientSize.Width - width_b) / 2, tx + 2 * space + 2 * height);
            about.Location = new Point((int)(this.ClientSize.Width + space) / 2, tx + 2 * space + 2 * height);
            exit.Location = new Point((int)(this.ClientSize.Width - width_m) / 2, tx + 3 * space + 3 * height);


            about.Click += about_Click;
            play.Click += play_Click;
            play.Click += (s, e) => AudioManager.PlaySfx(Sounds.ClickButton);
            shop.Click += (s, e) => AudioManager.PlaySfx(Sounds.ClickButton);
            options.Click += (s, e) => AudioManager.PlaySfx(Sounds.ClickButton);
            about.Click += (s, e) => AudioManager.PlaySfx(Sounds.ClickButton);
            exit.Click += (s, e) => AudioManager.PlaySfx(Sounds.ClickButton);

            AudioManager.music = Database.IsMusicEnabled();
            AudioManager.sfx = Database.IsSfxEnabled();
        }

        protected override void ApplyLayout() { }
        private void UpdateLayout()
        {
            float heightRatio = (float)this.ClientSize.Height / baseHeight;
            float widthRatio = (float)this.ClientSize.Width / baseWidth;
            int tx = (int)(120 * heightRatio);
            int height = (int)(55 * heightRatio);
            int space_w = (int)(15 * widthRatio);
            int space_h = (int)(15 * heightRatio);
            int width_b = (int)(300 * widthRatio);
            int width_m = (width_b - space_w) / 2;
            play.Height = height; play.Width = width_b;
            shop.Height = height; shop.Width = width_b;
            options.Height = height; options.Width = width_m;
            about.Height = height; about.Width = width_m;
            exit.Height = height; exit.Width = width_m;

            play.Location = new Point((int)(this.ClientSize.Width - width_b) / 2, tx);
            shop.Location = new Point((int)(this.ClientSize.Width - width_b) / 2, tx + space_h + height);
            options.Location = new Point((int)(this.ClientSize.Width - width_b) / 2, tx + 2 * space_h + 2 * height);
            about.Location = new Point((int)(this.ClientSize.Width + space_w) / 2, tx + 2 * space_h + 2 * height);
            exit.Location = new Point((int)(this.ClientSize.Width - width_m) / 2, tx + 3 * space_h + 3 * height);

            int sz = (int)(10 * (heightRatio + (widthRatio * 0.5))) + 10;
            title.Height = (int)(62 * heightRatio);
            title.Width = (int)(335 * widthRatio);
            title.Font = new Font(title.Font.FontFamily, sz, title.Font.Style);
            title.Location = new Point((int)((this.ClientSize.Width - title.Width) / 2), 10);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Database.SetMusicEnabled(AudioManager.music);
            Database.SetSfxEnabled(AudioManager.sfx);
            this.Close();
        }
        private void about_Click(object sender, EventArgs e)
        {
            this.OpenChild(new AboutForm());
        }
        private void play_Click(object sender, EventArgs e)
        {
            this.Hide();

            PlayForm playForm = new PlayForm();
            playForm.FormClosed += (s, args) => this.Show();
            playForm.Show();
        }

        private void options_Click(object sender, EventArgs e)
        {
            this.Hide();

            OptionsForm optionsForm = new OptionsForm();
            optionsForm.FormClosed += (s, args) => this.Show();
            optionsForm.Show();
        }

        private void shop_Click(object sender, EventArgs e)
        {
            this.Hide();

            ShopForm shopForm = new ShopForm();
            shopForm.FormClosed += (s, args) => this.Show();
            shopForm.Show();
        }
    }
}