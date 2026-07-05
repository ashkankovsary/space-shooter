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

        private AboutForm aboutForm;
        private Point lastMenuLocation;
        private Point lastAboutLocation;
        private bool isSyncingLocation = false;

        public Form1()
        {
            InitializeComponent();
            this.Resize += (s, e) => UpdateLayout();
            this.ResizeEnd += (s, e) => UpdateLayout();
            this.Load += (s, e) => UpdateLayout();

            this.MinimumSize = new Size(1000, 600);

            about.Click += about_Click;
        }

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

            // اگه About بازه، وقتی منو Resize میشه دوباره وسط‌چین کن
            if (aboutForm != null && !aboutForm.IsDisposed)
            {
                isSyncingLocation = true;

                aboutForm.ApplySizeFromMenu(this.Size);
                CenterAboutOnMenu();
                lastMenuLocation = this.Location;
                lastAboutLocation = aboutForm.Location;

                isSyncingLocation = false;
            }
        }


        private void about_Click(object sender, EventArgs e)
        {
            if (aboutForm != null && !aboutForm.IsDisposed)
            {
                aboutForm.Focus();
                return;
            }

            aboutForm = new AboutForm();
            aboutForm.Owner = this;
            aboutForm.StartPosition = FormStartPosition.Manual;

            aboutForm.ApplySizeFromMenu(this.Size);
            CenterAboutOnMenu();

            lastMenuLocation = this.Location;
            lastAboutLocation = aboutForm.Location;

            // فقط کنترل‌های داخل منو غیرفعال بشن، نه خود پنجره
            // (پنجره همچنان قابل جابجاییه)
            SetChildControlsEnabled(this, false);

            this.LocationChanged += Menu_LocationChanged;
            aboutForm.LocationChanged += AboutForm_LocationChanged;

            aboutForm.FormClosed += (s, args) =>
            {
                this.LocationChanged -= Menu_LocationChanged;
                SetChildControlsEnabled(this, true);
                aboutForm = null;
            };
            aboutForm.Show(); // Show نه ShowDialog، تا خود پنجره منو فعال بمونه
        }

        private void CenterAboutOnMenu()
        {
            if (aboutForm == null) return;
            int x = this.Location.X + (this.Width - aboutForm.Width) / 2;
            int y = this.Location.Y + (this.Height - aboutForm.Height) / 2;
            aboutForm.Location = new Point(x, y);
        }

        private void SetChildControlsEnabled(Control parent, bool enabled)
        {
            foreach (Control c in parent.Controls)
            {
                c.Enabled = enabled;
            }
        }

        private void Menu_LocationChanged(object sender, EventArgs e)
        {
            if (isSyncingLocation || aboutForm == null || aboutForm.IsDisposed) return;

            isSyncingLocation = true;
            int dx = this.Location.X - lastMenuLocation.X;
            int dy = this.Location.Y - lastMenuLocation.Y;

            aboutForm.Location = new Point(aboutForm.Location.X + dx, aboutForm.Location.Y + dy);

            lastMenuLocation = this.Location;
            lastAboutLocation = aboutForm.Location;
            isSyncingLocation = false;
        }
        
        private void AboutForm_LocationChanged(object sender, EventArgs e)
        {
            if (isSyncingLocation || aboutForm == null) return;

            isSyncingLocation = true;
            int dx = aboutForm.Location.X - lastAboutLocation.X;
            int dy = aboutForm.Location.Y - lastAboutLocation.Y;

            this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);

            lastMenuLocation = this.Location;
            lastAboutLocation = aboutForm.Location;
            isSyncingLocation = false;
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}