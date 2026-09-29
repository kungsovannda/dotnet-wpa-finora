using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// Round monogram avatar used in the header and profile areas. The control
    /// pins itself to a square so the circle always fills it edge to edge -
    /// a non-square box would leave a bare band that reads as a stray border.
    /// </summary>
    public class AvatarView : Control
    {
        private string _initials = "F";
        private float _scale = 1f;
        private int _diameter = 34;

        public AvatarView()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Font = Typography.CaptionMedium;
            ApplyDiameter();
        }

        /// <summary>Edge length of the circle, in design pixels.</summary>
        [Category("Appearance")]
        [DefaultValue(34)]
        public int Diameter
        {
            get => _diameter;
            set
            {
                _diameter = Math.Max(8, value);
                ApplyDiameter();
                Invalidate();
            }
        }

        /// <summary>
        /// Pins the control to a square and refuses to be resized. Telling the
        /// layout engine the allowed range is what stops a parent from handing
        /// us a stretched rectangle in the first place.
        /// </summary>
        private void ApplyDiameter()
        {
            if (IsDisposed)
                return;

            int side = Theme.Scaled(_diameter, _scale <= 0 ? 1f : _scale);
            if (side <= 0)
                return;

            MinimumSize = new Size(side, side);
            MaximumSize = new Size(side, side);
            if (Width != side || Height != side)
                Size = new Size(side, side);
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            int side = Theme.Scaled(_diameter, scale);
            return new Size(side, side);
        }

        [Category("Appearance")]
        [DefaultValue("F")]
        public string Initials
        {
            get => _initials;
            set
            {
                _initials = value ?? string.Empty;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color Fill
        {
            get; set;
        } = Colors.PrimarySoft;

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color Fill2
        {
            get; set;
        } = Colors.PrimaryHover;

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color Foreground
        {
            get; set;
        } = Colors.OnPrimary;

        /// <summary>
        /// Keeps the control square whatever size the layout hands it. A circle
        /// drawn into a non-square box leaves an empty band beside it, which is
        /// what made the profile look like it had a border around it.
        /// </summary>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            int side = Math.Min(Width, Height);
            if (side > 0 && (Width != side || Height != side))
            {
                MinimumSize = Size.Empty;
                MaximumSize = Size.Empty;
                Size = new Size(side, side);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
            ApplyDiameter();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            // The largest circle that fits, centred in the control. OnSizeChanged
            // already forces a square, but staying defensive here means a host
            // that fights the resize still gets a centred round shape.
            float diameter = Math.Min(Width, Height);
            var circle = new RectangleF(
                (Width - diameter) / 2f,
                (Height - diameter) / 2f,
                diameter,
                diameter);

            using (var path = Theme.RoundedPath(circle, diameter / 2f))
            using (var brush = new LinearGradientBrush(circle, Fill2, Fill, LinearGradientMode.ForwardDiagonal))
            {
                g.FillPath(brush, path);
            }

            if (string.IsNullOrEmpty(_initials))
                return;

            var size = Theme.MeasureText(g, _initials, Font);
            var bounds = new RectangleF(
                circle.X,
                circle.Y + (circle.Height - size.Height) / 2f,
                circle.Width,
                size.Height);
            Theme.DrawText(g, _initials, Font, bounds, Foreground, StringAlignment.Center);
        }
    }
}
