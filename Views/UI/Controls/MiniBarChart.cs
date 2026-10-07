using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>One month in the spending overview chart.</summary>
    public sealed class ChartBar
    {
        public ChartBar(string label, decimal income, decimal expense)
        {
            Label = label;
            Income = income;
            Expense = expense;
        }

        public string Label { get; }
        public decimal Income { get; }
        public decimal Expense { get; }
    }

    /// <summary>
    /// Compact income-vs-expense bar chart (GDI+ only, no chart dependency).
    /// Purely visual: the page feeds it already-computed values.
    ///
    /// Every month sits in a light column track, and only money that is
    /// actually there gets a bar - a zero month reads as "nothing happened"
    /// instead of drawing a full column. The axis is rounded up to a round
    /// number and its zero line is left unlabelled; the baseline says it all.
    /// Hovering a month shows the exact figures.
    /// </summary>
    public class MiniBarChart : Control
    {
        private readonly List<ChartBar> _data = new();
        private float _scale = 1f;

        /// <summary>Slot of each month, rebuilt on every paint for hit testing.</summary>
        private RectangleF[] _slots = Array.Empty<RectangleF>();

        private RectangleF _plot;
        private decimal _axisMax = 1m;
        private int _hover = -1;

        public MiniBarChart()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
        }

        public void SetData(IEnumerable<ChartBar> data)
        {
            _data.Clear();
            if (data != null)
                _data.AddRange(data);

            if (_hover >= _data.Count)
                _hover = -1;

            Invalidate();
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
            int axisWidth = Theme.Scaled(48, scale);
            int labelHeight = Theme.Scaled(20, scale);
            int topPad = Theme.Scaled(28, scale);

            var plot = new RectangleF(axisWidth, topPad,
                                      Math.Max(0, Width - axisWidth - Theme.Scaled(4, scale)),
                                      Math.Max(0, Height - labelHeight - topPad));
            _plot = plot;

            decimal max = 0m;
            foreach (var bar in _data)
                max = Math.Max(max, Math.Max(bar.Income, bar.Expense));

            if (_data.Count == 0 || plot.Width <= 0 || plot.Height <= 0 || max <= 0m)
            {
                _slots = Array.Empty<RectangleF>();
                Theme.DrawText(g, "No activity yet", Typography.Body,
                               new RectangleF(0, topPad, Width, Math.Max(0, Height - topPad)),
                               Colors.FaintText, StringAlignment.Center);
                return;
            }

            DrawLegend(g, scale);

            _axisMax = NiceMax(max);

            float slot = plot.Width / _data.Count;
            float barWidth = Math.Max(Theme.Scaled(6, scale),
                                      Math.Min(Theme.Scaled(16, scale), slot / 3.4f));
            float gap = Theme.Scaled(3, scale);
            float radius = Theme.Scaled(4, scale);

            // Slot rectangles first: they drive the hover band and the hit test.
            _slots = new RectangleF[_data.Count];
            for (int i = 0; i < _data.Count; i++)
                _slots[i] = new RectangleF(plot.Left + slot * i, plot.Top, slot, plot.Height);

            if (IsHovered)
            {
                var hit = _slots[_hover];
                var band = new RectangleF(hit.Left + Theme.Scaled(2, scale), hit.Top,
                                          Math.Max(0, hit.Width - Theme.Scaled(4, scale)), hit.Height);
                using var bandBrush = new SolidBrush(Colors.BorderSoft);
                using var bandPath = Theme.RoundedPath(band, Theme.Scaled(6, scale));
                g.FillPath(bandBrush, bandPath);
            }

            DrawGrid(g, plot, axisWidth, scale);

            for (int i = 0; i < _data.Count; i++)
            {
                var bar = _data[i];
                var slotRect = _slots[i];
                float groupWidth = barWidth * 2f + gap;
                float startX = slotRect.Left + (slotRect.Width - groupWidth) / 2f;

                var incomeTrack = new RectangleF(startX, plot.Top, barWidth, plot.Height);
                var expenseTrack = new RectangleF(startX + barWidth + gap, plot.Top, barWidth, plot.Height);

                DrawTrack(g, incomeTrack, radius);
                DrawTrack(g, expenseTrack, radius);

                DrawBar(g, incomeTrack, bar.Income, _axisMax, Colors.Success, radius, scale);
                DrawBar(g, expenseTrack, bar.Expense, _axisMax, Colors.Danger, radius, scale);

                Theme.DrawText(g, bar.Label, Typography.Caption,
                               new RectangleF(slotRect.Left, plot.Bottom + Theme.Scaled(4, scale),
                                              slotRect.Width, labelHeight - Theme.Scaled(4, scale)),
                               i == _hover ? Colors.SecondaryText : Colors.MutedText,
                               StringAlignment.Center);
            }

            // Baseline: the one line that is allowed to be a little stronger.
            using (var baseline = new Pen(Colors.Border, scale))
            {
                g.DrawLine(baseline, plot.Left, plot.Bottom, plot.Right, plot.Bottom);
            }

            if (IsHovered)
                DrawTooltip(g, scale, _hover);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            SetHover(HitTest(e.X, e.Y));
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            SetHover(-1);
        }

        private bool IsHovered => _hover >= 0 && _hover < _data.Count && _hover < _slots.Length;

        private void SetHover(int index)
        {
            if (_hover == index)
                return;

            _hover = index;
            Invalidate();
        }

        private int HitTest(int x, int y)
        {
            if (_slots.Length == 0 || _slots.Length != _data.Count)
                return -1;

            if (!_plot.Contains(x, y))
                return -1;

            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i].Contains(x, y))
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Gridlines and the two axis figures that carry information. The zero
        /// line at the bottom is the baseline, so it is deliberately not
        /// labelled - "$0" only ever repeats what the baseline already shows.
        /// </summary>
        private void DrawGrid(Graphics g, RectangleF plot, int axisWidth, float scale)
        {
            var axisFont = Typography.Caption;
            using var pen = new Pen(Colors.ChartGrid, Theme.Scaled(1, scale));

            for (int i = 1; i <= 2; i++)
            {
                float t = i / 2f;
                float y = plot.Bottom - plot.Height * t;
                g.DrawLine(pen, plot.Left, y, plot.Right, y);

                Theme.DrawText(g, FormatValue(_axisMax * (decimal)t), axisFont,
                               new RectangleF(0, y - Theme.Scaled(9, scale),
                                              axisWidth - Theme.Scaled(8, scale),
                                              Theme.Scaled(18, scale)),
                               Colors.ChartLabel, StringAlignment.Far);
            }
        }

        private void DrawLegend(Graphics g, float scale)
        {
            int dot = Theme.Scaled(7, scale);
            int right = Width - Theme.Scaled(4, scale);
            int y = Theme.Scaled(15, scale);
            var font = Typography.Caption;

            // Expenses (red) on the far right, Income (green) before it.
            var expenseSize = Theme.MeasureText(g, "Expenses", font);
            float expenseTextX = right - expenseSize.Width;
            Theme.FillCircle(g, expenseTextX - dot - Theme.Scaled(4, scale), y, dot / 2f, Colors.Danger);
            Theme.DrawText(g, "Expenses", font,
                           new RectangleF(expenseTextX, y - Theme.Scaled(9, scale), expenseSize.Width, Theme.Scaled(18, scale)),
                           Colors.MutedText, StringAlignment.Near);

            var incomeSize = Theme.MeasureText(g, "Income", font);
            float incomeTextX = expenseTextX - dot - Theme.Scaled(10, scale) - incomeSize.Width;
            Theme.FillCircle(g, incomeTextX - dot - Theme.Scaled(4, scale), y, dot / 2f, Colors.Success);
            Theme.DrawText(g, "Income", font,
                           new RectangleF(incomeTextX, y - Theme.Scaled(9, scale), incomeSize.Width, Theme.Scaled(18, scale)),
                           Colors.MutedText, StringAlignment.Near);
        }

        /// <summary>The pale column a bar grows in. It keeps a month with no money readable.</summary>
        private static void DrawTrack(Graphics g, RectangleF rect, float radius)
        {
            if (rect.Width <= 0.5f || rect.Height <= 0.5f)
                return;

            using var path = Theme.RoundedPath(rect, radius);
            using var brush = new SolidBrush(Colors.ChartTrack);
            g.FillPath(brush, path);
        }

        /// <summary>
        /// Draws one value column inside its track. A zero draws nothing at
        /// all, and everything else is measured from the value up from the
        /// baseline - the bar never runs past the axis, whatever the figure.
        /// </summary>
        private static void DrawBar(Graphics g, RectangleF track, decimal value, decimal axisMax,
                                    Color color, float radius, float scale)
        {
            if (value <= 0m || axisMax <= 0m)
                return;

            float height = (float)(double)(value / axisMax) * track.Height;
            height = Math.Max(Theme.Scaled(2, scale), Math.Min(height, track.Height));

            var rect = new RectangleF(track.Left, track.Bottom - height, track.Width, height);
            if (rect.Width <= 0.5f || rect.Height <= 0.5f)
                return;

            using var path = TopRoundedPath(rect, radius);
            using var brush = new LinearGradientBrush(rect,
                Theme.Mix(color, Colors.Surface, 0.24f), color, LinearGradientMode.Vertical);
            g.FillPath(brush, path);
        }

        /// <summary>Rounded on the top corners only, square where it meets the baseline.</summary>
        private static GraphicsPath TopRoundedPath(RectangleF rect, float radius)
        {
            var path = new GraphicsPath();

            if (rect.Width <= 0 || rect.Height <= 0)
                return path;

            float r = Math.Min(radius, Math.Min(rect.Width, rect.Height) / 2f);
            if (r <= 0.5f)
            {
                path.AddRectangle(rect);
                return path;
            }

            float d = r * 2f;
            path.AddArc(rect.Left, rect.Top, d, d, 180f, 90f);
            path.AddArc(rect.Right - d, rect.Top, d, d, 270f, 90f);
            path.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
            path.CloseFigure();
            return path;
        }

        /// <summary>Exact figures for the hovered month, in a floating card.</summary>
        private void DrawTooltip(Graphics g, float scale, int index)
        {
            var bar = _data[index];
            var slot = _slots[index];
            if (slot.Width <= 0)
                return;

            var title = Typography.CaptionMedium;
            var body = Typography.Caption;

            string heading = bar.Label;
            string income = "Income  " + FormatMoney(bar.Income);
            string expense = "Expense  " + FormatMoney(bar.Expense);

            float pad = Theme.Scaled(10, scale);
            float dot = Theme.Scaled(6, scale);
            float textGap = Theme.Scaled(7, scale);
            float lineGap = Theme.Scaled(5, scale);

            float titleHeight = Theme.MeasureText(g, heading, title).Height;
            float bodyHeight = Math.Max(Theme.MeasureText(g, income, body).Height,
                                        Theme.MeasureText(g, expense, body).Height);
            float textWidth = Math.Max(Theme.MeasureText(g, heading, title).Width,
                                       Math.Max(Theme.MeasureText(g, income, body).Width,
                                                Theme.MeasureText(g, expense, body).Width));

            float width = pad * 2f + dot + textGap + textWidth;
            float height = pad * 2f + titleHeight + lineGap + bodyHeight + lineGap + bodyHeight;

            // Sits just above the taller of the two bars, clamped inside the control.
            decimal peak = Math.Max(bar.Income, bar.Expense);
            float peakTop = plot_TopFor(peak);

            float x = slot.Left + slot.Width / 2f - width / 2f;
            x = Math.Max(0f, Math.Min(x, Width - width));

            float y = peakTop - height - Theme.Scaled(6, scale);
            if (y < 0f)
                y = 0f;
            if (y + height > Height)
                y = Math.Max(0f, Height - height);

            var box = new RectangleF(x, y, width, height);
            Theme.PaintSurface(g, box, Theme.Scaled(Theme.RadiusSm, scale),
                               Colors.Foreground, null, 1f, shadow: true);

            float line = y + pad;
            Theme.DrawText(g, heading, title,
                           new RectangleF(x + pad, line, textWidth, titleHeight),
                           Colors.OnPrimary, StringAlignment.Near);
            line += titleHeight + lineGap;

            Theme.FillCircle(g, x + pad + dot / 2f, line + bodyHeight / 2f, dot / 2f,
                             Theme.Mix(Colors.Success, Colors.Surface, 0.35f));
            Theme.DrawText(g, income, body,
                           new RectangleF(x + pad + dot + textGap, line, textWidth, bodyHeight),
                           Colors.OnPrimary, StringAlignment.Near);
            line += bodyHeight + lineGap;

            Theme.FillCircle(g, x + pad + dot / 2f, line + bodyHeight / 2f, dot / 2f,
                             Theme.Mix(Colors.Danger, Colors.Surface, 0.35f));
            Theme.DrawText(g, expense, body,
                           new RectangleF(x + pad + dot + textGap, line, textWidth, bodyHeight),
                           Colors.OnPrimary, StringAlignment.Near);
        }

        /// <summary>The y coordinate a value reaches, measured from the baseline.</summary>
        private float plot_TopFor(decimal value)
        {
            if (_axisMax <= 0m)
                return _plot.Bottom;

            return _plot.Bottom - (float)(double)(value / _axisMax) * _plot.Height;
        }

        /// <summary>
        /// Rounds the top of the scale up to a figure the gridlines can be
        /// counted on: a step of 1, 2, 2.5 or 5 times a power of ten, repeated
        /// three times. A chart whose top is always a round number lets the two
        /// labelled lines mean something.
        /// </summary>
        private static decimal NiceMax(decimal value)
        {
            if (value <= 0m)
                return 1m;

            decimal rough = value / 3m;
            decimal magnitude = 1m;
            while (rough >= magnitude * 10m)
                magnitude *= 10m;
            while (rough < magnitude)
                magnitude /= 10m;

            decimal normalized = rough / magnitude;
            decimal nice = normalized <= 1m ? 1m
                         : normalized <= 2m ? 2m
                         : normalized <= 2.5m ? 2.5m
                         : normalized <= 5m ? 5m
                         : 10m;

            decimal step = nice * magnitude;
            if (step <= 0m)
                return value;

            decimal max = step * 3m;
            return max < value ? max + step : max;
        }

        /// <summary>Compact money for the axis, full money for the tooltip.</summary>
        private static string FormatValue(decimal value)
        {
            if (value >= 1000m)
            {
                decimal thousands = value / 1000m;
                string number = thousands == Math.Truncate(thousands)
                    ? thousands.ToString("0")
                    : thousands.ToString("0.#");
                return "$" + number + "k";
            }

            return "$" + value.ToString("0.##");
        }

        private static string FormatMoney(decimal value) =>
            value.ToString("C", CultureInfo.CurrentCulture);
    }
}
