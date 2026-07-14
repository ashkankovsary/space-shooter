using System;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Shooter_game
{
    public class ManagedForm : Form
    {
        public ManagedForm ParentManagedForm { get; private set; }
        public ManagedForm ActiveChild { get; private set; }

        private Point _lastLocation;

        protected ManagedForm()
        {
            this.FormClosed += ManagedForm_FormClosed;
        }
        protected virtual void ApplyLayout() { }
        protected virtual bool SyncsLocationWithParent => true;
        public void OpenChild(ManagedForm child)
        {
            if (ActiveChild != null && !ActiveChild.IsDisposed)
            {
                ActiveChild.Focus();
                return;
            }

            child.ParentManagedForm = this;
            child.Owner = this;
            child.StartPosition = FormStartPosition.Manual;

            child.ApplyLayout();
            CenterOnParent(child);

            ActiveChild = child;
            SetChildControlsEnabled(this, false);

            if (child.SyncsLocationWithParent)
            {
                _lastLocation = this.Location;
                child._lastLocation = child.Location;
                this.LocationChanged += HandleParentMoved;
                child.LocationChanged += child.HandleChildMoved;
                this.Resize += this.HandleParentResized;
            }

            this.Hide();
            child.Show();
        }

        private void CenterOnParent(ManagedForm child)
        {
            int x = this.Location.X; // + (this.Width - child.Width) / 2;
            int y = this.Location.Y; // + (this.Height - child.Height) / 2;
            child.Location = new Point(x, y);
        }

        private void HandleParentMoved(object sender, EventArgs e)
        {
            if (ActiveChild == null || ActiveChild.IsDisposed) return;

            int dx = this.Location.X - _lastLocation.X;
            int dy = this.Location.Y - _lastLocation.Y;
            if (dx == 0 && dy == 0) return;

            ActiveChild.LocationChanged -= ActiveChild.HandleChildMoved;
            ActiveChild.Location = new Point(ActiveChild.Location.X + dx, ActiveChild.Location.Y + dy);
            ActiveChild.LocationChanged += ActiveChild.HandleChildMoved;

            _lastLocation = this.Location;
            ActiveChild._lastLocation = ActiveChild.Location;
        }

        private void HandleChildMoved(object sender, EventArgs e)
        {
            if (ParentManagedForm == null) return;

            int dx = this.Location.X - _lastLocation.X;
            int dy = this.Location.Y - _lastLocation.Y;
            if (dx == 0 && dy == 0) return;

            ParentManagedForm.LocationChanged -= ParentManagedForm.HandleParentMoved;
            ParentManagedForm.Location = new Point(ParentManagedForm.Location.X + dx, ParentManagedForm.Location.Y + dy);
            ParentManagedForm.LocationChanged += ParentManagedForm.HandleParentMoved;

            _lastLocation = this.Location;
            ParentManagedForm._lastLocation = ParentManagedForm.Location;
        }

        // Runs on the PARENT when the parent resizes: re-run the child's own
        // layout logic, then recenter it — without letting that programmatic
        // move trigger the child's own "user dragged me" handler.
        private void HandleParentResized(object sender, EventArgs e)
        {
            if (ActiveChild == null || ActiveChild.IsDisposed) return;
            ActiveChild.ApplyLayout();

            if (ActiveChild.SyncsLocationWithParent)
                ActiveChild.LocationChanged -= ActiveChild.HandleChildMoved;
            
            CenterOnParent(ActiveChild);

            if (ActiveChild.SyncsLocationWithParent)
            {
                ActiveChild._lastLocation = ActiveChild.Location;
                ActiveChild.LocationChanged += ActiveChild.HandleChildMoved;
            }

            _lastLocation = this.Location;
        }
        private void SetChildControlsEnabled(Control target, bool enabled)
        {
            foreach (Control c in target.Controls)
                c.Enabled = enabled;
        }
        // ManagedForm .cs
        private void ManagedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ActiveChild != null && !ActiveChild.IsDisposed)
            {
                ActiveChild.Close();
            }

            if (ParentManagedForm != null)
            {
                if (SyncsLocationWithParent)
                {
                    ParentManagedForm.LocationChanged -= ParentManagedForm.HandleParentMoved;
                    ParentManagedForm.Resize -= ParentManagedForm.HandleParentResized;
                    this.LocationChanged -= this.HandleChildMoved;
                }

                ParentManagedForm.SetChildControlsEnabled(ParentManagedForm, true);
                ParentManagedForm.ActiveChild = null;
                ParentManagedForm.Show();
            }
        }
    }
}