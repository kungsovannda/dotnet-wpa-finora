using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// Minimal, centred empty state: soft icon tile, short title, one line of
    /// guidance and an optional action. No illustrations, no noise.
    /// </summary>
    public class EmptyState : Control
    {
        private string _title = string.Empty;
        private string _description = string.Empty;
        private string _actionText = string.Empty;
        private string _icon = Icons.Layers;
        private float _scale = 1f;
        private bool _hover;
        private Rectangle _actionBounds;
        private bool _actionVisible;

        public EmptyState()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Font = Typography.Body;
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string Title
        {
            get => _title;
            set
            {
                _title = value ?? string.Empty;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string Description
        {
            get => _description;
            set
            {
                _description = value ?? string.Empty;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string ActionText
        {
            get => _actionText;
            set
            {
                _actionText = value ?? string.Empty;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(Icons.Layers)]
        public string Icon
        {
            get => _icon;
            set
            {
                _icon = value ?? string.Empty;
                Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text
        {
            get => _title;
            set => Title = value;
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

            int tile = Theme.Scaled(56, scale);
            int gapTileTitle = Theme.Scaled(Theme.Space4, scale);
            int gapTitleDesc = Theme.Scaled(Theme.Space1, scale);
            int gapDescAction = Theme.Scaled(Theme.Space5, scale);

            var titleFont = Typography.SectionTitle;
            var bodyFont = Typography.Body;
            var actionFont = Typography.Button;

            int titleHeight = Theme.Scaled(26, scale);
            int maxTextWidth = (int)Math.Max(120, Math.Min(Width - Theme.Scaled(48, scale), Theme.Scaled(420, scale)));

            Theme.WrapText(g, _description, bodyFont, maxTextWidth, out var descSize);
            int descHeight = string.IsNullOrEmpty(_description)
                ? 0
                : Math.Max(Theme.Scaled(20, scale), (int)Math.Ceiling(descSize.Height));

            _actionVisible = !string.IsNullOrEmpty(_actionText);
            int actionHeight = _actionVisible
                ? Theme.Scaled(Theme.ButtonHeight, scale) + gapDescAction
                : 0;

            int contentHeight = tile + gapTileTitle + titleHeight +
                                (string.IsNullOrEmpty(_description) ? 0 : gapTitleDesc + descHeight) +
                                actionHeight;

            // Vertically centre the block, biased slightly above the middle.
            float top = Math.Max(Theme.Scaled(Theme.Space6, scale), (Height - contentHeight) / 2f - Theme.Scaled(12, scale));
            float centerX = Width / 2f;

            // Icon tile
            var tileRect = new RectangleF(centerX - tile / 2f, top, tile, tile);
            using (var brush = new SolidBrush(Colors.Surface))
            using (var path = Theme.RoundedPath(tileRect, Theme.Scaled(Theme.RadiusLg, scale)))
            {
                g.FillPath(brush, path);
            }
            using (var pen = new Pen(Colors.Border, scale))
            using (var path = Theme.RoundedPath(tileRect, Theme.Scaled(Theme.RadiusLg, scale)))
            {
                g.DrawPath(pen, path);
            }

            int iconSize = Theme.Scaled(24, scale);
            Icons.DrawCentered(g, _icon, iconSize, tileRect, Colors.PrimaryOrange);

            // Title
            float y = top + tile + gapTileTitle;
            Theme.DrawText(g, _title, titleFont,
                new RectangleF(0, y, Width, titleHeight), Colors.Foreground, StringAlignment.Center);
            y += titleHeight;

            if (!string.IsNullOrEmpty(_description))
            {
                y += gapTitleDesc;
                var bounds = new RectangleF(centerX - maxTextWidth / 2f, y, maxTextWidth, descHeight);
                Theme.DrawText(g, _description, bodyFont, bounds, Colors.MutedText, StringAlignment.Center);
                y += descHeight;
            }

            if (_actionVisible)
            {
                y += gapDescAction;
                int textWidth = TextRenderer.MeasureText(_actionText, actionFont, Size.Empty, TextFormatFlags.NoPadding).Width;
                int width = textWidth + Theme.Scaled(32, scale) + Theme.Scaled(Theme.IconSize, scale) + Theme.Scaled(8, scale);
                int x = (int)(centerX - width / 2f);
                _actionBounds = new Rectangle(x, (int)y, width, Theme.Scaled(Theme.ButtonHeight, scale));

                Color fill = _hover ? Colors.PrimaryHover : Colors.PrimaryOrange;
                using (var brush = new SolidBrush(fill))
                using (var path = Theme.RoundedPath(_actionBounds, Theme.Scaled(Theme.RadiusMd, scale)))
                {
                    g.FillPath(brush, path);
                }

                int actionIconSize = Theme.Scaled(Theme.IconSize, scale);
                int gap = Theme.Scaled(8, scale);
                int contentLeft = _actionBounds.X + Theme.Scaled(16, scale);
                Icons.Draw(g, Icons.Plus, actionIconSize,
                    new RectangleF(contentLeft, _actionBounds.Y + (_actionBounds.Height - actionIconSize) / 2f,
                                   actionIconSize, actionIconSize),
                    Colors.OnPrimary);

                TextRenderer.DrawText(g, _actionText, actionFont,
                    new Rectangle(contentLeft + actionIconSize + gap, _actionBounds.Y,
                                  textWidth + 2, _actionBounds.Height),
                    Colors.OnPrimary,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                    TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            bool over = _actionVisible && _actionBounds.Contains(e.Location);
            if (over != _hover)
            {
                _hover = over;
                Cursor = over ? Cursors.Hand : Cursors.Default;
                Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _hover = false;
            Cursor = Cursors.Default;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_actionVisible && _actionBounds.Contains(e.Location))
                OnClick(EventArgs.Empty);
            base.OnMouseUp(e);
        }
    }
}
