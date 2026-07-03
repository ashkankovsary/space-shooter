using System.Xml.Linq;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Shooter_game
{
    public partial class Form1 : Form
    {
        private int baseWidth = 800;
        private int baseHeight = 500;

        public Form1()
        {
            InitializeComponent();
            this.Resize += (s, e) => UpdateLayout();
            this.ResizeEnd += (s, e) => UpdateLayout();
            this.Load += (s, e) => UpdateLayout();

            this.MinimumSize = new Size(800, 500);
        }
        private void UpdateLayout()
        {
            float heightRatio = (float)this.ClientSize.Height / baseHeight;
            int tx = (int)(90 * heightRatio);
            int space = (int)(70 * heightRatio);
            play.Height = (int)(50 * heightRatio);
            play.Width = (int)(135 * heightRatio);
            shop.Height = (int)(50 * heightRatio);
            shop.Width = (int)(135 * heightRatio);
            options.Height = (int)(50 * heightRatio);
            options.Width = (int)(135 * heightRatio);
            about.Height = (int)(50 * heightRatio);
            about.Width = (int)(135 * heightRatio);
            exit.Height = (int)(50 * heightRatio);
            exit.Width = (int)(135 * heightRatio);

            play.Location = new Point((int)(this.ClientSize.Width - play.Width) / 2, tx);
            shop.Location = new Point((int)(this.ClientSize.Width - play.Width) / 2, tx + space);
            options.Location = new Point((int)(this.ClientSize.Width - play.Width) / 2, tx + 2 * space);
            about.Location = new Point((int)(this.ClientSize.Width - play.Width) / 2, tx + 3 * space);
            exit.Location = new Point((int)(this.ClientSize.Width - play.Width) / 2, tx + 4 * space);

            int sz = (int)(28 * heightRatio);
            title.Height = (int)(62 * heightRatio);
            title.Width = (int)(335 * heightRatio);
            title.Font = new Font(title.Font.FontFamily, sz, title.Font.Style);
            title.Location = new Point((int)((this.ClientSize.Width - title.Width) / 2), 10);
        }
    }
}
