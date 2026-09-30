using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
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
    /// Presentation-only card for the Saving Goals page. One goal per full-width
    /// row, sized to read as a line in a list rather than a panel.
    /// <para>
    /// The row is three blocks on one optical centre line: a small identity block
    /// on the left (emoji, name, one quiet line of metadata), a thin progress line
    /// that fills the width that is left, and the actions at the right. Every
    /// block is placed by hand in <see cref="OnLayout"/> rather than by a
    /// TableLayoutPanel, because every layout engine stretches a child to fill
    /// its cell - and a stretched progress bar is a panel, not a line.
    /// </para>
    /// <para>
    /// Everything it shows is pushed in from the response DTO, and the only thing
    /// it emits is which affordance the user activated. All decisions - progress,
    /// remaining amount, whether a goal is overdue - arrive already made by the
    /// domain.
    /// </para>
    /// </summary>
    public class SavingGoalCard : UserControl
    {
        /// <summary>Height of the painted card, in design pixels.</summary>
        public const int CardHeight = 76;

        /// <summary>Height the host gives a row: the card plus the gap below it.</summary>
        public const int RowPitch = CardHeight + Theme.Space2;

        /// <summary>Width of the left-hand identity block, in design pixels.</summary>
        public const int IdentityColumn = 268;

        /// <summary>Gap between the identity block, the progress line and the actions.</summary>
        public const int ColumnGap = Theme.Space4;

        private const int TrackThickness = 6;
        private const int EmojiSize = 34;
        private const int MenuSize = 28;
        private const int ActionGap = Theme.Space2;
        private const int PadX = Theme.Space4;
        private const int PadY = Theme.Space3;

        private readonly EmojiTile _emoji;
        private readonly IconButton _menu;
        private readonly Label _nameLabel;
        private readonly Label _metaLine;
        private readonly Label _percentLabel;
        private readonly Label _remainingLabel;
        private readonly ProgressTrack _progress;
        private readonly TypeBadge _status;
        private readonly AppButton _contribute;

        private long _id;
        private string _amountsText = string.Empty;
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
                Anchor = AnchorStyles.None,
                BackColor = Color.Transparent
            };
            _emoji.MouseEnter += (_, _) => SetHover(true);
            _emoji.MouseLeave += (_, _) => SetHover(false);

            _menu = new IconButton
            {
                Icon = Icons.More,
                IconSize = Theme.IconSize,
                Anchor = AnchorStyles.None,
                BackColor = Color.Transparent
            };
            _menu.Click += (_, _) => Raise(GoalAction.Menu);
            _menu.MouseEnter += (_, _) => SetHover(true);
            _menu.MouseLeave += (_, _) => SetHover(false);

            _nameLabel = new Label
            {
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = Typography.BodyLarge,
                ForeColor = Colors.Foreground,
                BackColor = Color.Transparent,
                Text = "Saving goal",
                Anchor = AnchorStyles.None,
                Margin = Padding.Empty
            };

            // "$1,200 of $3,000  ·  Target 12 Mar 2027" - the one quiet line of
            // metadata under the name. Both halves are optional, so the line drops
            // whatever the goal does not have.
            _metaLine = new Label
            {
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = Typography.Caption,
                ForeColor = Colors.MutedText,
                BackColor = Color.Transparent,
                Text = string.Empty,
                Anchor = AnchorStyles.None,
                Margin = Padding.Empty
            };

            _status = new TypeBadge
            {
                Text = "In Progress",
                // Placed by hand in OnLayout: the badge text changes width with
                // the status, and only the name knows how much room the pill can
                // have without pushing the metadata out of the column.
                AutoSize = false,
                Anchor = AnchorStyles.None,
                Margin = Padding.Empty
            };

            _progress = new ProgressTrack
            {
                Anchor = AnchorStyles.None,
                Margin = Padding.Empty
            };

            // "42%" - flush with the end of the line, so the figure reads as the
            // reading of the bar rather than as a caption floating mid-row.
            _percentLabel = new Label
            {
                AutoSize = false,
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleRight,
                Font = Typography.CaptionMedium,
                ForeColor = Colors.MutedText,
                BackColor = Color.Transparent,
                Text = "0%",
                Anchor = AnchorStyles.None,
                Margin = Padding.Empty
            };

            // "$1,800 to go" - kept on the same baseline as the percentage, at the
            // far end of the line it belongs to.
            _remainingLabel = new Label
            {
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = Typography.Caption,
                ForeColor = Colors.MutedText,
                BackColor = Color.Transparent,
                Text = string.Empty,
                Anchor = AnchorStyles.None,
                Margin = Padding.Empty
            };

            _contribute = new AppButton
            {
                Caption = "Add money",
                Variant = AppButtonVariant.Secondary,
                Icon = Icons.Plus,
                AutoWidth = true,
                Anchor = AnchorStyles.None,
                BackColor = Color.Transparent,
                Margin = Padding.Empty
            };
            _contribute.Click += (_, _) => Raise(GoalAction.Contribute);
            _contribute.MouseEnter += (_, _) => SetHover(true);
            _contribute.MouseLeave += (_, _) => SetHover(false);

            Controls.Add(_emoji);
            Controls.Add(_nameLabel);
            Controls.Add(_metaLine);
            Controls.Add(_status);
            Controls.Add(_progress);
            Controls.Add(_remainingLabel);
            Controls.Add(_percentLabel);
            Controls.Add(_contribute);
            Controls.Add(_menu);

            // A row, so it fills the list cell it is placed in. The margin is the
            // gap between rows - the list owns the pitch, not the card.
            Dock = DockStyle.Fill;
            Margin = new Padding(0, 0, 0, Theme.Space2);

            // Applied after the children exist: it triggers OnLayout, which
            // positions them.
            Size = new Size(880, CardHeight);
            Font = Typography.Body;
            Cursor = Cursors.Default;

            PerformLayout();
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
            get => _amountsText;
            set
            {
                _amountsText = value ?? string.Empty;
                RefreshMetaLine();
            }
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string RemainingText
        {
            get => _remainingLabel.Text;
            set => _remainingLabel.Text = value ?? string.Empty;
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string TargetText
        {
            get => _targetText;
            set
            {
                _targetText = value ?? string.Empty;
                RefreshMetaLine();
            }
        }

        /// <summary>
        /// Joins the money and the deadline into the single quiet line under the
        /// name. Both halves are optional, so the line drops whatever the goal does
        /// not have rather than leaving a dangling separator.
        /// </summary>
        private void RefreshMetaLine()
        {
            if (_metaLine == null)
                return;

            string[] parts = new[] { _amountsText, _targetText }
                .Where(part => !string.IsNullOrWhiteSpace(part))
                .ToArray();

            _metaLine.Text = string.Join("  \u00b7  ", parts);
            _metaLine.Visible = _metaLine.Text.Length > 0;
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

            // The name, the pill and the percentage all changed width, so the
            // hand-placed row has to be measured again.
            PerformLayout();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            PerformLayout();
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            if (_emoji == null || _contribute == null || _progress == null)
                return;

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;

            int left = Theme.Scaled(PadX, scale);
            int top = Theme.Scaled(PadY, scale);
            int width = Math.Max(0, ClientSize.Width - left * 2);
            int height = Math.Max(0, ClientSize.Height - top * 2);

            // The identity column is a fixed slice so the progress line always
            // starts at the same place down the list and every bar is comparable;
            // the line takes the room that is left over.
            int identity = Math.Min(Theme.Scaled(IdentityColumn, scale), width);
            int gap = Theme.Scaled(ColumnGap, scale);
            int menu = Theme.Scaled(MenuSize, scale);

            // The button's slot is reserved whether or not the goal still takes
            // contributions: a list whose bars start in one place but end in
            // another reads as ragged, and an archived goal should not be the row
            // that breaks the rhythm.
            int actions = menu + _contribute.Width + Theme.Scaled(ActionGap, scale);

            int lineLeft = left + identity + gap;
            int lineWidth = Math.Max(0, left + width - actions - gap - lineLeft);

            LayoutIdentity(left, top, identity, height, scale);
            LayoutProgress(lineLeft, top, lineWidth, height, scale);
            LayoutActions(left + width - actions, top, actions, height, menu, scale);
        }

        /// <summary>
        /// The emoji tile and the two lines of text, centred on the row as one
        /// block. The tile keeps its square: a stretched tile stops being a tile.
        /// </summary>
        private void LayoutIdentity(int left, int top, int width, int height, float scale)
        {
            int tile = Math.Min(Theme.Scaled(EmojiSize, scale), height);
            _emoji.SetBounds(left, top + (height - tile) / 2, tile, tile);

            int textLeft = left + tile + Theme.Scaled(Theme.Space3, scale);
            int box = Math.Max(0, left + width - textLeft);

            int nameHeight = Math.Max(_nameLabel.PreferredHeight, Theme.Scaled(18, scale));
            int metaHeight = _metaLine.Visible
                ? Math.Max(_metaLine.PreferredHeight, Theme.Scaled(14, scale))
                : 0;
            int metaGap = Theme.Scaled(Theme.Space1, scale);

            // Measured with the metadata line and then without: a goal with no
            // target date centres on its name alone instead of leaving a hole.
            int block = nameHeight + (metaHeight > 0 ? metaGap + metaHeight : 0);
            int blockTop = top + Math.Max(0, (height - block) / 2);

            var pill = _status.GetPreferredSize(Size.Empty);
            int pillGap = Theme.Scaled(Theme.Space2, scale);
            int nameText = TextRenderer.MeasureText(
                _nameLabel.Text, _nameLabel.Font, Size.Empty, TextFormatFlags.NoPadding).Width;

            // The pill sits on the name's baseline, just past the end of the text.
            // It only appears when the name keeps a readable length of its own, and
            // the name gives up the room it needs so the two can never collide.
            bool showPill = box > pill.Width + pillGap + Theme.Scaled(56, scale);
            int nameWidth = showPill
                ? Math.Max(0, Math.Min(nameText, box - pill.Width - pillGap))
                : box;

            _nameLabel.SetBounds(textLeft, blockTop, nameWidth, nameHeight);

            if (metaHeight > 0)
                _metaLine.SetBounds(textLeft, blockTop + nameHeight + metaGap, box, metaHeight);
            else
                _metaLine.SetBounds(textLeft, blockTop + nameHeight, box, 0);

            _status.Visible = showPill;
            if (showPill)
            {
                _status.SetBounds(
                    textLeft + nameWidth + pillGap,
                    blockTop + (nameHeight - pill.Height) / 2,
                    pill.Width,
                    pill.Height);
            }
        }

        /// <summary>
        /// The line spans the column at a fixed thickness with the shortfall and
        /// the percentage on one caption row beneath it - the percentage flush
        /// with the end of the line, the shortfall taking what is left. The stack
        /// sits on the optical middle of the row, which is why it is placed by
        /// hand: a table cell would grow the bar to fill whatever height it was
        /// given, and a bar that stretches is not a line.
        /// </summary>
        private void LayoutProgress(int left, int top, int width, int height, float scale)
        {
            if (width <= 0)
            {
                _progress.SetBounds(left, top, 0, 0);
                _percentLabel.SetBounds(left, top, 0, 0);
                _remainingLabel.SetBounds(left, top, 0, 0);
                return;
            }

            int thickness = Theme.Scaled(TrackThickness, scale);
            int gap = Theme.Scaled(Theme.Space2, scale);
            int captionHeight = Math.Max(
                _percentLabel.PreferredHeight,
                Theme.Scaled(14, scale));

            int stack = thickness + gap + captionHeight;
            int barTop = top + Math.Max(0, (height - stack) / 2);

            _progress.SetBounds(left, barTop, width, thickness);

            int captionTop = barTop + thickness + gap;
            int percentWidth = Math.Min(_percentLabel.PreferredSize.Width, width);
            _percentLabel.SetBounds(left + width - percentWidth, captionTop, percentWidth, captionHeight);

            // The shortfall only earns its place once the column is wide enough to
            // hold it without crowding the percentage.
            int shortfall = Math.Max(0, width - percentWidth - Theme.Scaled(Theme.Space3, scale));
            _remainingLabel.Visible = shortfall >= Theme.Scaled(48, scale);
            _remainingLabel.SetBounds(left, captionTop, shortfall, captionHeight);
        }

        /// <summary>
        /// The actions, vertically centred and pinned to the right edge. The slot
        /// is laid out even when the button is hidden, so the row keeps its
        /// rhythm.
        /// </summary>
        private void LayoutActions(int left, int top, int width, int height, int menu, float scale)
        {
            if (_contribute.Visible)
            {
                int button = Math.Min(_contribute.Height, height);
                _contribute.SetBounds(
                    left,
                    top + (height - button) / 2,
                    _contribute.Width,
                    button);
            }

            _menu.SetBounds(left + width - menu, top + (height - menu) / 2, menu, menu);
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
