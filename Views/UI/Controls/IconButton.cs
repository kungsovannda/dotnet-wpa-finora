using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// Small square owner-drawn icon button (card actions, dialog helpers).
    /// Presentation only - raises <see cref="Control.Click"/>.
    /// </summary>
    public class IconButton : Control
    {
        private string _icon = Icons.More;
        private int _iconSize = Theme.IconSize;
        private bool _hover;
        private bool _pressed;
        private bool _danger;
        private float _scale = 1f;

        public IconButton()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
            TabStop = false;
            Size = new Size(Theme.Scaled(28, 1f), Theme.Scaled(28, 1f));
        }

        [Category("Appearance")]
        [DefaultValue(Icons.More)]
        public string Icon
        {
            get => _icon;
            set
            {
                _icon = value ?? string.Empty;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(Theme.IconSize)]
        public int IconSize
        {
            get => _iconSize;
            set
            {
                _iconSize = value;
                Invalidate();
            }
        }

        /// <summary>When true the icon turns red on hover (destructive actions).</summary>
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool Danger
        {
            get => _danger;
            set
            {
                _danger = value;
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
            int radius = Theme.Scaled(Theme.RadiusSm, scale);
            var rect = new RectangleF(0, 0, Width, Height);

            Color fore = _danger && _hover ? Colors.Danger : Colors.MutedText;
            if (!Enabled)
                fore = Colors.FaintText;

            if (_hover && Enabled)
            {
                using var brush = new SolidBrush(_danger ? Colors.DangerSoft : Colors.SurfaceHover);
                using var path = Theme.RoundedPath(rect, radius);
                g.FillPath(brush, path);
            }
            else if (_pressed && Enabled)
            {
                using var brush = new SolidBrush(_danger ? Colors.DangerBorder : Colors.BorderSoft);
                using var path = Theme.RoundedPath(rect, radius);
                g.FillPath(brush, path);
            }

            int size = Theme.Scaled(_iconSize, scale);
            Icons.DrawCentered(g, _icon, size, rect, fore);
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
            _pressed = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Enabled)
            {
                _pressed = true;
                Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_pressed && Enabled && ClientRectangle.Contains(e.Location))
                OnClick(EventArgs.Empty);
            _pressed = false;
            Invalidate();
            base.OnMouseUp(e);
        }
    }
}
