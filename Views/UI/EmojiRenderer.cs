using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.UI
{
    /// <summary>
    /// Single source of truth for drawing emoji glyphs.
    /// <para>
    /// Every glyph is rasterised once into a tightly cropped ARGB bitmap with
    /// GDI+ anti-aliasing, and the result is cached per glyph, pixel size and
    /// colour. Because the cached bitmap is cropped to the real ink bounds,
    /// callers centre the glyph with plain arithmetic instead of nudging it by
    /// hand against a measurement box that never matches the ink.
    /// </para>
    /// <para>
    /// The system emoji font is monochrome on some Windows installations, so
    /// rasterising in the caller's colour keeps the glyph looking deliberate on
    /// every surface instead of dropping a hard black blob onto it.
    /// </para>
    /// </summary>
    public static class EmojiRenderer
    {
        /// <summary>Upper bound on cached bitmaps; the picker shows far fewer.</summary>
        private const int MaxEntries = 512;

        private static readonly Dictionary<(string Glyph, int Pixels, int Colour), Bitmap> Cache = new();
        private static readonly object Gate = new();

        /// <summary>Default glyph colour when a caller does not supply a tint.</summary>
        public static Color DefaultTint => Colors.Foreground;

        /// <summary>
        /// Draws <paramref name="glyph"/> centred inside <paramref name="area"/>,
        /// scaled to fit while keeping its aspect ratio.
        /// </summary>
        /// <param name="g">Target graphics.</param>
        /// <param name="glyph">Emoji to draw.</param>
        /// <param name="pixelSize">Tallest edge of the glyph, in pixels.</param>
        /// <param name="area">Rectangle to centre the glyph in.</param>
        /// <param name="tint">Colour for the glyph.</param>
        public static void Draw(Graphics g, string glyph, int pixelSize, RectangleF area, Color? tint = null)
        {
            if (g == null || area.Width <= 0 || area.Height <= 0 || pixelSize <= 0)
                return;

            var bmp = Get(glyph, pixelSize, tint ?? DefaultTint);
            if (bmp == null || bmp.Width == 0 || bmp.Height == 0)
                return;

            // Fit inside the area, preserving the glyph's aspect ratio. The cached
            // bitmap is cropped to the ink, so this centres it exactly.
            float ratio = Math.Min(area.Width / bmp.Width, area.Height / bmp.Height);
            var dest = new RectangleF(
                area.X + (area.Width - bmp.Width * ratio) / 2f,
                area.Y + (area.Height - bmp.Height * ratio) / 2f,
                bmp.Width * ratio,
                bmp.Height * ratio);

            var previousInterpolation = g.InterpolationMode;
            var previousOffset = g.PixelOffsetMode;
            try
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(bmp, dest);
            }
            catch (Exception)
            {
                // A malformed glyph must never take the UI down.
            }
            finally
            {
                g.InterpolationMode = previousInterpolation;
                g.PixelOffsetMode = previousOffset;
            }
        }

        /// <summary>Returns the cached, tightly cropped glyph bitmap, or null.</summary>
        public static Bitmap? Get(string glyph, int pixelSize, Color tint)
        {
            if (string.IsNullOrWhiteSpace(glyph) || pixelSize <= 0)
                return null;

            glyph = glyph.Trim();
            var key = (glyph, pixelSize, tint.ToArgb());

            lock (Gate)
            {
                if (Cache.TryGetValue(key, out var cached))
                    return cached;
            }

            var bmp = Rasterise(glyph, pixelSize, tint);

            lock (Gate)
            {
                if (Cache.Count >= MaxEntries)
                {
                    foreach (var stale in Cache.Values)
                        stale.Dispose();

                    Cache.Clear();
                }

                Cache[key] = bmp!;
            }

            return bmp;
        }

        /// <summary>Drops every cached bitmap (call when the DPI changes).</summary>
        public static void ClearCache()
        {
            lock (Gate)
            {
                foreach (var bmp in Cache.Values)
                    bmp.Dispose();

                Cache.Clear();
            }
        }

        private static Bitmap? Rasterise(string glyph, int pixelSize, Color colour)
        {
            try
            {
                using var scratch = new Bitmap(1, 1);
                using var g = Graphics.FromImage(scratch);

                // Pixel units keep the glyph exactly the requested size instead
                // of inheriting the monitor's point-to-pixel ratio.
                using var font = new Font(Emoji.Family, pixelSize, FontStyle.Regular, GraphicsUnit.Pixel);
                var measured = g.MeasureString(glyph, font, int.MaxValue, StringFormat.GenericTypographic);
                int width = Math.Max(1, (int)Math.Ceiling(measured.Width) + 6);
                int height = Math.Max(1, (int)Math.Ceiling(measured.Height) + 6);

                using var full = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
                using (var fg = Graphics.FromImage(full))
                {
                    fg.Clear(Color.Transparent);
                    // Grayscale anti-aliasing: the plain GDI path produces hard,
                    // jagged edges at these sizes because a memory DC is not
                    // anti-aliased by the font smoother.
                    fg.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    fg.SmoothingMode = SmoothingMode.AntiAlias;

                    // Draw with an inset so the crop always keeps a fully
                    // transparent border, which stops edge bleed when resampled.
                    using var format = new StringFormat(StringFormat.GenericTypographic)
                    {
                        FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip
                    };
                    using var brush = new SolidBrush(colour);
                    fg.DrawString(glyph, font, brush, 2f, 0f, format);
                }

                return Crop(full, 1);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>Crops to the non-transparent pixels, keeping a 1px margin.</summary>
        private static Bitmap Crop(Bitmap source, int margin)
        {
            int minX = source.Width, minY = source.Height, maxX = -1, maxY = -1;
            for (int y = 0; y < source.Height; y++)
            for (int x = 0; x < source.Width; x++)
            {
                if (source.GetPixel(x, y).A <= 8)
                    continue;

                if (x < minX) minX = x;
                if (y < minY) minY = y;
                if (x > maxX) maxX = x;
                if (y > maxY) maxY = y;
            }

            if (maxX < 0)
                return new Bitmap(1, 1, PixelFormat.Format32bppPArgb);

            int left = Math.Max(0, minX - margin);
            int top = Math.Max(0, minY - margin);
            int width = Math.Min(source.Width - left, maxX - minX + 1 + margin * 2);
            int height = Math.Min(source.Height - top, maxY - minY + 1 + margin * 2);

            var cropped = new Bitmap(Math.Max(1, width), Math.Max(1, height), PixelFormat.Format32bppPArgb);
            using var g = Graphics.FromImage(cropped);
            g.Clear(Color.Transparent);
            g.DrawImage(source,
                new Rectangle(0, 0, cropped.Width, cropped.Height),
                new Rectangle(left, top, cropped.Width, cropped.Height),
                GraphicsUnit.Pixel);
            return cropped;
        }
    }
}
