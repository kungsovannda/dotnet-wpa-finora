using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>Round monogram avatar used in the header and profile areas.</summary>
    public class AvatarView : Control
    {
        private string _initials = "F";
        private float _scale = 1f;

        public AvatarView()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Font = Typography.CaptionMedium;
            Size = new Size(Theme.Scaled(32, 1f), Theme.Scaled(32, 1f));
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

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            var rect = new RectangleF(0, 0, Width, Height);
            float radius = Math.Min(rect.Width, rect.Height) / 2f;

            using (var path = Theme.RoundedPath(rect, radius))
            using (var brush = new LinearGradientBrush(rect, Fill2, Fill, LinearGradientMode.ForwardDiagonal))
            {
                g.FillPath(brush, path);
            }

            if (string.IsNullOrEmpty(_initials))
                return;

            var size = Theme.MeasureText(g, _initials, Font);
            var bounds = new RectangleF(0, (Height - size.Height) / 2f, Width, size.Height);
            Theme.DrawText(g, _initials, Font, bounds, Foreground, StringAlignment.Center);
        }
    }
}
