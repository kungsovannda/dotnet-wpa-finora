using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// Small rounded pill with a leading dot - used for the
    /// Income / Expense indicator on cards and rows.
    /// </summary>
    public class TypeBadge : Control
    {
        private string _text = string.Empty;
        private Color _accent = Colors.SecondaryText;
        private Color _fill = Colors.SurfaceSunken;
        private float _scale = 1f;

        public TypeBadge()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Font = Typography.CaptionMedium;
            Cursor = Cursors.Hand;
            AutoSize = true;
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public new string Text
        {
            get => _text;
            set
            {
                _text = value ?? string.Empty;
                PerformLayout();
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color Accent
        {
            get => _accent;
            set
            {
                _accent = value;
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

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            PerformLayout();
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            int dot = Theme.Scaled(6, scale);
            int gap = Theme.Scaled(6, scale);
            int padding = Theme.Scaled(10, scale);
            int height = Theme.Scaled(22, scale);
            int textWidth = string.IsNullOrEmpty(_text)
                ? 0
                : TextRenderer.MeasureText(_text, Font, Size.Empty, TextFormatFlags.NoPadding).Width;

            return new Size(padding * 2 + dot + gap + textWidth, height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            var rect = new RectangleF(0, 0, Width, Height);

            using (var brush = new SolidBrush(_fill))
            using (var path = Theme.RoundedPath(rect, Height / 2f))
            {
                g.FillPath(brush, path);
            }

            int dot = Theme.Scaled(6, scale);
            int gap = Theme.Scaled(6, scale);
            int padding = Theme.Scaled(10, scale);
            float cy = rect.Height / 2f;

            Theme.FillCircle(g, padding + dot / 2f, cy, dot / 2f, _accent);

            if (string.IsNullOrEmpty(_text))
                return;

            TextRenderer.DrawText(g, _text, Font,
                new Rectangle(padding + dot + gap, 0, Math.Max(0, Width - padding * 2 - dot - gap), Height),
                _accent,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
        }
    }
}
