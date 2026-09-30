using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    public class GoalActionEventArgs : EventArgs
    {
        public GoalActionEventArgs(long id, GoalAction action)
        {
            Id = id;
            Action = action;
        }

        public long Id { get; }

        public GoalAction Action { get; }
    }

    public enum GoalAction
    {
        Menu,
        Contribute,
        Details
    }

    /// <summary>
    /// Presentation-only card for the Saving Goals page: one goal per full-width
    /// row, with the identity on the left, the money in the middle and the
    /// progress bar taking whatever room is left. Everything it shows is pushed
    /// in from the response DTO, and the only thing it emits is which affordance
    /// the user activated. All decisions - progress, remaining amount, whether a
    /// goal is overdue - arrive already made by the domain.
    /// </summary>
    public class SavingGoalCard : UserControl
    {
        /// <summary>Row height in design pixels; the width comes from the host.</summary>
        public const int CardHeight = 104;

        private const int IdentityColumn = 320;
        private const int AmountsColumn = 250;
        private const int TrackThickness = 10;
        private const int EmojiSize = 44;

        private readonly TableLayoutPanel _layout;
        private readonly Panel _identityText;
        private readonly EmojiTile _emoji;
        private readonly IconButton _menu;
        private readonly Label _nameLabel;
        private readonly Label _amountsLabel;
        private readonly ProgressTrack _progress;
        private readonly Label _percentLabel;
        private readonly Label _remainingLabel;
        private readonly Label _targetLabel;
        private readonly TypeBadge _status;
        private readonly AppButton _contribute;

        private long _id;
        private string _remainingText = string.Empty;
        private string _targetText = string.Empty;
        private float _scale = 1f;
        private bool _hover;

        public SavingGoalCard()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Colors.Background;

            _emoji = new EmojiTile
            {
                Glyph = Emoji.DefaultCategory,
                EmojiSize = 21F,
                Size = new Size(Theme.Scaled(EmojiSize, 1f), Theme.Scaled(EmojiSize, 1f))
            };
            _emoji.MouseEnter += (_, _) => SetHover(true);
            _emoji.MouseLeave += (_, _) => SetHover(false);

            _menu = new IconButton
            {
                Icon = Icons.More,
                IconSize = Theme.IconSize,
                Size = new Size(Theme.Scaled(28, 1f), Theme.Scaled(28, 1f)),
                BackColor = Color.Transparent
            };
            _menu.Click += (_, _) => Raise(GoalAction.Menu);
            _menu.MouseEnter += (_, _) => SetHover(true);
            _menu.MouseLeave += (_, _) => SetHover(false);

            _nameLabel = new Label
            {
                Dock = DockStyle.Fill,
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = Typography.HeadingSmall,
                ForeColor = Colors.Foreground,
                BackColor = Color.Transparent,
                Text = "Saving goal",
                Margin = Padding.Empty
            };

            _status = new TypeBadge
            {
                Text = "In Progress",
                // Sized by hand in OnLayout: the badge text changes width with the
                // status, and a docked or auto-sized badge inside a percent cell
                // would drift to the top instead of staying on the text baseline.
                AutoSize = false,
                Margin = Padding.Empty
            };

            _amountsLabel = new Label
            {
                Dock = DockStyle.Fill,
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = Typography.Amount,
                ForeColor = Colors.Foreground,
                BackColor = Color.Transparent,
                Text = "$0 of $0",
                Margin = Padding.Empty
            };

            _targetLabel = new Label
            {
                Dock = DockStyle.Fill,
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = Typography.BodySmall,
                ForeColor = Colors.MutedText,
                BackColor = Color.Transparent,
                Text = string.Empty,
                Margin = new Padding(0, 0, 0, 0)
            };

            _progress = new ProgressTrack
            {
                // Anchored rather than docked: the track spans the column but keeps
                // a bar's proportions instead of stretching the full half-row.
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
                Size = new Size(200, Theme.Scaled(TrackThickness, 1f)),
                Margin = Padding.Empty
            };

            _percentLabel = new Label
            {
                Dock = DockStyle.Fill,
                AutoSize = false,
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = Typography.CaptionMedium,
                ForeColor = Colors.MutedText,
                BackColor = Color.Transparent,
                Text = "0%",
                Margin = Padding.Empty
            };

            _remainingLabel = new Label
            {
                Dock = DockStyle.Fill,
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleRight,
                Font = Typography.BodySmall,
                ForeColor = Colors.SecondaryText,
                BackColor = Color.Transparent,
                Text = string.Empty,
                Margin = Padding.Empty
            };

            _contribute = new AppButton
            {
                Caption = "Add money",
                Variant = AppButtonVariant.Secondary,
                Icon = Icons.Plus,
                AutoWidth = true,
                BackColor = Color.Transparent,
                Margin = Padding.Empty
            };
            _contribute.Click += (_, _) => Raise(GoalAction.Contribute);
            _contribute.MouseEnter += (_, _) => SetHover(true);
            _contribute.MouseLeave += (_, _) => SetHover(false);

            // Identity: emoji on the left, then the name stacked over the status
            // pill. The stack is laid out by hand in OnLayout so the name and the
            // pill stay as a single centred block against the emoji.
            _identityText = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Margin = Padding.Empty
            };

            var identity = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, Theme.Space5, 0)
            };
            identity.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, EmojiSize + Theme.Space3));
            identity.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            identity.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            identity.Controls.Add(_emoji, 0, 0);
            identity.Controls.Add(_identityText, 1, 0);

            // Money: the running total over the deadline.
            var amounts = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, Theme.Space5, 0)
            };
            amounts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            amounts.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            amounts.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            amounts.Controls.Add(_amountsLabel, 0, 0);
            amounts.Controls.Add(_targetLabel, 0, 1);

            // Progress: the track sits on the vertical centre of the row, with
            // the percentage and the shortfall beneath it.
            var progressLabels = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent,
                Margin = Padding.Empty
            };
            progressLabels.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            progressLabels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            progressLabels.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            progressLabels.Controls.Add(_percentLabel, 0, 0);
            progressLabels.Controls.Add(_remainingLabel, 1, 0);

            var progress = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, Theme.Space5, 0)
            };
            progress.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            progress.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            progress.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            progress.Controls.Add(_progress, 0, 0);
            progress.Controls.Add(progressLabels, 0, 1);

            // Actions: a single right-aligned cluster, vertically centred.
            var actions = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent,
                Margin = Padding.Empty
            };
            actions.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            actions.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            actions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            actions.Controls.Add(_contribute, 0, 0);
            actions.Controls.Add(_menu, 1, 0);

            // Vertically centred in the row without giving up the caption-driven
            // width the button sizes itself to.
            _contribute.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            _menu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;

            _layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1,
                BackColor = Color.Transparent,
                Padding = new Padding(Theme.Space4, Theme.Space3, Theme.Space3, Theme.Space3),
                Margin = new Padding(0, 0, 0, Theme.Space3)
            };
            _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, IdentityColumn));
            _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, AmountsColumn));
            _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            _layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _layout.Controls.Add(identity, 0, 0);
            _layout.Controls.Add(amounts, 1, 0);
            _layout.Controls.Add(progress, 2, 0);
            _layout.Controls.Add(actions, 3, 0);

            // Applied after the children exist: it triggers OnLayout, which
            // positions them.
            Size = new Size(Theme.Scaled(880, 1f), Theme.Scaled(CardHeight, 1f));
            Font = Typography.Body;
            Cursor = Cursors.Default;

            Controls.Add(_layout);
        }

        public event EventHandler<GoalActionEventArgs>? ActionRequested;

        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public long Id
        {
            get => _id;
            set
            {
                _id = value;
                Tag = value;
            }
        }

        [Category("Appearance")]
        [DefaultValue("Saving goal")]
        public string GoalName
        {
            get => _nameLabel.Text;
            set => _nameLabel.Text = value ?? string.Empty;
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string EmojiGlyph
        {
            get => _emoji.Glyph;
            set
            {
                string normalized = Emoji.Normalize(value);
                _emoji.Glyph = string.IsNullOrEmpty(normalized) ? Emoji.DefaultCategory : normalized;
            }
        }

        [Category("Appearance")]
        [DefaultValue(0)]
        public decimal ProgressPercentage
        {
            get => _progress.Value;
            set
            {
                _progress.Value = value;
                _percentLabel.Text = $"{value:0.#}%";
            }
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string AmountSummary
        {
            get => _amountsLabel.Text;
            set => _amountsLabel.Text = value ?? string.Empty;
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string RemainingText
        {
            get => _remainingText;
            set
            {
                _remainingText = value ?? string.Empty;
                _remainingLabel.Text = _remainingText;
            }
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string TargetText
        {
            get => _targetText;
            set
            {
                _targetText = value ?? string.Empty;
                _targetLabel.Text = _targetText;
            }
        }

        [Category("Appearance")]
        [DefaultValue(SavingGoalStatus.IN_PROGRESS)]
        public SavingGoalStatus Status
        {
            get => _status.Tag is SavingGoalStatus status ? status : SavingGoalStatus.IN_PROGRESS;
            set
            {
                _status.Tag = value;
                _progress.Completed = value == SavingGoalStatus.COMPLETED;

                switch (value)
                {
                    case SavingGoalStatus.COMPLETED:
                        _status.Text = "Completed";
                        _status.Accent = Colors.Success;
                        _status.Fill = Colors.SuccessSoft;
                        _emoji.TileColor = Colors.SuccessSoft;
                        _percentLabel.ForeColor = Colors.Success;
                        break;

                    case SavingGoalStatus.OVERDUE:
                        _status.Text = "Overdue";
                        _status.Accent = Colors.Danger;
                        _status.Fill = Colors.DangerSoft;
                        _emoji.TileColor = Colors.DangerSoft;
                        _percentLabel.ForeColor = Colors.Danger;
                        break;

                    case SavingGoalStatus.ARCHIVED:
                        _status.Text = "Archived";
                        _status.Accent = Colors.MutedText;
                        _status.Fill = Colors.SurfaceSunken;
                        _emoji.TileColor = Colors.SurfaceSunken;
                        _percentLabel.ForeColor = Colors.MutedText;
                        break;

                    default:
                        _status.Text = "In Progress";
                        _status.Accent = Colors.Warning;
                        _status.Fill = Colors.WarningSoft;
                        _emoji.TileColor = Colors.WarningSoft;
                        _percentLabel.ForeColor = Colors.MutedText;
                        break;
                }

                // A retired goal takes no more deposits.
                _contribute.Visible = value != SavingGoalStatus.ARCHIVED;
                PerformLayout();
                _identityText?.PerformLayout();
            }
        }

        /// <summary>Pushes every value from a goal response in one go.</summary>
        public void Bind(SavingGoalResponseDto goal)
        {
            Id = goal.Id;
            GoalName = goal.Name;
            EmojiGlyph = goal.Emoji;
            Status = goal.Status;
            ProgressPercentage = goal.ProgressPercentage;
            AmountSummary = string.Format(
                CultureInfo.CurrentCulture,
                "{0} of {1}",
                goal.CurrentAmount.ToString("C", CultureInfo.CurrentCulture),
                goal.TargetAmount.ToString("C", CultureInfo.CurrentCulture));

            RemainingText = goal.RemainingAmount <= 0m
                ? "Goal reached"
                : string.Format(
                    CultureInfo.CurrentCulture,
                    "{0} to go",
                    goal.RemainingAmount.ToString("C", CultureInfo.CurrentCulture));

            TargetText = goal.TargetDate.HasValue
                ? "Target " + goal.TargetDate.Value.ToString("d MMM yyyy", CultureInfo.CurrentCulture)
                : "No target date";
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
            ApplyTrackThickness();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            _layout?.PerformLayout();
        }

        private void ApplyTrackThickness()
        {
            if (_progress == null)
                return;

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            int thickness = Theme.Scaled(TrackThickness, scale);
            if (_progress.Height == thickness)
                return;

            _progress.Height = thickness;
            _progress.Invalidate();
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            if (_identityText == null || _nameLabel == null || _status == null)
                return;

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            int gap = Theme.Scaled(Theme.Space1, scale);

            int nameHeight = Math.Max(_nameLabel.PreferredHeight, Theme.Scaled(20, scale));
            var badge = _status.GetPreferredSize(Size.Empty);
            int badgeHeight = Math.Max(badge.Height, Theme.Scaled(20, scale));
            int badgeWidth = Math.Min(badge.Width, Math.Max(0, _identityText.ClientSize.Width));

            // One centred block: name, gap, pill. Everything else in the row is
            // anchored to the same optical middle.
            int block = nameHeight + gap + badgeHeight;
            int top = Math.Max(0, (_identityText.ClientSize.Height - block) / 2);

            _nameLabel.SetBounds(0, top, _identityText.ClientSize.Width, nameHeight);
            _status.SetBounds(0, top + nameHeight + gap, badgeWidth, badgeHeight);
        }

        private void SetHover(bool hover)
        {
            if (_hover == hover)
                return;

            _hover = hover;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            SetHover(true);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            SetHover(false);
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            int radius = Theme.Scaled(Theme.RadiusLg, scale);
            float lift = _hover ? -1f * scale : 0f;
            var rect = new RectangleF(0, lift, Width, Height - scale);

            Color border = _hover
                ? Theme.Mix(Colors.Border, Colors.PrimaryOrange, 0.5f)
                : Colors.Border;

            Theme.PaintSurface(g, rect, radius, Colors.Surface, border, scale, shadow: true);
        }

        private void Raise(GoalAction action)
        {
            ActionRequested?.Invoke(this, new GoalActionEventArgs(_id, action));
        }
    }
}
