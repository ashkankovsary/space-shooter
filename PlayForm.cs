using System;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Shooter_game
{
    public partial class PlayForm : ManagedForm
    {
        public PlayForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        protected override bool SyncsLocationWithParent => false;

        protected override void ApplyLayout(){}
    }
}