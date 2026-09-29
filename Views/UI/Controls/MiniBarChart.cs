using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
    /// </summary>
    public class MiniBarChart : Control
    {
        private readonly List<ChartBar> _data = new();
        private float _scale = 1f;

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
            int axisWidth = Theme.Scaled(52, scale);
            int labelHeight = Theme.Scaled(20, scale);
            int topPad = Theme.Scaled(26, scale);

            var plot = new RectangleF(axisWidth, topPad,
                                      Math.Max(0, Width - axisWidth - Theme.Scaled(4, scale)),
                                      Math.Max(0, Height - labelHeight - topPad));

            DrawLegend(g, scale);

            if (_data.Count == 0 || plot.Width <= 0 || plot.Height <= 0)
            {
                Theme.DrawText(g, "No activity yet", Typography.Body,
                    new RectangleF(0, 0, Width, Height), Colors.FaintText, StringAlignment.Center);
                return;
            }

            decimal max = 0m;
            foreach (var bar in _data)
                max = Math.Max(max, Math.Max(bar.Income, bar.Expense));

            if (max <= 0m)
                max = 1m;

            // Gridlines + value axis
            var axisFont = Typography.Caption;
            for (int i = 0; i <= 2; i++)
            {
                float t = i / 2f;
                float y = plot.Bottom - plot.Height * t;
                using (var pen = new Pen(Colors.ChartGrid, Theme.Scaled(1, scale)))
                {
                    g.DrawLine(pen, plot.Left, y, plot.Right, y);
                }

                decimal value = max * (decimal)t;
                string text = value >= 1000m
                    ? "$" + (value / 1000m).ToString("0.#") + "k"
                    : "$" + value.ToString("0");
                Theme.DrawText(g, text, axisFont,
                    new RectangleF(0, y - Theme.Scaled(9, scale), axisWidth - Theme.Scaled(8, scale), Theme.Scaled(18, scale)),
                    Colors.ChartLabel, StringAlignment.Far);
            }

            float slot = plot.Width / _data.Count;
            float barWidth = Math.Max(Theme.Scaled(6, scale), Math.Min(Theme.Scaled(16, scale), slot / 3.2f));
            float gap = Theme.Scaled(3, scale);
            float radius = Theme.Scaled(3, scale);

            for (int i = 0; i < _data.Count; i++)
            {
                var bar = _data[i];
                float center = plot.Left + slot * i + slot / 2f;
                float groupWidth = barWidth * 2 + gap;
                float startX = center - groupWidth / 2f;

                DrawBar(g, new RectangleF(startX, plot.Bottom - (float)(double)(bar.Income / max) * plot.Height,
                                          barWidth, plot.Height), Colors.Success, radius, scale);
                DrawBar(g, new RectangleF(startX + barWidth + gap, plot.Bottom - (float)(double)(bar.Expense / max) * plot.Height,
                                          barWidth, plot.Height), Colors.Danger, radius, scale);

                Theme.DrawText(g, bar.Label, Typography.Caption,
                    new RectangleF(plot.Left + slot * i, plot.Bottom + Theme.Scaled(4, scale), slot, labelHeight - Theme.Scaled(4, scale)),
                    Colors.MutedText, StringAlignment.Center);
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

        private static void DrawBar(Graphics g, RectangleF area, Color color, float radius, float scale)
        {
            if (area.Height <= 0.5f || area.Width <= 0.5f)
                return;

            float height = Math.Min(area.Height, area.Height);
            var rect = new RectangleF(area.X, area.Bottom - height, area.Width, height);
            if (height <= radius * 2f)
            {
                using var flat = new SolidBrush(color);
                g.FillRectangle(flat, rect);
                return;
            }

            using (var brush = new SolidBrush(color))
            using (var path = Theme.RoundedPath(rect, radius))
            {
                g.FillPath(brush, path);
            }

            // Square off the base so the bar sits flat on the axis
            using var baseBrush = new SolidBrush(color);
            g.FillRectangle(baseBrush, rect.X, rect.Bottom - radius, rect.Width, radius + 1f);
        }
    }
}
