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
            score.Text = $"Score : {gameManager.player.Score}";
            hpbar.MaxHP = gameManager.player.MaxHP;
            hpbar.CurrentHP = gameManager.player.CurrentHP;
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