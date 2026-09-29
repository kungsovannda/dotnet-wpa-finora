using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// Consistent form row: caption, input and optional hint, using the standard
    /// 8px rhythm shared by every Finora dialog.
    /// </summary>
    public class FormField : UserControl
    {
        private readonly TableLayoutPanel _layout;
        private readonly Label _caption;
        private readonly Label _hint;
        private Control? _input;

        public FormField()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Margin = Padding.Empty;
            Padding = Padding.Empty;

            _caption = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = Typography.Label,
                ForeColor = Colors.SecondaryText,
                Text = "Label",
                BackColor = Color.Transparent,
                Margin = Padding.Empty
            };

            _hint = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = Typography.Caption,
                ForeColor = Colors.MutedText,
                Visible = false,
                BackColor = Color.Transparent,
                Margin = new Padding(0, Theme.Space1, 0, 0)
            };

            _layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = Color.Transparent,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                GrowStyle = TableLayoutPanelGrowStyle.AddRows
            };
            _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, Theme.Scaled(CaptionHeight, 1f)));
            _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, Theme.Scaled(Theme.InputHeight, 1f)));
            _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
            _layout.Controls.Add(_caption, 0, 0);
            _layout.Controls.Add(_hint, 0, 2);

            Controls.Add(_layout);
        }

        /// <summary>Row height of the caption; tall enough for the label font.</summary>
        private const int CaptionHeight = 22;

        /// <summary>Row height of the hint line when it is shown.</summary>
        private const int HintHeight = 20;

        [Category("Data")]
        [DefaultValue("Label")]
        public string Caption
        {
            get => _caption.Text;
            set => _caption.Text = value ?? string.Empty;
        }

        [Category("Data")]
        [DefaultValue("")]
        public string Hint
        {
            get => _hint.Text;
            set
            {
                _hint.Text = value ?? string.Empty;
                _hint.Visible = !string.IsNullOrEmpty(value);
                SyncCaptionHeight();
                PerformLayout();
            }
        }

        /// <summary>Input control shown between the caption and the hint.</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control? Input
        {
            get => _input;
            set
            {
                if (_input != null)
                    _layout.Controls.Remove(_input);

                _input = value;
                if (value != null)
                {
                    value.Dock = DockStyle.Fill;
                    value.Margin = Padding.Empty;
                    _layout.Controls.Add(value, 0, 1);
                    SyncInputHeight();
                }

                PerformLayout();
            }
        }

        /// <summary>Height the input asks for, or 0 when there is no input.</summary>
        private int InputDesiredHeight =>
            _input is IDesiredHeight sized ? sized.DesiredHeight : _input?.Height ?? 0;

        /// <summary>
        /// Re-reads the input height. Reads the input's requested height rather
        /// than <see cref="Control.Height"/>, which the layout engine overwrites
        /// with the row height and which would otherwise pin a multiline field
        /// to a single line.
        /// </summary>
        public void SyncInputHeight()
        {
            int desired = InputDesiredHeight;
            if (desired > 0 && Math.Abs(_layout.RowStyles[1].Height - desired) >= 0.5F)
                _layout.RowStyles[1].Height = desired;
        }

        /// <summary>
        /// Sizes the caption and hint rows from the real preferred height of
        /// their labels, so neither can ever be clipped - at any DPI.
        /// </summary>
        private void SyncCaptionHeight()
        {
            if (_caption == null || _hint == null)
                return;

            float scale = Theme.ScaleOf(this);
            float caption = Math.Max(_caption.PreferredHeight, Theme.Scaled(CaptionHeight, scale));
            if (_layout.RowStyles[0].Height != caption)
                _layout.RowStyles[0].Height = caption;

            float hint = _hint.Visible
                ? Math.Max(_hint.PreferredHeight, Theme.Scaled(HintHeight, scale))
                : 0F;
            if (_layout.RowStyles[2].Height != hint)
                _layout.RowStyles[2].Height = hint;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SyncCaptionHeight();
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            SyncCaptionHeight();

            int desired = InputDesiredHeight;
            if (desired > 0 && Math.Abs(_layout.RowStyles[1].Height - desired) >= 0.5F)
                SyncInputHeight();
        }
    }
}
