using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// A labelled share of a total: name, proportional bar, amount. Used by the
    /// category, payment-method and month reports. The bar length is a share of
    /// the largest row in the group, so the biggest spender is always full width.
    /// </summary>
    public class ReportBarRow : Control
    {
        private readonly Label _nameLabel;
        private readonly Label _detailLabel;
        private readonly Label _amountLabel;
        private readonly Panel _track;
        private readonly TableLayoutPanel _layout;
        private readonly TableLayoutPanel _barRow;

        private Color _barColor = Colors.PrimaryOrange;
        private decimal _share;

        public ReportBarRow()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;

            _nameLabel = new Label
            {
                Dock = DockStyle.Fill,
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = Typography.BodySemibold,
                ForeColor = Colors.Foreground,
                BackColor = Color.Transparent,
                Text = "Label",
                Margin = Padding.Empty
            };

            _detailLabel = new Label
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = Typography.Caption,
                ForeColor = Colors.MutedText,
                BackColor = Color.Transparent,
                Text = string.Empty,
                Margin = new Padding(Theme.Space2, 0, 0, 0)
            };

            _amountLabel = new Label
            {
                Dock = DockStyle.Fill,
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleRight,
                Font = Typography.Amount,
                ForeColor = Colors.Foreground,
                BackColor = Color.Transparent,
                Text = "$0.00",
                Margin = new Padding(Theme.Space3, 0, 0, 0)
            };

            _track = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Margin = Padding.Empty
            };
            _track.Paint += Track_Paint;

            _barRow = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent,
                Margin = Padding.Empty
            };
            _barRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _barRow.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            _barRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _barRow.Controls.Add(_track, 0, 0);
            _barRow.Controls.Add(_amountLabel, 1, 0);

            var captions = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent,
                Margin = Padding.Empty
            };
            captions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            captions.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            captions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            captions.Controls.Add(_nameLabel, 0, 0);
            captions.Controls.Add(_detailLabel, 1, 0);

            _layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.Transparent,
                Margin = Padding.Empty
            };
            _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, Theme.Scaled(8, 1f)));

            _layout.Controls.Add(captions, 0, 0);
            _layout.Controls.Add(_barRow, 0, 1);

            Size = new Size(320, 40);
            Margin = Padding.Empty;
            Cursor = Cursors.Default;

            Controls.Add(_layout);
        }

        [Category("Appearance")]
        [DefaultValue("Label")]
        public string ItemName
        {
            get => _nameLabel.Text;
            set => _nameLabel.Text = value ?? string.Empty;
        }

        /// <summary>Muted secondary caption beside the name, e.g. "12 transactions".</summary>
        [Category("Appearance")]
        [DefaultValue("")]
        public string Detail
        {
            get => _detailLabel.Text;
            set => _detailLabel.Text = value ?? string.Empty;
        }

        [Category("Appearance")]
        [DefaultValue("$0.00")]
        public string AmountText
        {
            get => _amountLabel.Text;
            set => _amountLabel.Text = value ?? string.Empty;
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BarColor
        {
            get => _barColor;
            set
            {
                _barColor = value;
                _track.Invalidate();
            }
        }

        /// <summary>0-100 share used for the bar length.</summary>
        [Category("Appearance")]
        [DefaultValue(0)]
        public decimal Share
        {
            get => _share;
            set
            {
                _share = value < 0m ? 0m : value > 100m ? 100m : value;
                _track.Invalidate();
            }
        }

        private void Track_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            int radius = Math.Max(1, _track.Height / 2);
            using (var track = new SolidBrush(Colors.ChartTrack))
            {
                g.FillPath(track, Theme.RoundedPath(new RectangleF(0, 0, _track.Width, _track.Height), radius));
            }

            int filled = (int)Math.Round(_track.Width * (float)(_share / 100m));
            if (filled <= 0)
                return;

            if (filled < _track.Height * 2)
                filled = Math.Min(_track.Height * 2, _track.Width);

            using (var bar = new SolidBrush(_barColor))
            {
                g.FillPath(bar, Theme.RoundedPath(new RectangleF(0, 0, filled, _track.Height), radius));
            }
        }
    }
}
