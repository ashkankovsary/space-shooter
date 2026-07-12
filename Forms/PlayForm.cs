using System;
using System.Drawing;
using System.Windows.Forms;
using static Space_Shooter_game.GameSettings;

namespace Space_Shooter_game
{
    public partial class PlayForm : ManagedForm
    {
        bool gamePaused = false;
        GameManager gameManager;
        public PlayForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.KeyDown += PlayForm_KeyDown;
            this.KeyUp += PlayForm_KeyUp;
            this.Shown += PlayForm_Shown;
            this.FormClosed += (s, e) => AudioManager.StopMusic();

            resume_btn.Click += resume_btn_Click;
            exit_btn.Click += exit_btn_Click;
            resume_btn.Click += (s, e) => AudioManager.PlaySfx(Sounds.ClickButton);
            restart_btn.Click += (s, e) => AudioManager.PlaySfx(Sounds.ClickButton);
            exit_btn.Click += (s, e) => AudioManager.PlaySfx(Sounds.ClickButton);

            victory_restart_btn.Click += (s, e) => RestartGame();
            victory_restart_btn.Click += (s, e) => AudioManager.PlaySfx(Sounds.ClickButton);
            victory_menu_btn.Click += exit_btn_Click;
            victory_menu_btn.Click += (s, e) => AudioManager.PlaySfx(Sounds.ClickButton);

            timer.Start();
        }

        protected override bool SyncsLocationWithParent => false;

        protected override void ApplyLayout() { }

        private void RestartGame()
        {
            pause_panel.Visible = false;
            victory_panel.Visible = false;
            gamePaused = false;

            gameManager = new GameManager(ClientSize.Width, ClientSize.Height);
            AudioManager.PlayMusic(Sounds.MusicWave1To9);

            timer.Start();
        }

        private void PlayForm_Shown(object sender, EventArgs e)
        {
            gameManager = new GameManager(ClientSize.Width, ClientSize.Height);
            hp_label.Location = new Point(ClientSize.Width - 390, 15);
            hpbar.Location = new Point(ClientSize.Width - 350, 20);
            wave_label.Location = new Point((ClientSize.Width - wave_label.Width) / 2, 21);
            AudioManager.PlayMusic(Sounds.MusicWave1To9);
        }
        private void PlayForm_KeyDown(object sender, KeyEventArgs e)
        {
            float pcr = gameManager.player.CollisionRadius;
            if (e.KeyCode == Keys.Escape)
            {
                if (!gamePaused && !victory_panel.Visible)
                {
                    PauseGame();
                    timer.Stop();
                }
            }
            if (e.KeyCode == Keys.W) gameManager.player.MovingUp = true;
            if (e.KeyCode == Keys.S) gameManager.player.MovingDown = true;
            if (e.KeyCode == Keys.A) gameManager.player.MovingLeft = true;
            if (e.KeyCode == Keys.D) gameManager.player.MovingRight = true;
            if (e.KeyCode == Keys.Space) gameManager.player.Shooting = true;
        }

        private void PlayForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) gameManager.player.MovingUp = false;
            if (e.KeyCode == Keys.S) gameManager.player.MovingDown = false;
            if (e.KeyCode == Keys.A) gameManager.player.MovingLeft = false;
            if (e.KeyCode == Keys.D) gameManager.player.MovingRight = false;
            if (e.KeyCode == Keys.Space) gameManager.player.Shooting = false;
        }

        private void PauseGame()
        {
            gamePaused = true;
            pause_panel.Left = (this.ClientSize.Width - pause_panel.Width) / 2;
            pause_panel.Top = (this.ClientSize.Height - pause_panel.Height) / 2;
            pause_panel.Visible = true;
            pause_panel.BringToFront();
        }

        private void UpdateHUD()
        {
            score.Text = $"{gameManager.player.Score}";
            coin.Text = $"{gameManager.player.Coins}";
            hpbar.MaxHP = gameManager.player.MaxHP;
            hpbar.CurrentHP = gameManager.player.CurrentHP;
            wave_label.Text = $"Wave {gameManager.waveManager.CurrentWave}";
            wave_label.Location = new Point((ClientSize.Width - wave_label.Width) / 2, 21);

            bool showBanner = gameManager.waveManager.State == WaveState.ShowingBanner;
            wave_banner.Visible = showBanner;
            if (showBanner)
            {
                wave_banner.Text = gameManager.waveManager.BannerText;
                wave_banner.Location = new Point((ClientSize.Width - wave_banner.Width) / 2, (ClientSize.Height - wave_banner.Height) / 2);
            }
            int count = 0;

            foreach (PowerUpType put in gameManager.player.ActivePowerUps)
            {
                HPbar bar = count == 0 ? powerup1 : count == 1 ? powerup2 : count == 2 ? powerup3 : null;
                PictureBox icon = count == 0 ? powerup1_icon : count == 1 ? powerup2_icon : count == 2 ? powerup3_icon : null;
                if (bar == null) break;

                if (put == PowerUpType.Shield)
                {
                    bar.MaxHP = 150;
                    bar.CurrentHP = gameManager.player.ShieldTimer;
                    icon.Image = Properties.Resources.shield;
                }
                else if (put == PowerUpType.TripleShot)
                {
                    bar.MaxHP = 300;
                    bar.CurrentHP = gameManager.player.TripleShotTimer;
                    icon.Image = Properties.Resources.triple_shoot;
                }
                else if (put == PowerUpType.FireRateBooster)
                {
                    bar.MaxHP = 300;
                    bar.CurrentHP = gameManager.player.FireRateBoosterTimer;
                    icon.Image = Properties.Resources.fire_rate;
                }
                count++;
            }

            powerup1.Visible = powerup1_icon.Visible = count > 0;
            powerup2.Visible = powerup2_icon.Visible = count > 1;
            powerup3.Visible = powerup3_icon.Visible = count > 2;
        }

        private void ShowVictory()
        {
            timer.Stop();
            AudioManager.StopMusic();

            victory_score_label.Text = $"Score: {gameManager.player.Score}";
            victory_coins_label.Text = $"Coins: {gameManager.player.Coins}";
            victory_panel.Visible = true;
            victory_panel.BringToFront();
        }

        private void resume_btn_Click(object sender, EventArgs e)
        {
            pause_panel.Visible = false;
            gamePaused = false;
            timer.Start();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            gameManager.Draw(e.Graphics);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (gameManager.player.IsDead) this.Close();

            gameManager.Update();
            UpdateHUD();
            Invalidate();

            if (gameManager.waveManager.State == WaveState.Victory)
            {
                ShowVictory();
            }
        }
    }
}