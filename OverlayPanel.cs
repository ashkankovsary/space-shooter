using System.Drawing;
using System.Windows.Forms;

namespace Space_Shooter_game
{
    public class OverlayPanel : Panel
    {
        public OverlayPanel()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(170, 0, 0, 0)))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            base.OnPaint(e);
        }
    }
}