using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// One line of the dashboard's goal summary: name, how far along it is, and
    /// the figure that matters. Presentation only.
    /// </summary>
    public class GoalProgressRow : Control
    {
        private const int BarHeight = 6;

        private readonly Label _nameLabel;
        private readonly Label _valueLabel;
        private readonly ProgressTrack _bar;
        private readonly TableLayoutPanel _layout;

        private decimal _progress;

        public GoalProgressRow()
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
                Text = "Goal",
                Margin = Padding.Empty
            };

            _valueLabel = new Label
            {
                Dock = DockStyle.Fill,
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleRight,
                Font = Typography.CaptionMedium,
                ForeColor = Colors.MutedText,
                BackColor = Color.Transparent,
                Text = string.Empty,
                Margin = Padding.Empty
            };

            _bar = new ProgressTrack
            {
                Dock = DockStyle.Fill,
                Margin = Padding.Empty
            };

            var captions = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent,
                Margin = Padding.Empty
            };
            captions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            captions.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            captions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            captions.Controls.Add(_nameLabel, 0, 0);
            captions.Controls.Add(_valueLabel, 1, 0);

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
            _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, BarHeight + 4));

            _layout.Controls.Add(captions, 0, 0);
            _layout.Controls.Add(_bar, 0, 1);

            Size = new Size(240, 34);
            Margin = Padding.Empty;
            Cursor = Cursors.Default;

            Controls.Add(_layout);
        }

        [Category("Appearance")]
        [DefaultValue("Goal")]
        public string GoalName
        {
            get => _nameLabel.Text;
            set => _nameLabel.Text = value ?? string.Empty;
        }

        [Category("Appearance")]
        [DefaultValue(0)]
        public decimal ProgressPercentage
        {
            get => _progress;
            set
            {
                _progress = value;
                _bar.Value = value;
            }
        }

        /// <summary>Right-hand caption, e.g. "21.3% of $4,000".</summary>
        [Category("Appearance")]
        [DefaultValue("")]
        public string Caption
        {
            get => _valueLabel.Text;
            set => _valueLabel.Text = value ?? string.Empty;
        }

        [Category("Appearance")]
        [DefaultValue(false)]
        public bool Completed
        {
            get => _bar.Completed;
            set => _bar.Completed = value;
        }

        public void Bind(SavingGoalResponseDto goal)
        {
            GoalName = goal.Name;
            ProgressPercentage = goal.ProgressPercentage;
            Completed = goal.Status == Domains.SavingGoalStatus.COMPLETED;
            Caption = string.Format(
                CultureInfo.CurrentCulture,
                "{0:0.#}% of {1}",
                goal.ProgressPercentage,
                goal.TargetAmount.ToString("C", CultureInfo.CurrentCulture));
        }
    }
}
