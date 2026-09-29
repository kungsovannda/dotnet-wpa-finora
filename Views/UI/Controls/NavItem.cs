using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// Sidebar navigation row: Lucide icon + label, soft hover state and an
    /// orange active state. Raises <see cref="Control.Click"/> only.
    /// </summary>
    public class NavItem : Control
    {
        private string _caption = string.Empty;
        private string _icon = Icons.Dashboard;
        private bool _selected;
        private bool _hover;
        private bool _pressed;
        private float _scale = 1f;

        public NavItem()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Font = Typography.Label;
            Cursor = Cursors.Hand;
            TabStop = true;
            Height = Theme.Scaled(40, 1f);
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value ?? string.Empty;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(Icons.Dashboard)]
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
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text
        {
            get => _caption;
            set => Caption = value;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            int radius = Theme.Scaled(Theme.RadiusMd, scale);
            int inset = Theme.Scaled(4, scale);
            var rect = new RectangleF(inset, Theme.Scaled(1, scale),
                                      Width - inset * 2f, Height - Theme.Scaled(2, scale));

            Color iconColor = _selected ? Colors.PrimaryOrange : Colors.MutedText;
            Color textColor = _selected ? Colors.Foreground : Colors.SecondaryText;

            if (_selected)
            {
                using var brush = new SolidBrush(Colors.PrimarySoft);
                using var path = Theme.RoundedPath(rect, radius);
                g.FillPath(brush, path);

                // Slim active indicator on the leading edge
                int barHeight = (int)Math.Round(rect.Height * 0.42f);
                var bar = new RectangleF(rect.X + Theme.Scaled(1, scale),
                                         rect.Y + (rect.Height - barHeight) / 2f,
                                         Theme.Scaled(3, scale), barHeight);
                using var barBrush = new SolidBrush(Colors.PrimaryOrange);
                using var barPath = Theme.RoundedPath(bar, Theme.Scaled(2, scale));
                g.FillPath(barBrush, barPath);
            }
            else if (_hover)
            {
                using var brush = new SolidBrush(Colors.SurfaceHover);
                using var path = Theme.RoundedPath(rect, radius);
                g.FillPath(brush, path);
                iconColor = Colors.SecondaryText;
            }

            int iconSize = Theme.Scaled(Theme.IconSize, scale);
            float iconX = rect.X + Theme.Scaled(12, scale);
            float cy = rect.Y + rect.Height / 2f;

            Icons.Draw(g, _icon, iconSize, new RectangleF(iconX, cy - iconSize / 2f, iconSize, iconSize), iconColor);
            float textX = iconX + iconSize + Theme.Scaled(10, scale);
            var textBounds = new RectangleF(textX, rect.Y, Math.Max(0, rect.Right - textX - Theme.Scaled(10, scale)), rect.Height);
            TextRenderer.DrawText(g, _caption, Font, Rectangle.Round(textBounds), textColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix |
                TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine);
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
            if (e.Button == MouseButtons.Left)
            {
                _pressed = true;
                Focus();
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

        protected override void OnGotFocus(EventArgs e)
        {
            Invalidate();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            Invalidate();
            base.OnLostFocus(e);
        }

        protected override bool IsInputKey(Keys keyData) =>
            keyData == Keys.Space || keyData == Keys.Enter || base.IsInputKey(keyData);

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                if (Enabled)
                    OnClick(EventArgs.Empty);
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            base.OnKeyDown(e);
        }
    }
}
