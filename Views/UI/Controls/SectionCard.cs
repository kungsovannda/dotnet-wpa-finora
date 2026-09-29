using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// Layered surface used for every "card" in the app: white fill, 12px
    /// radius, hairline border and a very soft shadow. It is a pure container -
    /// it holds whatever content control is assigned to <see cref="Content"/>.
    /// </summary>
    public class SectionCard : UserControl
    {
        private Control? _content;
        private float _scale = 1f;
        private bool _hovered;
        private bool _interactive;

        public SectionCard()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);

            BackColor = Colors.Background;
            Padding = new Padding(Theme.Space5, Theme.Space4, Theme.Space5, Theme.Space4);
        }

        [Category("Appearance")]
        [DefaultValue(Theme.RadiusLg)]
        public int Radius { get; set; } = Theme.RadiusLg;

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color Surface { get; set; } = Colors.Surface;

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color Border { get; set; } = Colors.Border;

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowShadow { get; set; } = true;

        /// <summary>Optional lift on hover (used by clickable cards).</summary>
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool Interactive
        {
            get => _interactive;
            set
            {
                _interactive = value;
                if (value)
                {
                    Cursor = Cursors.Hand;
                    MouseEnter += (_, _) => { _hovered = true; Invalidate(); };
                    MouseLeave += (_, _) => { _hovered = false; Invalidate(); };
                }
            }
        }

        /// <summary>Child control that fills the padded content area.</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control? Content
        {
            get => _content;
            set
            {
                if (_content != null)
                {
                    Controls.Remove(_content);
                    _content.Dispose();
                    _content = null;
                }

                _content = value;
                if (value != null)
                {
                    value.Dock = DockStyle.Fill;
                    value.Margin = Padding.Empty;
                    Controls.Add(value);
                }

                PerformLayout();
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ApplyRegion();
        }

        /// <summary>
        /// Clips the card (and every child) to its rounded outline so hosting a
        /// grid or a panel inside it never shows square corners.
        /// </summary>
        private void ApplyRegion()
        {
            if (Width <= 0 || Height <= 0)
                return;

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            using var path = Theme.RoundedPath(
                new RectangleF(0, 0, Width, Height),
                Theme.Scaled(Radius, scale) + 1f);
            var region = new Region(path);
            var previous = Region;
            Region = region;
            previous?.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            float offset = _interactive && _hovered ? -1f * scale : 0f;
            float radius = Theme.Scaled(Radius, scale);
            var rect = new RectangleF(0.5f, offset + 0.5f, Width - 1f, Height - 1f);

            Color border = _interactive && _hovered
                ? Theme.Mix(Border, Colors.PrimaryOrange, 0.55f)
                : Border;

            // Soft interior lift (kept inside the clipped region).
            if (ShowShadow)
            {
                using var shadow = new SolidBrush(Color.FromArgb(8, 24, 24, 27));
                using var shadowPath = Theme.RoundedPath(
                    new RectangleF(rect.X, rect.Y + 1f, rect.Width, rect.Height + 1f), radius);
                g.FillPath(shadow, shadowPath);
            }

            using (var fillBrush = new SolidBrush(Surface))
            using (var path = Theme.RoundedPath(rect, radius))
            {
                g.FillPath(fillBrush, path);
            }

            using var pen = new Pen(border, scale);
            using var borderPath = Theme.RoundedPath(rect, radius);
            g.DrawPath(pen, borderPath);
        }
    }
}
