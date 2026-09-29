using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.UI
{
    /// <summary>
    /// Spacing scale, corner radii and the shared GDI+ painting primitives
    /// (rounded surfaces, hairlines, shadows, ellipsised text) used by every
    /// Finora control. Keeps spacing consistent and avoids magic numbers.
    /// </summary>
    public static class Theme
    {
        // Spacing scale
        public const int Space1 = 4;
        public const int Space2 = 8;
        public const int Space3 = 12;
        public const int Space4 = 16;
        public const int Space5 = 20;
        public const int Space6 = 24;
        public const int Space7 = 32;

        // Corner radii
        public const int RadiusSm = 6;
        public const int RadiusMd = 8;
        public const int RadiusLg = 12;
        public const int RadiusXl = 16;
        public const int RadiusPill = 999;

        // Control metrics
        public const int InputHeight = 40;
        public const int InputHeightLarge = 44;
        public const int ButtonHeight = 38;
        public const int ButtonHeightLarge = 44;
        public const int IconSize = 18;
        public const int IconSizeLarge = 20;

        /// <summary>Design-time scale factor for the current monitor (96 DPI = 1.0).</summary>
        public static float ScaleOf(Control control)
        {
            if (control == null)
                return 1f;

            float dpi = control.DeviceDpi > 0 ? control.DeviceDpi : 96f;
            float scale = dpi / 96f;
            return scale < 0.75f ? 0.75f : (scale > 3f ? 3f : scale);
        }

        public static int Scaled(int value, float scale) => (int)Math.Round(value * scale);

        public static Size Scaled(int width, int height, float scale) =>
            new Size(Scaled(width, scale), Scaled(height, scale));

        public static Padding ScaledPadding(int all, float scale) => new Padding(Scaled(all, scale));

        public static Padding ScaledPadding(int horizontal, int vertical, float scale) =>
            new Padding(Scaled(horizontal, scale), Scaled(vertical, scale),
                        Scaled(horizontal, scale), Scaled(vertical, scale));

        /// <summary>Configures a Graphics for smooth, high quality vector drawing.</summary>
        public static void SetupQuality(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        }

        /// <summary>Builds a rounded rectangle path (clamped to the given bounds).</summary>
        public static GraphicsPath RoundedPath(RectangleF rect, float radius)
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
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0f, 90f);
            path.AddArc(rect.Left, rect.Bottom - d, d, d, 90f, 90f);
            path.CloseFigure();
            return path;
        }

        public static GraphicsPath RoundedPath(Rectangle rect, int radius) =>
            RoundedPath((RectangleF)rect, radius);

        /// <summary>Paints a layered surface: soft shadow, fill and optional hairline border.</summary>
        public static void PaintSurface(Graphics g,
                                        RectangleF rect,
                                        float radius,
                                        Color fill,
                                        Color? border = null,
                                        float borderWidth = 1f,
                                        bool shadow = true)
        {
            if (rect.Width <= 0 || rect.Height <= 0)
                return;

            if (shadow)
            {
                using var shadowBrush = new SolidBrush(Color.FromArgb(10, 24, 24, 27));
                using var shadowPath = RoundedPath(
                    new RectangleF(rect.X, rect.Y + 1f, rect.Width, rect.Height), radius);
                g.FillPath(shadowBrush, shadowPath);

                using var deeperShadow = new SolidBrush(Color.FromArgb(6, 24, 24, 27));
                using var deeperPath = RoundedPath(
                    new RectangleF(rect.X, rect.Y + 2f, rect.Width, rect.Height), radius);
                g.FillPath(deeperShadow, deeperPath);
            }

            using (var fillBrush = new SolidBrush(fill))
            using (var path = RoundedPath(rect, radius))
            {
                g.FillPath(fillBrush, path);
            }

            if (border.HasValue && borderWidth > 0f)
            {
                using var pen = new Pen(border.Value, borderWidth);
                using var path = RoundedPath(
                    new RectangleF(rect.X + borderWidth / 2f, rect.Y + borderWidth / 2f,
                                   rect.Width - borderWidth, rect.Height - borderWidth),
                    radius - borderWidth / 2f);
                g.DrawPath(pen, path);
            }
        }

        /// <summary>Paints a 1px hairline (crisp on both sides of a pixel).</summary>
        public static void PaintHairline(Graphics g, RectangleF rect, Color color, float thickness = 1f)
        {
            using var pen = new Pen(color, thickness);
            g.DrawLine(pen, rect.Left, rect.Top + thickness / 2f, rect.Right, rect.Top + thickness / 2f);
        }

        public static void PaintVerticalHairline(Graphics g, RectangleF rect, Color color, float thickness = 1f)
        {
            using var pen = new Pen(color, thickness);
            g.DrawLine(pen, rect.Left + thickness / 2f, rect.Top, rect.Left + thickness / 2f, rect.Bottom);
        }

        public static void PaintDivider(Graphics g, int x, int y, int width, Color color, float scale = 1f)
        {
            PaintHairline(g, new RectangleF(x, y, width, 1), color, Theme.Scaled(1, scale));
        }

        /// <summary>Draws a solid circle.</summary>
        public static void FillCircle(Graphics g, float cx, float cy, float radius, Color color)
        {
            using var brush = new SolidBrush(color);
            g.FillEllipse(brush, cx - radius, cy - radius, radius * 2f, radius * 2f);
        }

        /// <summary>Draws a circle outline.</summary>
        public static void DrawCircle(Graphics g, float cx, float cy, float radius, Color color, float width = 1.6f)
        {
            using var pen = new Pen(color, width);
            g.DrawEllipse(pen, cx - radius, cy - radius, radius * 2f, radius * 2f);
        }

        /// <summary>GDI+ text drawing (vertically centred) used across the custom controls.</summary>
        public static void DrawText(Graphics g,
                                   string text,
                                   Font font,
                                   RectangleF bounds,
                                   Color color,
                                   StringAlignment horizontal = StringAlignment.Near,
                                   StringFormatFlags flags = StringFormatFlags.NoWrap)
        {
            if (string.IsNullOrEmpty(text))
                return;

            using var brush = new SolidBrush(color);
            using var format = new StringFormat(flags)
            {
                Alignment = horizontal,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter
            };
            g.DrawString(text, font, brush, bounds, format);
        }

        public static void DrawText(Graphics g,
                                   string text,
                                   Font font,
                                   PointF location,
                                   Color color,
                                   StringAlignment horizontal = StringAlignment.Near)
        {
            if (string.IsNullOrEmpty(text))
                return;

            using var brush = new SolidBrush(color);
            using var format = new StringFormat(StringFormatFlags.NoWrap)
            {
                Alignment = horizontal,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter
            };
            g.DrawString(text, font, brush, location, format);
        }

        /// <summary>Measures a single line of text with the same engine used to paint it.</summary>
        public static SizeF MeasureText(Graphics g, string text, Font font)
        {
            if (g == null || string.IsNullOrEmpty(text) || font == null)
                return SizeF.Empty;

            try
            {
                using var format = new StringFormat(StringFormatFlags.NoWrap);
                return g.MeasureString(text, font, int.MaxValue, format);
            }
            catch
            {
                return SizeF.Empty;
            }
        }

        /// <summary>Word-wraps text to the given width and returns the wrapped block.</summary>
        public static string WrapText(Graphics g, string text, Font font, int maxWidth, out SizeF size)
        {
            size = SizeF.Empty;
            if (g == null || font == null || string.IsNullOrEmpty(text) || maxWidth <= 0)
            {
                return text ?? string.Empty;
            }

            using var format = new StringFormat(StringFormat.GenericTypographic);
            var layout = new SizeF(maxWidth, float.MaxValue);
            var measured = g.MeasureString(text, font, layout, format);
            size = new SizeF(Math.Min(measured.Width, maxWidth), measured.Height);
            return text;
        }

        /// <summary>Truncates a single line of text with an ellipsis so it never overflows.</summary>
        public static string Ellipsize(string text, Font font, float maxWidth, Graphics g)
        {
            if (string.IsNullOrEmpty(text) || g == null || maxWidth <= 0)
                return text ?? string.Empty;

            using var format = new StringFormat(StringFormatFlags.NoWrap);
            if (g.MeasureString(text, font, int.MaxValue, format).Width <= maxWidth)
                return text;

            const string ellipsis = "...";
            string candidate = text;
            while (candidate.Length > 1)
            {
                candidate = text.Substring(0, candidate.Length - 1).TrimEnd() + ellipsis;
                if (g.MeasureString(candidate, font, int.MaxValue, format).Width <= maxWidth)
                    return candidate;
            }

            return ellipsis;
        }

        /// <summary>Blends two colours, t = 0 returns <paramref name="from"/>, t = 1 returns <paramref name="to"/>.</summary>
        public static Color Mix(Color from, Color to, float t)
        {
            t = Math.Max(0f, Math.Min(1f, t));
            return Color.FromArgb(
                (int)Math.Round(from.A + (to.A - from.A) * t),
                (int)Math.Round(from.R + (to.R - from.R) * t),
                (int)Math.Round(from.G + (to.G - from.G) * t),
                (int)Math.Round(from.B + (to.B - from.B) * t));
        }

        public static Color WithAlpha(Color color, int alpha) =>
            Color.FromArgb(Math.Max(0, Math.Min(255, alpha)), color);

        /// <summary>Standard page padding used by every content page.</summary>
        public static Padding PagePadding() =>
            new Padding(Theme.Space6, Theme.Space5, Theme.Space6, Theme.Space6);
    }
}
