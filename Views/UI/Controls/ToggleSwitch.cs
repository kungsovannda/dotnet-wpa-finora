using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// Pill switch used by the settings rows. Follows the shared tokens: a
    /// sunken track, the Finora amber when on, and a white knob that slides
    /// between the ends. Click it or focus it and press Space.
    /// </summary>
    public class ToggleSwitch : Control
    {
        private bool _checked;
        private bool _hover;

        public ToggleSwitch()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.Selectable |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
            TabStop = true;
            Size = new Size(46, 28);
        }

        [Category("Data")]
        [DefaultValue(false)]
        public bool Checked
        {
            get => _checked;
            set
            {
                if (_checked == value)
                    return;

                _checked = value;
                Invalidate();
                OnCheckedChanged(EventArgs.Empty);
            }
        }

        /// <summary>Raised whenever <see cref="Checked"/> changes.</summary>
        public event EventHandler? CheckedChanged;

        protected virtual void OnCheckedChanged(EventArgs e) =>
            CheckedChanged?.Invoke(this, e);

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (Enabled)
                Checked = !Checked;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Enabled && e.KeyCode == Keys.Space && !e.Handled)
            {
                Checked = !Checked;
                e.Handled = true;
            }

            base.OnKeyDown(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _hover = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _hover = false;
            Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            // The 3px inset leaves room for the focus ring inside the control
            // bounds, so nothing is ever clipped by the parent.
            const float pad = 3f;
            var track = new RectangleF(
                pad, pad,
                Math.Max(0f, Width - pad * 2f),
                Math.Max(0f, Height - pad * 2f));

            if (track.Width <= 0f || track.Height <= 0f)
                return;

            float radius = Math.Min(track.Width, track.Height) / 2f;

            Color fill = !Enabled
                ? (_checked
                    ? Theme.Mix(Colors.PrimaryOrange, Colors.Surface, 0.55f)
                    : Colors.SurfaceSunken)
                : _checked
                    ? (_hover ? Colors.PrimaryHover : Colors.PrimaryOrange)
                    : (_hover ? Colors.BorderStrong : Colors.Border);

            using (var path = Theme.RoundedPath(track, radius))
            using (var brush = new SolidBrush(fill))
            {
                g.FillPath(brush, path);
            }

            // The "off" state needs its own edge on a white card.
            if (!_checked)
            {
                using var pen = new Pen(Colors.BorderStrong, 1f);
                using var path = Theme.RoundedPath(
                    new RectangleF(track.X + 0.5f, track.Y + 0.5f,
                                   track.Width - 1f, track.Height - 1f),
                    radius);
                g.DrawPath(pen, path);
            }

            float knobRadius = track.Height / 2f - 4f;
            float centerY = track.Y + track.Height / 2f;
            float centerX = _checked
                ? track.Right - 4f - knobRadius
                : track.Left + 4f + knobRadius;

            using (var shadow = new SolidBrush(Color.FromArgb(30, 24, 24, 27)))
            {
                g.FillEllipse(shadow, centerX - knobRadius, centerY - knobRadius + 1f,
                              knobRadius * 2f, knobRadius * 2f);
            }

            using (var knob = new SolidBrush(Colors.Surface))
            {
                g.FillEllipse(knob, centerX - knobRadius, centerY - knobRadius,
                              knobRadius * 2f, knobRadius * 2f);
            }

            if (Focused && Enabled)
            {
                using var pen = new Pen(Colors.PrimaryBorder, 1.6f);
                using var path = Theme.RoundedPath(
                    new RectangleF(1f, 1f, Width - 2f, Height - 2f), radius + pad);
                g.DrawPath(pen, path);
            }
        }
    }
}
