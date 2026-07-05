using System;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Shooter_game
{
    public abstract class ManagedForm : Form
    {
        public ManagedForm ParentManagedForm { get; private set; }
        public ManagedForm ActiveChild { get; private set; }
        private Point _lastLocation;

        protected ManagedForm()
        {
            this.FormClosed += ManagedForm_FormClosed;
        }
        protected abstract void ApplyInitialLayout();
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

            child.ApplyInitialLayout();
            CenterOnParent(child);

            ActiveChild = child;
            SetChildControlsEnabled(this, false);

            if (child.SyncsLocationWithParent)
            {
                _lastLocation = this.Location;
                child._lastLocation = child.Location;
                this.LocationChanged += HandleParentMoved;
                child.LocationChanged += child.HandleChildMoved;
            }

            child.Show();
        }

        private void CenterOnParent(ManagedForm child)
        {
            int x = this.Location.X + (this.Width - child.Width) / 2;
            int y = this.Location.Y + (this.Height - child.Height) / 2;
            child.Location = new Point(x, y);
        }

        // Runs on the PARENT when the parent's window moves: shifts the child by the same delta.
        private void HandleParentMoved(object sender, EventArgs e)
        {
            if (ActiveChild == null || ActiveChild.IsDisposed) return;

            int dx = this.Location.X - _lastLocation.X;
            int dy = this.Location.Y - _lastLocation.Y;
            if (dx == 0 && dy == 0) return;

            ActiveChild.LocationChanged -= ActiveChild.HandleChildMoved; // avoid reentrancy
            ActiveChild.Location = new Point(ActiveChild.Location.X + dx, ActiveChild.Location.Y + dy);
            ActiveChild.LocationChanged += ActiveChild.HandleChildMoved;

            _lastLocation = this.Location;
            ActiveChild._lastLocation = ActiveChild.Location;
        }

        // Runs on the CHILD when the child's window moves: shifts the parent by the same delta.
        private void HandleChildMoved(object sender, EventArgs e)
        {
            if (ParentManagedForm == null) return;

            int dx = this.Location.X - _lastLocation.X;
            int dy = this.Location.Y - _lastLocation.Y;
            if (dx == 0 && dy == 0) return;

            ParentManagedForm.LocationChanged -= ParentManagedForm.HandleParentMoved; // avoid reentrancy
            ParentManagedForm.Location = new Point(ParentManagedForm.Location.X + dx, ParentManagedForm.Location.Y + dy);
            ParentManagedForm.LocationChanged += ParentManagedForm.HandleParentMoved;

            _lastLocation = this.Location;
            ParentManagedForm._lastLocation = ParentManagedForm.Location;
        }

        private void SetChildControlsEnabled(Control target, bool enabled)
        {
            foreach (Control c in target.Controls)
                c.Enabled = enabled;
        }

        // When THIS form closes: close its own active child first (cascade),
        // then re-enable the parent's controls (if it has a parent).
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
                    this.LocationChanged -= this.HandleChildMoved;
                }

                ParentManagedForm.SetChildControlsEnabled(ParentManagedForm, true);
                ParentManagedForm.ActiveChild = null;
            }
        }
    }
}