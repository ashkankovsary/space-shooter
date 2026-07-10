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

            resume_btn.Click += resume_btn_Click;
            exit_btn.Click += exit_btn_Click;

            timer.Start();
        }

        protected override bool SyncsLocationWithParent => false;

        protected override void ApplyLayout() { }

        private void PlayForm_Shown(object sender, EventArgs e)
        {
            gameManager = new GameManager(ClientSize.Width, ClientSize.Height);
            hp_label.Location = new Point(ClientSize.Width - 390, 15);
            hpbar.Location = new Point(ClientSize.Width - 350, 20);
        }
        private void PlayForm_KeyDown(object sender, KeyEventArgs e)
        {
            float pcr = gameManager.player.CollisionRadius;
            if (e.KeyCode == Keys.Escape)
            {
                if (!gamePaused)
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
            hpbar.MaxHP = gameManager.player.MaxHP;
            hpbar.CurrentHP = gameManager.player.CurrentHP;

            int count = 0;
            /*powerup1.MaxHP = 300;
            powerup1.CurrentHP = gameManager.player.TripleShotTimer;
            if(powerup1.CurrentHP == 0) powerup1.Visible = false;
            if (!powerup1.Visible && gameManager.player.TripleShotTimer > 0)
                powerup1.Visible = true;*/

            foreach(PowerUpType put in gameManager.player.ActivePowerUps)
            {
                if(put is PowerUpType.Shield)
                {
                    if(count == 0)
                    {
                        powerup1.MaxHP = 150;
                        powerup1.CurrentHP = gameManager.player.ShieldTimer;
                    }
                    else if(count == 1)
                    {
                        powerup2.MaxHP = 150;
                        powerup2.CurrentHP = gameManager.player.ShieldTimer;
                    }
                    else if(count == 2)
                    {
                        powerup3.MaxHP = 150;
                        powerup3.CurrentHP = gameManager.player.ShieldTimer;
                    }
                }
                else if(put is PowerUpType.TripleShot)
                {
                    if (count == 0)
                    {
                        powerup1.MaxHP = 300;
                        powerup1.CurrentHP = gameManager.player.TripleShotTimer;
                    }
                    else if (count == 1)
                    {
                        powerup2.MaxHP = 300;
                        powerup2.CurrentHP = gameManager.player.TripleShotTimer;
                    }
                    else if (count == 2)
                    {
                        powerup3.MaxHP = 300;
                        powerup3.CurrentHP = gameManager.player.TripleShotTimer;
                    }
                }
                else if(put is PowerUpType.FireRateBooster)
                {
                    if (count == 0)
                    {
                        powerup1.MaxHP = 300;
                        powerup1.CurrentHP = gameManager.player.FireRateBoosterTimer;
                    }
                    else if (count == 1)
                    {
                        powerup2.MaxHP = 300;
                        powerup2.CurrentHP = gameManager.player.FireRateBoosterTimer;
                    }
                    else if (count == 2)
                    {
                        powerup3.MaxHP = 300;
                        powerup3.CurrentHP = gameManager.player.FireRateBoosterTimer;
                    }
                }
                count++;
            }
            if(count == 0)
            {
                powerup1.Visible = false;
                powerup2.Visible = false;
                powerup3.Visible = false;
            }
            else if (count == 1)
            {
                if(!powerup1.Visible)
                    powerup1.Visible = true;
                powerup2.Visible = false;
                powerup3.Visible = false;
            }
            else if (count == 2)
            {
                if(!powerup1.Visible)
                    powerup1.Visible = true;
                if (!powerup2.Visible)
                    powerup2.Visible = true;
                powerup3.Visible = false;
            }
            else if (count == 3)
            {
                if (!powerup1.Visible)
                    powerup1.Visible = true;
                if (!powerup2.Visible)
                    powerup2.Visible = true;
                if(!powerup3.Visible)
                    powerup3.Visible = true;
            }
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
        }
    }
}