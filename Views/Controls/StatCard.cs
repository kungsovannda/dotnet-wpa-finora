using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Controls
{
    /// <summary>Visual weight of a stat card.</summary>
    public enum StatTone
    {
        /// <summary>Neutral surface with the orange brand accent (e.g. balance).</summary>
        Neutral,
        Income,
        Expense
    }

    /// <summary>
    /// Dashboard metric card: small label, large amount, supporting line and a
    /// soft icon tile. Income uses a subtle green, expenses a subtle red and the
    /// balance stays neutral with the orange accent - orange is never used as a
    /// large fill.
    /// </summary>
    public partial class StatCard : UserControl
    {
        private StatTone _tone = StatTone.Neutral;
        private string _icon = Icons.Wallet;
        private float _scale = 1f;

        public StatCard()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint |
                     ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            ApplyTheming();
            iconHost.Paint += IconHost_Paint;
            FitRows();
        }

        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Title
        {
            get => lbTitle.Text;
            set
            {
                lbTitle.Text = value ?? string.Empty;
                FitRows();
            }
        }

        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Value
        {
            get => lbValue.Text;
            set
            {
                lbValue.Text = value ?? string.Empty;
                FitRows();
            }
        }

        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Support
        {
            get => lbSupport.Text;
            set
            {
                lbSupport.Text = value ?? string.Empty;
                FitRows();
            }
        }

        [Category("Appearance")]
        [DefaultValue(Icons.Wallet)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Icon
        {
            get => _icon;
            set
            {
                _icon = value ?? string.Empty;
                iconHost.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(StatTone.Neutral)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public StatTone Tone
        {
            get => _tone;
            set
            {
                _tone = value;
                ApplyTheming();
                Invalidate();
            }
        }

        public void SetValue(string value, string? support = null)
        {
            Value = value;
            if (support != null)
                Support = support;
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            FitRows();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            FitRows();
        }

        /// <summary>
        /// Rows 0, 1 and 3 are absolute and sized from the labels themselves, so
        /// the amount and the supporting line can never be squeezed or pushed
        /// into the card padding. Row 2 absorbs the slack, which keeps the
        /// supporting line a consistent distance below the amount. The card's
        /// <see cref="Control.MinimumSize"/> is raised to whatever the current
        /// content needs, so an over-squeezed layout is impossible.
        /// </summary>
        private const int TitleRowHeight = 28;

        /// <summary>Gap kept between the amount and the supporting line.</summary>
        private const int SupportGap = 4;

        private bool _fitting;

        private void FitRows()
        {
            if (_fitting || content == null || lbValue == null || lbSupport == null || lbTitle == null)
                return;

            _fitting = true;
            try
            {
                int titleRow = Math.Max(TitleRowHeight, Math.Max(lbTitle.PreferredHeight, 1));
                int value = Math.Max(lbValue.PreferredHeight, 1);
                bool hasSupport = !string.IsNullOrEmpty(lbSupport.Text);
                int support = hasSupport ? Math.Max(lbSupport.PreferredHeight, 1) + SupportGap : 0;

                // Never let the fixed rows exceed the available content height.
                int available = content.Height > 0
                    ? content.Height
                    : Height - Padding.Vertical;
                if (available > 0 && titleRow + value + support > available)
                {
                    support = Math.Max(0, available - titleRow - value);
                    hasSupport = support > 0;
                }

                if (content.RowStyles[0].Height != titleRow)
                    content.RowStyles[0].Height = titleRow;
                if (content.RowStyles[1].Height != value)
                    content.RowStyles[1].Height = value;
                if (content.RowStyles[3].Height != support)
                    content.RowStyles[3].Height = support;

                if (lbSupport.Visible != hasSupport)
                    lbSupport.Visible = hasSupport;

                // Grow (never shrink) the floor so the rows always fit.
                int needed = titleRow + value + support + Padding.Vertical;
                if (needed > MinimumSize.Height)
                    MinimumSize = new Size(MinimumSize.Width, needed);
            }
            finally
            {
                _fitting = false;
            }
        }

        private void ApplyTheming()
        {
            BackColor = Colors.Background;
            lbValue.ForeColor = _tone switch
            {
                StatTone.Income => Colors.Success,
                StatTone.Expense => Colors.Danger,
                _ => Colors.Foreground
            };
            iconHost.Invalidate();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
            FitRows();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            FitRows();
        }

        private void IconHost_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            int tile = Theme.Scaled(28, scale);
            int radius = Theme.Scaled(Theme.RadiusMd, scale);
            var rect = new RectangleF(
                Math.Max(0, (iconHost.Width - tile) / 2f),
                Math.Max(0, (iconHost.Height - tile) / 2f),
                tile, tile);

            using (var brush = new SolidBrush(TileFill()))
            using (var path = Theme.RoundedPath(rect, radius))
            {
                g.FillPath(brush, path);
            }

            int glyph = Theme.Scaled(16, scale);
            Icons.DrawCentered(g, _icon, glyph, rect, IconColor());
        }

        private Color TileFill() => _tone switch
        {
            StatTone.Income => Colors.SuccessSoft,
            StatTone.Expense => Colors.DangerSoft,
            _ => Colors.PrimarySoft
        };

        private Color IconColor() => _tone switch
        {
            StatTone.Income => Colors.Success,
            StatTone.Expense => Colors.Danger,
            _ => Colors.PrimaryOrange
        };

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            float radius = Theme.Scaled(Theme.RadiusLg, scale);
            var rect = new RectangleF(0, 0, Width, Height - scale);

            Color fill;
            Color border;
            switch (_tone)
            {
                case StatTone.Income:
                    fill = Theme.Mix(Colors.Surface, Colors.SuccessSoft, 0.35f);
                    border = Theme.Mix(Colors.Border, Colors.SuccessBorder, 0.75f);
                    break;
                case StatTone.Expense:
                    fill = Theme.Mix(Colors.Surface, Colors.DangerSoft, 0.30f);
                    border = Theme.Mix(Colors.Border, Colors.DangerBorder, 0.75f);
                    break;
                default:
                    fill = Colors.Surface;
                    border = Colors.Border;
                    break;
            }

            Theme.PaintSurface(g, rect, radius, fill, border, scale, shadow: true);

            if (_tone == StatTone.Neutral)
            {
                // Slim brand accent on the leading edge.
                var accent = new RectangleF(rect.X + radius, rect.Y, Theme.Scaled(28, scale), Theme.Scaled(3, scale));
                using var brush = new SolidBrush(Colors.PrimaryOrange);
                using var path = Theme.RoundedPath(accent, Theme.Scaled(2, scale));
                g.FillPath(brush, path);
            }

            base.OnPaint(e);
        }
    }
}
