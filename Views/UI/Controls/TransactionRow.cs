using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// Single line item used by the dashboard "Recent transactions" list.
    /// Presentation only - the data is handed in already resolved.
    /// </summary>
    public class TransactionRow : Control
    {
        private TransactionResponseDto? _item;
        private float _scale = 1f;
        private bool _hover;

        public TransactionRow()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Font = Typography.Body;
            Height = Theme.Scaled(56, 1f);
            Margin = Padding.Empty;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TransactionResponseDto? Item
        {
            get => _item;
            set
            {
                _item = value;
                Invalidate();
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
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

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;

            if (_hover)
            {
                using var brush = new SolidBrush(Colors.SurfaceHover);
                using var path = Theme.RoundedPath(new RectangleF(0, 0, Width, Height), Theme.Scaled(Theme.RadiusSm, scale));
                g.FillPath(brush, path);
            }

            var item = _item;
            if (item == null)
                return;

            bool income = item.Type == TransactionType.INCOME;
            Color amountColor = income ? Colors.Success : Colors.Foreground;

            // Monogram tile
            int tile = Theme.Scaled(32, scale);
            var tileRect = new RectangleF(Theme.Scaled(4, scale), (Height - tile) / 2f, tile, tile);
            using (var brush = new SolidBrush(income ? Colors.SuccessSoft : Colors.SurfaceSunken))
            using (var path = Theme.RoundedPath(tileRect, tile / 2f))
            {
                g.FillPath(brush, path);
            }

            string monogram = string.IsNullOrWhiteSpace(item.CategoryName)
                ? "?"
                : item.CategoryName.Trim()[..1].ToUpperInvariant();
            Theme.DrawText(g, monogram, Typography.CaptionMedium,
                new RectangleF(tileRect.X, tileRect.Y, tile, tile),
                income ? Colors.Success : Colors.SecondaryText, StringAlignment.Center);

            // Category + supporting line
            float textLeft = tileRect.Right + Theme.Scaled(Theme.Space3, scale);
            float amountWidth = Theme.Scaled(96, scale);
            var nameBounds = new RectangleF(textLeft, Theme.Scaled(8, scale),
                                            Math.Max(0, Width - textLeft - amountWidth - Theme.Scaled(Theme.Space2, scale)),
                                            Theme.Scaled(20, scale));
            Theme.DrawText(g, item.CategoryName, Typography.BodyMedium, nameBounds, Colors.Foreground);

            string secondary = !string.IsNullOrWhiteSpace(item.Description)
                ? item.Description
                : item.Date == default
                    ? "No description"
                    : item.Date.ToString("d MMM yyyy");
            var secondaryBounds = new RectangleF(textLeft, Theme.Scaled(28, scale),
                                                 nameBounds.Width, Theme.Scaled(18, scale));
            Theme.DrawText(g, secondary, Typography.Caption, secondaryBounds, Colors.MutedText);

            // Amount
            string amount = (income ? "+" : "\u2212") + item.Amount.ToString("C0", System.Globalization.CultureInfo.CurrentCulture);
            var amountBounds = new RectangleF(Width - amountWidth - Theme.Scaled(4, scale), 0,
                                              amountWidth, Height);
            Theme.DrawText(g, amount, Typography.BodyMedium, amountBounds, amountColor, StringAlignment.Far);
        }
    }
}
