using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>Carries the category id from a card to the page that owns the logic.</summary>
    public class CategoryActionEventArgs : EventArgs
    {
        public CategoryActionEventArgs(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }

    /// <summary>
    /// Presentation-only card used by the Categories page. It renders a category
    /// (emoji, name, description, income/expense indicator) and raises
    /// <see cref="MenuRequested"/> when the "..." affordance is activated.
    /// It never touches controllers, services or repositories - the page wires
    /// the event to the existing category edit/delete logic.
    /// </summary>
    public class CategoryCard : UserControl
    {
        private readonly TableLayoutPanel _layout;
        private readonly Panel _header;
        private readonly EmojiTile _emoji;
        private readonly IconButton _menu;
        private readonly Label _nameLabel;
        private readonly Label _descriptionLabel;
        private readonly TypeBadge _badge;

        private long _id;
        private string _descriptionText = string.Empty;
        private bool _isIncome;
        private float _scale = 1f;
        private bool _hover;

        public CategoryCard()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Colors.Background;

            _emoji = new EmojiTile
            {
                Glyph = Emoji.DefaultExpense,
                EmojiSize = 21F,
                Size = new Size(Theme.Scaled(44, 1f), Theme.Scaled(44, 1f))
            };

            _menu = new IconButton
            {
                Icon = Icons.More,
                IconSize = Theme.IconSize,
                Size = new Size(Theme.Scaled(28, 1f), Theme.Scaled(28, 1f))
            };
            _menu.Click += (_, _) => OnMenuRequested(new CategoryActionEventArgs(_id));

            _header = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Margin = Padding.Empty
            };
            _header.Controls.Add(_emoji);
            _header.Controls.Add(_menu);
            _header.MouseEnter += (_, _) => SetHover(true);
            _header.MouseLeave += (_, _) => SetHover(false);
            _emoji.MouseEnter += (_, _) => SetHover(true);

            _nameLabel = new Label
            {
                Dock = DockStyle.Fill,
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = Typography.HeadingSmall,
                ForeColor = Colors.Foreground,
                BackColor = Color.Transparent,
                Text = "Category",
                Margin = Padding.Empty
            };

            _descriptionLabel = new Label
            {
                Dock = DockStyle.Fill,
                AutoEllipsis = true,
                TextAlign = ContentAlignment.TopLeft,
                Font = Typography.Caption,
                BackColor = Color.Transparent,
                Text = string.Empty,
                Margin = Padding.Empty
            };

            _badge = new TypeBadge
            {
                Text = "Expense",
                Anchor = AnchorStyles.Left,
                Margin = Padding.Empty
            };

            _layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                BackColor = Color.Transparent,
                Padding = new Padding(Theme.Space4),
                Margin = Padding.Empty
            };
            _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, Theme.Scaled(44, 1f)));
            _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, Theme.Scaled(26, 1f)));
            _layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, Theme.Scaled(24, 1f)));

            _layout.Controls.Add(_header, 0, 0);
            _layout.Controls.Add(_nameLabel, 0, 1);
            _layout.Controls.Add(_descriptionLabel, 0, 2);
            _layout.Controls.Add(_badge, 0, 3);

            // Apply sizing only after the children exist: it triggers OnLayout,
            // which positions them.
            Size = new Size(Theme.Scaled(236, 1f), Theme.Scaled(146, 1f));
            Margin = new Padding(Theme.Space1);
            Font = Typography.Body;
            Cursor = Cursors.Default;

            Controls.Add(_layout);
        }

        /// <summary>Raised when the card's "..." affordance is activated.</summary>
        public event EventHandler<CategoryActionEventArgs>? MenuRequested;

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
        [DefaultValue("Category")]
        public string CategoryName
        {
            get => _nameLabel.Text;
            set => _nameLabel.Text = value ?? string.Empty;
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string DescriptionText
        {
            get => _descriptionText;
            set
            {
                _descriptionText = value ?? string.Empty;
                bool empty = string.IsNullOrWhiteSpace(_descriptionText);
                _descriptionLabel.Text = empty ? "No description" : _descriptionText;
                _descriptionLabel.ForeColor = empty ? Colors.FaintText : Colors.MutedText;
            }
        }

        /// <summary>Category emoji (normalised; falls back to a neutral glyph).</summary>
        [Category("Appearance")]
        [DefaultValue("")]
        public string EmojiGlyph
        {
            get => _emoji.Glyph;
            set
            {
                string normalized = Emoji.Normalize(value);
                _emoji.Glyph = string.IsNullOrEmpty(normalized) ? Emoji.Fallback(_isIncome) : normalized;
            }
        }

        [Category("Appearance")]
        [DefaultValue(false)]
        public bool IsIncome
        {
            get => _isIncome;
            set
            {
                _isIncome = value;
                _badge.Text = value ? "Income" : "Expense";
                _badge.Accent = value ? Colors.Success : Colors.Danger;
                _badge.Fill = value ? Colors.SuccessSoft : Colors.DangerSoft;
                _emoji.TileColor = value ? Colors.SuccessSoft : Colors.SurfaceSunken;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
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

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            int size = Theme.Scaled(44, scale);
            _emoji.SetBounds(0, 0, size, size);
            _menu.SetBounds(_header.ClientSize.Width - Theme.Scaled(28, scale), 0,
                            Theme.Scaled(28, scale), Theme.Scaled(28, scale));
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

        protected virtual void OnMenuRequested(CategoryActionEventArgs e) => MenuRequested?.Invoke(this, e);
    }
}
