using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.UI
{
    /// <summary>
    /// Lucide-style outline icons drawn with GDI+ (24x24 grid, rounded joins,
    /// 2px stroke scaled down). No external icon font or image dependency.
    /// Rendered bitmaps are cached per name / size / colour.
    /// </summary>
    public static class Icons
    {
        public const string Dashboard = "dashboard";
        public const string Transactions = "transactions";
        public const string Categories = "categories";
        public const string Reports = "reports";
        public const string Settings = "settings";
        public const string Wallet = "wallet";
        public const string TrendingUp = "trending-up";
        public const string TrendingDown = "trending-down";
        public const string Receipt = "receipt";
        public const string Plus = "plus";
        public const string More = "more";
        public const string Edit = "edit";
        public const string Trash = "trash";
        public const string User = "user";
        public const string ChevronDown = "chevron-down";
        public const string ChevronRight = "chevron-right";
        public const string Close = "close";
        public const string Search = "search";
        public const string Layers = "layers";
        public const string Sparkles = "sparkles";
        public const string Calendar = "calendar";
        public const string Info = "info";
        public const string Lock = "lock";
        public const string Tag = "tag";

        private static readonly ConcurrentDictionary<string, Bitmap> Cache =
            new ConcurrentDictionary<string, Bitmap>();

        /// <summary>Returns (and caches) an icon bitmap.</summary>
        /// <remarks>
        /// The returned bitmap is cached and shared by every control, so callers
        /// must NOT dispose it. Prefer <see cref="Draw"/>, which handles this.
        /// </remarks>
        public static Bitmap Get(string name, int size = Theme.IconSize, Color? color = null)
        {
            size = Math.Max(10, size);
            var tint = color ?? Colors.SecondaryText;
            string key = string.Concat(name, "|", size.ToString(), "|", tint.ToArgb().ToString());

            return Cache.GetOrAdd(key, _ => Render(name, size, tint));
        }

        /// <summary>
        /// Draws an icon into <paramref name="destination"/>. The cached bitmap is
        /// shared, so it is deliberately not disposed here.
        /// </summary>
        public static void Draw(Graphics g, string name, int size, RectangleF destination, Color? color = null)
        {
            if (destination.Width <= 0f || destination.Height <= 0f)
                return;

            g.DrawImage(Get(name, size, color), destination);
        }

        /// <summary>Draws an icon centred inside <paramref name="bounds"/>.</summary>
        public static void DrawCentered(Graphics g, string name, int size, RectangleF bounds, Color? color = null)
        {
            float x = bounds.X + (bounds.Width - size) / 2f;
            float y = bounds.Y + (bounds.Height - size) / 2f;
            Draw(g, name, size, new RectangleF(x, y, size, size), color);
        }

        /// <summary>Converts an icon to white-on-primary variants (used on coloured buttons).</summary>
        public static Bitmap OnPrimary(string name, int size = Theme.IconSize) =>
            Get(name, size, Colors.OnPrimary);

        private static Bitmap Render(string name, int size, Color color)
        {
            var bitmap = new Bitmap(size, size);
            bitmap.SetResolution(96f, 96f);

            using var g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.Clear(Color.Transparent);

            float s = size / 24f;              // design grid is 24x24
            float stroke = Math.Max(1.2f, 2f * s);

            using var pen = new Pen(color, stroke)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };
            using var fill = new SolidBrush(color);

            void Line(float x1, float y1, float x2, float y2) =>
                g.DrawLine(pen, x1 * s, y1 * s, x2 * s, y2 * s);
            void Polyline(params float[] pts)
            {
                var points = new PointF[pts.Length / 2];
                for (int i = 0; i < points.Length; i++)
                    points[i] = new PointF(pts[i * 2] * s, pts[i * 2 + 1] * s);
                g.DrawLines(pen, points);
            }
            void Rect(float x, float y, float w, float h, float radius, bool fillIt = false)
            {
                using var path = Theme.RoundedPath(
                    new RectangleF(x * s, y * s, w * s, h * s), radius * s);
                if (fillIt) g.FillPath(fill, path);
                else g.DrawPath(pen, path);
            }
            void Circle(float cx, float cy, float r, bool fillIt = false)
            {
                var rect = new RectangleF((cx - r) * s, (cy - r) * s, r * 2 * s, r * 2 * s);
                if (fillIt) g.FillEllipse(fill, rect);
                else g.DrawEllipse(pen, rect);
            }

            switch (name)
            {
                case Dashboard: // layout-dashboard
                    Rect(3, 3, 18, 18, 3);
                    Line(9, 3, 9, 21);
                    Line(3, 9, 21, 9);
                    break;

                case Transactions: // arrow-left-right
                    Line(3, 8, 21, 8);
                    Polyline(7, 4, 3, 8, 7, 12);
                    Line(21, 16, 3, 16);
                    Polyline(17, 12, 21, 16, 17, 20);
                    break;

                case Categories: // layout-grid
                    Rect(3, 3, 7.5f, 7.5f, 2);
                    Rect(13.5f, 3, 7.5f, 7.5f, 2);
                    Rect(3, 13.5f, 7.5f, 7.5f, 2);
                    Rect(13.5f, 13.5f, 7.5f, 7.5f, 2);
                    break;

                case Reports: // bar-chart-3
                    Line(3, 20, 21, 20);
                    Line(6, 20, 6, 12);
                    Line(12, 20, 12, 5);
                    Line(18, 20, 18, 9);
                    break;

                case Settings: // settings
                    Circle(12, 12, 3.2f);
                    for (int i = 0; i < 8; i++)
                    {
                        double a = i * Math.PI / 4.0;
                        float x1 = 12f + (float)Math.Cos(a) * 6.2f;
                        float y1 = 12f + (float)Math.Sin(a) * 6.2f;
                        float x2 = 12f + (float)Math.Cos(a) * 8.8f;
                        float y2 = 12f + (float)Math.Sin(a) * 8.8f;
                        Line(x1, y1, x2, y2);
                    }
                    break;

                case Wallet:
                    Rect(3, 6, 18, 13, 3);
                    Line(3, 10, 21, 10);
                    Circle(16.5f, 14.5f, 1.2f, true);
                    break;

                case TrendingUp:
                    Polyline(3, 17, 9, 11, 13, 15, 21, 7);
                    Polyline(15, 7, 21, 7, 21, 13);
                    break;

                case TrendingDown:
                    Polyline(3, 7, 9, 13, 13, 9, 21, 17);
                    Polyline(15, 17, 21, 17, 21, 11);
                    break;

                case Receipt:
                    Rect(5, 3, 14, 18, 2);
                    Line(8.5f, 8, 15.5f, 8);
                    Line(8.5f, 12, 15.5f, 12);
                    Line(8.5f, 16, 13f, 16);
                    break;

                case Plus:
                    Line(12, 5, 12, 19);
                    Line(5, 12, 19, 12);
                    break;

                case More:
                    Circle(12, 5, 1.6f, true);
                    Circle(12, 12, 1.6f, true);
                    Circle(12, 19, 1.6f, true);
                    break;

                case Edit: // pencil
                    Polyline(4, 20, 4, 16, 16, 4, 20, 8, 8, 20, 4, 20);
                    Line(14, 6, 18, 10);
                    break;

                case Trash:
                    Line(3, 6, 21, 6);
                    Polyline(9, 6, 9, 4, 15, 4, 15, 6);
                    Polyline(5, 6, 6, 21, 18, 21, 19, 6);
                    Line(10, 10, 10, 17);
                    Line(14, 10, 14, 17);
                    break;

                case User:
                    Circle(12, 8, 4);
                    Polyline(4, 21, 4, 18, 20, 18, 20, 21);
                    break;

                case ChevronDown:
                    Polyline(6, 9, 12, 15, 18, 9);
                    break;

                case ChevronRight:
                    Polyline(9, 6, 15, 12, 9, 18);
                    break;

                case Close:
                    Line(6, 6, 18, 18);
                    Line(18, 6, 6, 18);
                    break;

                case Search:
                    Circle(11, 11, 6);
                    Line(15.5f, 15.5f, 20, 20);
                    break;

                case Layers:
                    Polyline(12, 3, 21, 8, 12, 13, 3, 8, 12, 3);
                    Polyline(3, 12, 12, 17, 21, 12);
                    Polyline(3, 16, 12, 21, 21, 16);
                    break;

                case Sparkles:
                    Polyline(12, 3, 13.4f, 8.6f, 19, 10, 13.4f, 11.4f, 12, 17, 10.6f, 11.4f, 5, 10, 10.6f, 8.6f, 12, 3);
                    Line(18.5f, 16, 18.5f, 20);
                    Line(16.5f, 18, 20.5f, 18);
                    break;

                case Calendar:
                    Rect(3, 5, 18, 16, 3);
                    Line(3, 10, 21, 10);
                    Line(8, 3, 8, 7);
                    Line(16, 3, 16, 7);
                    break;

                case Info:
                    Circle(12, 12, 9);
                    Line(12, 11, 12, 16.5f);
                    Circle(12, 7.8f, 1.1f, true);
                    break;

                case Lock: // lock-keyhole
                    Rect(4, 10, 16, 10, 2.5f);
                    Polyline(8, 10, 8, 7, 12, 4, 16, 7, 16, 10);
                    Circle(12, 14.5f, 1.2f, true);
                    break;

                case Tag: // tag
                    Polyline(3, 3, 3, 11, 11, 21, 21, 11, 13, 3, 3, 3);
                    Circle(7, 7, 1.4f, true);
                    break;

                default:
                    Circle(12, 12, 8);
                    break;
            }

            GC.KeepAlive(pen);
            return bitmap;
        }
    }
}
