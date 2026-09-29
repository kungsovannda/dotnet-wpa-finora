using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>A single selectable emoji cell used inside the picker.</summary>
    public class EmojiChip : Control
    {
        private string _glyph = string.Empty;
        private float _scale = 1f;
        private bool _hover;
        private bool _selected;

        public EmojiChip()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
            Size = new Size(Theme.Scaled(38, 1f), Theme.Scaled(38, 1f));
            Margin = Padding.Empty;
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string Glyph
        {
            get => _glyph;
            set
            {
                _glyph = value ?? string.Empty;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(false)]
        public bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                Invalidate();
            }
        }

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
            var rect = new RectangleF(1f, 1f, Width - 2f, Height - 2f);
            int radius = Theme.Scaled(Theme.RadiusSm, scale);

            if (_selected)
            {
                using var selectedBrush = new SolidBrush(Colors.PrimarySoft);
                using var selectedPath = Theme.RoundedPath(rect, radius);
                g.FillPath(selectedBrush, selectedPath);

                using var pen = new Pen(Colors.PrimaryBorder, scale);
                using var borderPath = Theme.RoundedPath(rect, radius);
                g.DrawPath(pen, borderPath);
            }
            else if (_hover)
            {
                using var brush = new SolidBrush(Colors.SurfaceHover);
                using var path = Theme.RoundedPath(rect, radius);
                g.FillPath(brush, path);
            }

            if (string.IsNullOrEmpty(_glyph))
                return;

            int pixels = Theme.Scaled(22, scale);
            EmojiRenderer.Draw(g, _glyph, pixels, new RectangleF(0f, 0f, Width, Height));
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _hover = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _hover = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ClientRectangle.Contains(e.Location))
                OnClick(EventArgs.Empty);
            base.OnMouseUp(e);
        }
    }
}
