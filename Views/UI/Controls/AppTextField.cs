using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// Rounded bordered text input with placeholder text, an optional leading
    /// adornment and the shared focus ring. Wraps the native TextBox so all
    /// keyboard behaviour (selection, IME, clipboard, undo) stays native.
    /// </summary>
    public class AppTextField : Control, IDesiredHeight
    {
        private readonly TextBox _input;
        private readonly Label _placeholderLabel;
        private string _placeholder = string.Empty;
        private string _leadingIcon = string.Empty;
        private float _scale = 1f;
        private bool _focused;
        private bool _hover;

        /// <summary>Taller height a multiline field asks for, in design pixels.</summary>
        private const int MultilineHeight = 96;

        /// <summary>
        /// Height the field wants, or -1 for the standard single-line height.
        /// <see cref="Control.Height"/> cannot be used for this: a docked parent
        /// overwrites it with the row height.
        /// </summary>
        private int _desiredHeight = -1;

        public AppTextField()
        {
            // Create the child controls first: setting properties such as Font
            // or Height raises OnFontChanged / OnLayout, which forward to them.
            _input = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = InputChrome.Fill(InputState.Rest),
                ForeColor = InputChrome.TextTint(InputState.Rest),
                Font = Typography.BodyLarge,
                TextAlign = HorizontalAlignment.Left,
                AcceptsTab = false
            };

            _placeholderLabel = new Label
            {
                AutoSize = false,
                BackColor = InputChrome.Fill(InputState.Rest),
                ForeColor = Colors.FaintText,
                Font = Typography.BodyLarge,
                TextAlign = ContentAlignment.MiddleLeft,
                Visible = false
            };

            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            BackColor = InputChrome.Fill(InputState.Rest);
            ForeColor = Colors.Foreground;
            Font = Typography.BodyLarge;
            Cursor = Cursors.IBeam;
            Height = Theme.Scaled(Theme.InputHeight, 1f);
            TabStop = false;

            _input.TextChanged += (_, _) =>
            {
                OnTextChanged(EventArgs.Empty);
                UpdatePlaceholder();
            };
            _input.GotFocus += (_, _) =>
            {
                _focused = true;
                OnGotFocus(EventArgs.Empty);
                UpdatePlaceholder();
                ApplyChrome();
            };
            _input.LostFocus += (_, _) =>
            {
                _focused = false;
                OnLostFocus(EventArgs.Empty);
                UpdatePlaceholder();
                ApplyChrome();
            };
            _input.MouseEnter += (_, _) => SetHover(true);
            _input.MouseLeave += (_, _) => SetHover(false);
            _placeholderLabel.MouseEnter += (_, _) => SetHover(true);
            _placeholderLabel.MouseLeave += (_, _) => SetHover(false);
            _placeholderLabel.MouseDown += (_, _) => _input.Focus();

            Controls.Add(_input);
            Controls.Add(_placeholderLabel);
        }

        /// <summary>Value of the wrapped input.</summary>
        [Category("Data")]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new string Text
        {
            get => _input.Text;
            set => _input.Text = value ?? string.Empty;
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string Placeholder
        {
            get => _placeholder;
            set
            {
                _placeholder = value ?? string.Empty;
                _placeholderLabel.Text = _placeholder;
                UpdatePlaceholder();
                Invalidate();
            }
        }

        /// <summary>Optional icon drawn inside the field, before the text.</summary>
        [Category("Appearance")]
        [DefaultValue("")]
        public string LeadingIcon
        {
            get => _leadingIcon;
            set
            {
                _leadingIcon = value ?? string.Empty;
                PerformLayout();
                Invalidate();
            }
        }

        [Category("Behavior")]
        [DefaultValue(false)]
        public bool Multiline
        {
            get => _input.Multiline;
            set
            {
                _input.Multiline = value;
                if (value)
                {
                    float scale = Theme.ScaleOf(this);
                    _desiredHeight = Theme.Scaled(MultilineHeight, scale);
                    if (Height < _desiredHeight)
                        Height = _desiredHeight;
                }
                else
                {
                    _desiredHeight = -1;
                    int standard = Theme.Scaled(Theme.InputHeight, _scale <= 0 ? Theme.ScaleOf(this) : _scale);
                    if (Height > standard)
                        Height = standard;
                }

                ApplyInputFont();
                PerformLayout();
            }
        }

        /// <summary>
        /// Height the field asks its host for. A multiline field wants room for
        /// several lines; a single-line field wants the standard input height.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DesiredHeight
        {
            get
            {
                float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
                if (_desiredHeight > 0)
                    return _desiredHeight;

                // Never smaller than one line of text plus the field padding.
                int single = _input.PreferredHeight + Theme.Scaled(Theme.Space2, scale) * 2;
                return Math.Max(single, Theme.Scaled(Theme.InputHeight, scale));
            }
        }

        [Category("Behavior")]
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get => _input.ReadOnly;
            set => _input.ReadOnly = value;
        }

        [Category("Behavior")]
        [DefaultValue(false)]
        public bool IsPassword
        {
            get => _input.UseSystemPasswordChar;
            set => _input.UseSystemPasswordChar = value;
        }

        [Category("Behavior")]
        [DefaultValue(0)]
        public int MaxLength
        {
            get => _input.MaxLength;
            set => _input.MaxLength = value;
        }

        /// <summary>Exposes the native control (focus and key handling only).</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TextBox Input => _input;

        /// <summary>Current interaction state, used by the shared chrome painter.</summary>
        public InputState State
        {
            get
            {
                if (!Enabled)
                    return InputState.Disabled;

                if (_focused || _input.Focused)
                    return InputState.Focus;

                return _hover ? InputState.Hover : InputState.Rest;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
            ApplyInputFont();
            UpdatePlaceholder();
            ApplyChrome();
        }

        private void ApplyInputFont()
        {
            _input.Font = Font;
            _placeholderLabel.Font = Font;
            UpdatePlaceholder();
        }

        private void UpdatePlaceholder()
        {
            _placeholderLabel.Visible =
                !string.IsNullOrEmpty(_placeholder) &&
                string.IsNullOrEmpty(_input.Text);
        }

        /// <summary>Re-applies the state dependent fill to the native children.</summary>
        private void ApplyChrome()
        {
            if (_input == null || _placeholderLabel == null)
                return;

            Color fill = InputChrome.Fill(State);
            BackColor = fill;
            _input.BackColor = fill;
            _placeholderLabel.BackColor = fill;
            _input.ForeColor = InputChrome.TextTint(State);
            _input.ReadOnly = ReadOnly;
            Invalidate();
        }

        private void SetHover(bool hover)
        {
            if (_hover == hover)
                return;

            _hover = hover;
            ApplyChrome();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (_input == null || _placeholderLabel == null)
                return;

            _input.Font = Font;
            _placeholderLabel.Font = Font;
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            if (_input == null || _placeholderLabel == null)
                return;

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            int padX = Theme.Scaled(InputChrome.PaddingX, scale);
            int padY = Theme.Scaled(Theme.Space2, scale);
            bool hasIcon = !string.IsNullOrEmpty(_leadingIcon);

            int left = padX;
            if (hasIcon)
            {
                left += Theme.Scaled(InputChrome.IconSize, scale) +
                        Theme.Scaled(InputChrome.IconGap, scale);
            }

            int width = Math.Max(0, Width - left - padX);

            if (_input.Multiline)
            {
                int height = Math.Max(0, Height - padY * 2);
                _input.SetBounds(left, padY, width, height);
                _placeholderLabel.SetBounds(left, padY, width, height);
                _placeholderLabel.TextAlign = ContentAlignment.TopLeft;
            }
            else
            {
                int inputHeight = _input.PreferredHeight;
                int y = Math.Max(0, (Height - inputHeight) / 2);
                _input.SetBounds(left, y, width, inputHeight);
                _placeholderLabel.SetBounds(left, y, width, inputHeight);
                _placeholderLabel.TextAlign = ContentAlignment.MiddleLeft;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            var rect = InputChrome.Bounds(this, scale);

            InputChrome.Paint(g, rect, scale, State);

            if (string.IsNullOrEmpty(_leadingIcon))
                return;

            int size = Theme.Scaled(InputChrome.IconSize, scale);
            var iconBounds = new RectangleF(
                Theme.Scaled(InputChrome.PaddingX, scale),
                (Height - size) / 2f, size, size);
            Icons.DrawCentered(g, _leadingIcon, size, iconBounds, InputChrome.IconTint(State));
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            SetHover(true);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            SetHover(false);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left && Enabled)
                _input.Focus();
        }

        /// <summary>Moves keyboard focus to the wrapped input.</summary>
        public bool FocusInput()
        {
            if (IsDisposed || !Enabled)
                return false;

            return _input.Focus();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (_input == null)
                return;

            _input.Enabled = Enabled;
            if (!Enabled)
            {
                _focused = false;
                _hover = false;
            }

            ApplyChrome();
        }
    }
}
