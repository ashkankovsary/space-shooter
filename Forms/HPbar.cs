using System;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Shooter_game
{
    public class HPbar : Control
    {
        private int currentHP = 100;
        private int maxHP = 100;

        public int CurrentHP
        {
            get => currentHP;
            set
            {
                currentHP = Math.Max(0, Math.Min(value, maxHP));
                Invalidate();
            }
        }

        public int MaxHP
        {
            get => maxHP;
            set
            {
                maxHP = Math.Max(1, value);
                Invalidate();
            }
        }

        public HPbar()
        {
            DoubleBuffered = true;
            Width = 250;
            Height = 25;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color hpColor;
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.DarkGray, ClientRectangle);

            float percent = (float)CurrentHP / MaxHP;

            if (percent >= 0.65f) hpColor = Color.LimeGreen;
            else if (percent >= 0.30f) hpColor = Color.Gold;
            else hpColor = Color.Red;

            Rectangle fill = new Rectangle(0, 0, (int)(Width * percent), Height);

            using (SolidBrush brush = new SolidBrush(hpColor))
            {
                g.FillRectangle(brush, fill);
            }
            g.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
        }
    }
}