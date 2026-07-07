using System;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Shooter_game
{
    public partial class PlayForm : ManagedForm
    {
        bool gamePaused = false;
        public PlayForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.KeyDown += PlayForm_KeyDown;

            resume_btn.Click += resume_btn_Click;
            exit_btn.Click += exit_btn_Click;
        }

        protected override bool SyncsLocationWithParent => false;

        protected override void ApplyLayout(){}

        private void PlayForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (!gamePaused)
                    PauseGame();
            }
        }

        private void PauseGame()
        {
            gamePaused = true;
            pause_panel.Left = (this.ClientSize.Width - pause_panel.Width) / 2;
            pause_panel.Top = (this.ClientSize.Height - pause_panel.Height) / 2;
            pause_panel.Visible = true;
            pause_panel.BringToFront();
        }

        private void resume_btn_Click(object sender, EventArgs e)
        {
            pause_panel.Visible = false;
            gamePaused = false;
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}