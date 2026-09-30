using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// A single rounded progress bar. The value is clamped by the setter so a
    /// caller can pass a raw ratio without risking a negative or over-full bar.
    /// </summary>
    public class ProgressTrack : Control
    {
        private decimal _value;
        private Color _fill = Colors.PrimaryOrange;
        private bool _completed;

        public ProgressTrack()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Size = new Size(240, 8);
        }

        /// <summary>Progress as a percentage, clamped to 0-100.</summary>
        [Category("Appearance")]
        [DefaultValue(0)]
        public decimal Value
        {
            get => _value;
            set
            {
                decimal clamped = value < 0m ? 0m : value > 100m ? 100m : value;
                if (_value == clamped)
                    return;

                _value = clamped;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color Fill
        {
            get => _fill;
            set
            {
                _fill = value;
                Invalidate();
            }
        }

        /// <summary>Switches the fill to the success colour once the goal is met.</summary>
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool Completed
        {
            get => _completed;
            set
            {
                _completed = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = Theme.ScaleOf(this);
            int radius = Math.Max(1, Height / 2);

            using (var track = new SolidBrush(Colors.ChartTrack))
            {
                g.FillPath(track, Theme.RoundedPath(new RectangleF(0, 0, Width, Height), radius));
            }

            // A completed goal fills the whole track, so the rounded caps never
            // collapse to a sliver at either end.
            int filled = (int)Math.Round(Width * (float)(_value / 100m));
            if (filled <= 0)
                return;

            if (filled < Height * 2)
                filled = Math.Min(Height * 2, Width);

            Color colour = _completed ? Colors.Success : _fill;
            using (var bar = new SolidBrush(colour))
            {
                g.FillPath(bar, Theme.RoundedPath(new RectangleF(0, 0, filled, Height), radius));
            }

            if (_completed)
            {
                using (var sheen = new SolidBrush(Color.FromArgb(40, 255, 255, 255)))
                {
                    g.FillPath(sheen, Theme.RoundedPath(
                        new RectangleF(scale, scale, Math.Max(0f, filled - scale * 2f), Math.Max(0f, Height - scale * 2f)),
                        Math.Max(1f, radius - scale)));
                }
            }
        }
    }
}
