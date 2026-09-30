using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// A date input painted with the same chrome, inset and type as every other
    /// field in the app. The platform picker is kept for its calendar, typing and
    /// locale behaviour, but it is only revealed while the user is actually
    /// choosing a date; the rest of the time the field paints itself, so its text
    /// lands on the same baseline as the text fields beside it.
    /// <para>
    /// The value is nullable: a goal with no deadline shows a muted placeholder
    /// instead of silently defaulting to today, which makes "no target date" a
    /// real state.
    /// </para>
    /// </summary>
    public class DateField : Control, IDesiredHeight
    {
        private readonly DateTimePicker _picker;
        private readonly IconButton _clear;

        private DateTime? _value;
        private bool _hover;
        private bool _focused;
        private bool _picking;
        private string _placeholder = "No date set";
        private int _clearSize = 24;
        private float _scale = 1f;

        /// <summary>Width reserved on the trailing edge for the calendar glyph.</summary>
        private const int AffordanceGap = 8;

        public DateField()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.Selectable |
                     ControlStyles.UserPaint, true);

            BackColor = InputChrome.Fill(InputState.Rest);
            Font = Typography.BodyLarge;
            ForeColor = InputChrome.TextTint(InputState.Rest);
            Cursor = Cursors.Hand;
            Padding = Padding.Empty;
            TabStop = true;

            _picker = new DateTimePicker
            {
                // The platform picker always paints its own 3D frame and cannot be
                // restyled, so it is only ever shown while the user is choosing a
                // date. Everything else is painted by this control, which is what
                // keeps the resting field identical to its sibling inputs.
                BackColor = InputChrome.Fill(InputState.Focus),
                ForeColor = InputChrome.TextTint(InputState.Focus),
                Font = Typography.BodyLarge,
                CustomFormat = "d MMM yyyy",
                Format = DateTimePickerFormat.Custom,
                ShowUpDown = false,
                // Hidden until the field is activated, then laid exactly over the
                // input rect so the two cannot disagree about where text starts.
                Dock = DockStyle.None,
                Visible = false,
                Margin = Padding.Empty
            };
            _picker.ValueChanged += Picker_ValueChanged;
            _picker.GotFocus += (_, _) => { _picking = true; Invalidate(); };
            _picker.LostFocus += (_, _) => SetPicking(false);
            _picker.KeyDown += Picker_KeyDown;

            _clear = new IconButton
            {
                Icon = Icons.Close,
                IconSize = 12,
                TabStop = false,
                Cursor = Cursors.Hand,
                // The clear button sits on top of the painted field, so it must
                // not erase the chrome behind itself.
                BackColor = Color.Transparent
            };
            _clear.Click += (_, _) => Clear();
            _clear.MouseEnter += (_, _) => SetHover(true);
            _clear.MouseLeave += (_, _) => SetHover(false);

            Controls.Add(_picker);
            Controls.Add(_clear);

            Height = Theme.Scaled(Theme.InputHeight, 1f);
        }

        public event EventHandler? ValueChanged;

        [Category("Behavior")]
        [DefaultValue(null)]
        public DateTime? Value
        {
            get => _value;
            set
            {
                DateTime? next = value.HasValue ? Normalize(value.Value) : null;
                if (_value == next)
                    return;

                _value = next;
                SyncPicker();
                Invalidate();
                ValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        [Category("Appearance")]
        [DefaultValue("No date set")]
        public string Placeholder
        {
            get => _placeholder;
            set
            {
                _placeholder = value ?? string.Empty;
                Invalidate();
            }
        }

        [Category("Behavior")]
        [DefaultValue(false)]
        public bool HasValue => _value.HasValue;

        /// <summary>
        /// Turns the field into a date and time picker. Off by default, because a
        /// deadline only needs a day.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool ShowTime
        {
            get => _picker.ShowUpDown;
            set
            {
                if (_picker.ShowUpDown == value)
                    return;

                _picker.ShowUpDown = value;
                _picker.CustomFormat = value ? "d MMM yyyy HH:mm" : "d MMM yyyy";
                if (_value.HasValue)
                    _value = Normalize(_value.Value);

                SyncPicker();
                Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InputState State
        {
            get
            {
                if (!Enabled)
                    return InputState.Disabled;

                if (_focused || _picking || _picker.Focused)
                    return InputState.Focus;

                return _hover ? InputState.Hover : InputState.Rest;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DesiredHeight
        {
            get
            {
                float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
                return Theme.Scaled(Theme.InputHeight, scale);
            }
        }

        /// <summary>Formatted value as shown on the field.</summary>
        [Browsable(false)]
        public string DisplayText => _value.HasValue
            ? _value.Value.ToString(_picker.CustomFormat, System.Globalization.CultureInfo.CurrentCulture)
            : _placeholder;

        public void Clear()
        {
            Value = null;
            SetPicking(false);
            SetFocused(false);
        }

        public bool FocusInput()
        {
            if (!Enabled)
                return false;

            // Choosing a date is the only way into this field, so focusing it
            // seeds the picker with a sensible default and reveals it.
            if (!_value.HasValue)
                _value = Normalize(_picker.Value);

            SyncPicker();
            Invalidate();
            ValueChanged?.Invoke(this, EventArgs.Empty);

            SetFocused(true);
            BeginPicking();
            return true;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
            SyncPicker();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (_picker == null)
                return;

            _picker.Font = Font;
        }

        private void SetHover(bool hover)
        {
            if (_hover == hover)
                return;

            _hover = hover;
            Invalidate();
        }

        private void SetFocused(bool focused)
        {
            if (_focused == focused)
                return;

            _focused = focused;
            Invalidate();
        }

        /// <summary>
        /// Shows the native picker exactly over the painted field, so the calendar
        /// appears without the field changing size or position.
        /// </summary>
        private void BeginPicking()
        {
            if (_picking || !Enabled)
                return;

            if (IsHandleCreated)
            {
                _picking = true;
                SyncPicker();
                _picker.Focus();
            }

            Invalidate();
        }

        private void SetPicking(bool picking)
        {
            if (_picking == picking)
                return;

            _picking = picking;
            SyncPicker();
            Invalidate();
        }

        private void Picker_KeyDown(object? sender, KeyEventArgs e)
        {
            // Escape is the one key that must hand control back to the field.
            if (e.KeyCode == Keys.Escape)
            {
                _picker.Value = _value ?? _picker.Value;
                SetPicking(false);
                Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Picker_ValueChanged(object? sender, EventArgs e)
        {
            _value = Normalize(_picker.Value);
            SyncPicker();
            Invalidate();
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>Midnight for a date-only field, the full value when a time is shown.</summary>
        private DateTime Normalize(DateTime value) => _picker.ShowUpDown ? value : value.Date;

        private void SyncPicker()
        {
            if (_picker == null)
                return;

            if (_value.HasValue)
                _picker.Value = _value.Value;

            _picker.Visible = _picking;
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            if (_clear == null)
                return;

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            _clearSize = Math.Max(Theme.Scaled(20, scale), _clear.PreferredSize.Width);

            int top = Math.Max(0, (Height - _clearSize) / 2);
            int right = Theme.Scaled(Theme.Space2, scale);
            _clear.SetBounds(Width - _clearSize - right, top, _clearSize, _clearSize);

            if (!_picker.Visible)
                return;

            var rect = InputChrome.Bounds(this, scale);
            _picker.SetBounds(
                (int)Math.Round(rect.X),
                (int)Math.Round(rect.Y),
                Math.Max(1, (int)Math.Round(rect.Width)),
                Math.Max(1, (int)Math.Round(rect.Height)));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            InputState state = State;

            // While the native picker is up it draws its own border over this
            // area, so only the fill is laid down underneath it.
            if (_picking)
            {
                using (var fill = new SolidBrush(InputChrome.Fill(InputState.Focus)))
                    g.FillRectangle(fill, ClientRectangle);
            }
            else
            {
                InputChrome.Paint(g, InputChrome.Bounds(this, scale), scale, state);
            }

            int right = Theme.Scaled(Theme.Space2, scale) + _clearSize;
            int padX = Theme.Scaled(InputChrome.PaddingX, scale);
            var text = new RectangleF(
                padX, 0,
                Math.Max(0f, Width - padX - right),
                Height);

            Theme.DrawText(g, DisplayText, Font, text,
                _value.HasValue ? InputChrome.TextTint(state) : InputChrome.PlaceholderTint(state),
                StringAlignment.Near);

            if (_picking)
                return;

            // Trailing affordance so the field reads as a picker, not a label.
            int glyph = Theme.Scaled(16, scale);
            int glyphLeft = _clear.Bounds.Left - Theme.Scaled(AffordanceGap, scale) - glyph;
            var iconBounds = new RectangleF(glyphLeft, (Height - glyph) / 2f, glyph, glyph);
            Icons.DrawCentered(g, Icons.Calendar, glyph, iconBounds, InputChrome.IconTint(state));
        }

        protected override bool IsInputKey(Keys keyData) => true;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button != MouseButtons.Left || !Enabled)
                return;

            if (_picking)
            {
                // Let the click reach the picker that is already up.
                return;
            }

            // Clicking the clear button must not also open the calendar.
            if (_clear.Bounds.Contains(e.Location))
                return;

            Focus();
            FocusInput();
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

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            SetFocused(true);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            SetFocused(false);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (_picker == null)
                return;

            _picker.Enabled = Enabled;
            if (!Enabled)
            {
                _hover = false;
                _focused = false;
                _picking = false;
                _picker.Visible = false;
            }

            Invalidate();
        }
    }
}
