using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    public enum AppButtonVariant
    {
        Primary,
        Secondary,
        Ghost,
        Danger
    }

    /// <summary>
    /// Owner-drawn application button: rounded 8px surface, subtle shadow,
    /// hover / pressed / focus states and an optional Lucide icon.
    /// Purely presentational - it only raises <see cref="Control.Click"/>.
    /// </summary>
    public class AppButton : Control
    {
        private string _text = string.Empty;
        private string _icon = string.Empty;
        private AppButtonVariant _variant = AppButtonVariant.Primary;
        private bool _autoWidth = true;
        private bool _hover;
        private bool _pressed;
        private bool _focused;
        private int _iconSize = Theme.IconSize;
        private float _scale = 1f;

        public AppButton()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.Selectable, true);

            BackColor = Color.Transparent;
            ForeColor = Colors.Foreground;
            Font = Typography.Button;
            Cursor = Cursors.Hand;
            TabStop = true;
            Size = new Size(Theme.Scaled(120, 1f), Theme.Scaled(Theme.ButtonHeight, 1f));
        }

        [Category("Appearance")]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Caption
        {
            get => _text;
            set
            {
                _text = value ?? string.Empty;
                UpdateAutoWidth();
                Invalidate();
            }
        }

        [Browsable(false)]
        [DefaultValue("")]
        public new string Text
        {
            get => _text;
            set => Caption = value;
        }

        [Category("Appearance")]
        [DefaultValue(AppButtonVariant.Primary)]
        public AppButtonVariant Variant
        {
            get => _variant;
            set
            {
                _variant = value;
                ApplyVariantColors();
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string Icon
        {
            get => _icon;
            set
            {
                _icon = value ?? string.Empty;
                UpdateAutoWidth();
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
                UpdateAutoWidth();
                Invalidate();
            }
        }

        [Category("Layout")]
        [DefaultValue(true)]
        public bool AutoWidth
        {
            get => _autoWidth;
            set
            {
                _autoWidth = value;
                UpdateAutoWidth();
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
            UpdateAutoWidth();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            UpdateAutoWidth();
        }

        private void ApplyVariantColors()
        {
            switch (_variant)
            {
                case AppButtonVariant.Primary:
                    ForeColor = Colors.OnPrimary;
                    break;
                case AppButtonVariant.Danger:
                    ForeColor = Colors.OnPrimary;
                    break;
                case AppButtonVariant.Secondary:
                    ForeColor = Colors.Foreground;
                    break;
                default:
                    ForeColor = Colors.SecondaryText;
                    break;
            }
        }

        /// <summary>
        /// Width the caption and icon need, including the variant's side
        /// padding. This is the floor for the button: no layout is allowed to
        /// squeeze it narrower, otherwise the caption gets ellipsised.
        /// </summary>
        private int ContentWidth()
        {
            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            int horizontal = Theme.Scaled(_variant == AppButtonVariant.Ghost ? 10 : 16, scale);
            int icon = string.IsNullOrEmpty(_icon)
                ? 0
                : Theme.Scaled(_iconSize, scale) + Theme.Scaled(8, scale);
            return horizontal * 2 + icon + TextWidth();
        }

        /// <summary>
        /// Tight width of the caption. Must match the flags <see cref="DrawContent"/>
        /// draws with, otherwise the text is either clipped or loosely spaced.
        /// </summary>
        private int TextWidth() => string.IsNullOrEmpty(_text)
            ? 0
            : TextRenderer.MeasureText(_text, Font, Size.Empty, TextFormatFlags.NoPadding).Width;

        private void UpdateAutoWidth()
        {
            if (IsDisposed)
                return;

            int width = ContentWidth();
            if (width <= 0)
                return;

            bool changed = false;

            // Never let a parent shrink the button below its own content, which
            // is what produced "Add Trans..." instead of "Add Transaction".
            if (width > MinimumSize.Width)
            {
                MinimumSize = new Size(width, MinimumSize.Height);
                changed = true;
            }

            if (_autoWidth && Math.Abs(Width - width) > 1)
            {
                Width = width;
                changed = true;
            }

            // A TableLayoutPanel caches its column widths, so a button that
            // grows after the parent was laid out needs the parent to re-measure.
            if (changed && Parent is not null)
                Parent.PerformLayout();
        }

        /// <summary>
        /// Advertises the caption-driven width so TableLayoutPanel, FlowLayoutPanel
        /// and AutoSize hosts size the button from its content instead of
        /// squeezing it into whatever the column happens to be.
        /// </summary>
        public override Size GetPreferredSize(Size proposedSize)
        {
            Size baseSize = base.GetPreferredSize(proposedSize);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            int width = ContentWidth();
            int height = baseSize.Height > 0
                ? baseSize.Height
                : Theme.Scaled(Theme.ButtonHeight, scale);

            if (!_autoWidth)
                width = Math.Max(baseSize.Width, width);

            return new Size(width, height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            int radius = Theme.Scaled(Theme.RadiusMd, scale);
            int inset = _variant == AppButtonVariant.Primary || _variant == AppButtonVariant.Danger
                ? Theme.Scaled(0, scale)
                : Theme.Scaled(1, scale);
            var rect = new RectangleF(inset, inset, Width - inset * 2f, Height - inset * 2f);
            if (rect.Width <= 0 || rect.Height <= 0)
                return;

            if (!Enabled)
            {
                DrawBackground(g, rect, radius, scale, disabled: true);
                DrawContent(g, rect, scale, Colors.FaintText);
                return;
            }

            DrawBackground(g, rect, radius, scale, disabled: false);
            DrawContent(g, rect, scale, ForeColor);

            if (_focused && Focused)
            {
                using var pen = new Pen(Theme.WithAlpha(Colors.PrimaryOrange, 90), 2f);
                using var path = Theme.RoundedPath(
                    new RectangleF(rect.X + 1f, rect.Y + 1f, rect.Width - 2f, rect.Height - 2f), radius);
                g.DrawPath(pen, path);
            }
        }

        private void DrawBackground(Graphics g, RectangleF rect, int radius, float scale, bool disabled)
        {
            Color fill;
            Color? border = null;
            bool shadow = false;

            switch (_variant)
            {
                case AppButtonVariant.Primary:
                    fill = disabled
                        ? Color.FromArgb(200, 245, 158, 11)
                        : _pressed ? Colors.PrimaryPressed
                        : _hover ? Colors.PrimaryHover
                        : Colors.PrimaryOrange;
                    shadow = !disabled;
                    break;

                case AppButtonVariant.Danger:
                    fill = disabled
                        ? Color.FromArgb(200, 220, 38, 38)
                        : _pressed ? Color.FromArgb(185, 28, 28)
                        : _hover ? Color.FromArgb(190, 38, 38)
                        : Colors.Danger;
                    shadow = !disabled;
                    break;

                case AppButtonVariant.Secondary:
                    fill = _hover && !disabled ? Colors.SurfaceHover : Colors.Surface;
                    border = Colors.Border;
                    break;

                default: // Ghost
                    fill = _hover && !disabled ? Colors.SurfaceHover : Color.Transparent;
                    break;
            }

            if (shadow)
            {
                using var shadowBrush = new SolidBrush(Color.FromArgb(_pressed ? 10 : 22, 24, 24, 27));
                using var shadowPath = Theme.RoundedPath(
                    new RectangleF(rect.X, rect.Y + Theme.Scaled(1, scale), rect.Width, rect.Height), radius);
                g.FillPath(shadowBrush, shadowPath);
            }

            if (fill.A > 0)
            {
                using var fillBrush = new SolidBrush(fill);
                using var path = Theme.RoundedPath(rect, radius);
                g.FillPath(fillBrush, path);
            }

            if (border.HasValue)
            {
                using var pen = new Pen(border.Value, Theme.Scaled(1, scale));
                using var path = Theme.RoundedPath(
                    new RectangleF(rect.X + 0.5f * scale, rect.Y + 0.5f * scale,
                                   rect.Width - scale, rect.Height - scale),
                    radius - 0.5f * scale);
                g.DrawPath(pen, path);
            }
        }

        private void DrawContent(Graphics g, RectangleF rect, float scale, Color foreColor)
        {
            bool hasIcon = !string.IsNullOrEmpty(_icon);
            int iconSize = Theme.Scaled(_iconSize, scale);
            int gap = hasIcon ? Theme.Scaled(8, scale) : 0;
            int textWidth = TextWidth();

            int contentWidth = (hasIcon ? iconSize + gap : 0) + textWidth;
            float x = rect.X + (rect.Width - contentWidth) / 2f;
            float cy = rect.Top + rect.Height / 2f;

            if (hasIcon)
            {
                Icons.Draw(g, _icon, iconSize, new RectangleF(x, cy - iconSize / 2f, iconSize, iconSize), foreColor);
                x += iconSize + gap;
            }

            if (textWidth > 0)
            {
                // x is already the exact left edge of the text (the content block
                // is centred as a whole), so draw with NoPadding into a rect the
                // full width of the string. GDI's default padding plus
                // EndEllipsis would otherwise shave the last character off.
                TextRenderer.DrawText(g, _text, Font,
                    new Rectangle((int)Math.Round(x), (int)Math.Round(cy - rect.Height / 2f), textWidth, (int)Math.Round(rect.Height)),
                    foreColor,
                    TextFormatFlags.NoPadding | TextFormatFlags.VerticalCenter |
                    TextFormatFlags.NoPrefix | TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine);
            }
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
            _focused = true;
            Invalidate();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            _focused = false;
            _pressed = false;
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
