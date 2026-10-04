using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// A date input that is drawn from the same parts as every other field in the
    /// app, so it lines up with its siblings instead of looking like a control that
    /// came from somewhere else.
    /// <para>
    /// The platform <see cref="DateTimePicker"/> does the actual work - it brings
    /// the calendar, the keyboard editing and the locale rules - but it has no
    /// restyle hooks at all: no border style, no flat mode, nothing. The only way
    /// to keep its raised edge out of sight is to stop it painting there. So the
    /// picker is inset by <see cref="FrameInset"/> on every side and the band that
    /// leaves behind is filled by this control with the same hairline, fill and
    /// focus ring the sibling inputs use. The picker is also given a
    /// <see cref="DateTimePicker.CustomFormat"/> of literal text while the field is
    /// empty, which is how the muted placeholder is rendered in the picker's own
    /// font and colour rather than being overdrawn.
    /// </para>
    /// <para>
    /// The value is nullable: a goal with no deadline shows a placeholder instead
    /// of silently defaulting to today, which makes "no target date" a real state.
    /// </para>
    /// </summary>
    public class DateField : Control, IDesiredHeight
    {
        private readonly DateTimePicker _picker;
        private readonly IconButton _clear;

        private DateTime? _value;
        private bool _hover;
        private bool _focused;
        private string _placeholder = "No date set";
        private int _clearSize = 24;
        private float _scale = 1f;

        /// <summary>
        /// Band left unpainted by the platform picker, in design pixels. Wide enough
        /// to swallow the picker's raised edge, thin enough that the text does not
        /// visibly shift when the field is engaged.
        /// </summary>
        private const int FrameInset = 3;

        /// <summary>Format used once a date is actually set.</summary>
        private const string DateFormat = "d MMM yyyy";

        /// <summary>Format used when the field is also a time picker.</summary>
        private const string DateTimeFormat = "d MMM yyyy HH:mm";

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
                BackColor = InputChrome.Fill(InputState.Rest),
                ForeColor = InputChrome.TextTint(InputState.Rest),
                Font = Typography.BodyLarge,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = _placeholder,
                CalendarFont = Typography.BodyLarge,
                // The calendar popup is the one part of the platform control we
                // are allowed to restyle, and it is the part the user actually
                // looks at, so it is themed to match the rest of the app.
                CalendarForeColor = Colors.Foreground,
                CalendarMonthBackground = Colors.Surface,
                CalendarTitleBackColor = Theme.Mix(Colors.Surface, Colors.PrimaryOrange, 0.14f),
                CalendarTitleForeColor = Colors.Foreground,
                CalendarTrailingForeColor = Colors.FaintText,
                ShowUpDown = false,
                DropDownAlign = LeftRightAlignment.Left,
                Dock = DockStyle.None,
                Margin = Padding.Empty
            };
            _picker.ValueChanged += Picker_ValueChanged;
            _picker.GotFocus += (_, _) => SetFocused(true);
            _picker.LostFocus += (_, _) => SetFocused(false);
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

            // Picker last so the clear button stays clickable above it.
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
                SyncPicker();
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
                if (_value.HasValue)
                    _value = Normalize(_value.Value);

                SyncPicker();
                Invalidate();
            }
        }

        /// <summary>True while the platform calendar is dropped down.</summary>
        [Browsable(false)]
        public bool IsCalendarOpen => _picker.Focused;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InputState State
        {
            get
            {
                if (!Enabled)
                    return InputState.Disabled;

                if (_focused || _picker.Focused)
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
            ? _value.Value.ToString(ValueFormat, CultureInfo.CurrentCulture)
            : _placeholder;

        public void Clear()
        {
            Value = null;
            SetFocused(false);
        }

        public bool FocusInput()
        {
            if (!Enabled)
                return false;

            SetFocused(true);
            _picker.Focus();
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
            _picker.CalendarFont = Font;
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
            }

            SyncPicker();
            Invalidate();
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

        private void Picker_KeyDown(object? sender, KeyEventArgs e)
        {
            // Escape is the one key that must hand control back to the field.
            if (e.KeyCode == Keys.Escape)
            {
                // Reverting first makes Escape a true cancel: a half-typed date is
                // discarded rather than committed.
                if (_value.HasValue)
                    _picker.Value = _value.Value;

                SetFocused(false);
                _picker.Visible = true;
                Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Picker_ValueChanged(object? sender, EventArgs e)
        {
            if (_value.HasValue && _picker.Value.Date == _value.Value.Date &&
                (_picker.ShowUpDown || _picker.Value.TimeOfDay == _value.Value.TimeOfDay))
            {
                return;
            }

            _value = Normalize(_picker.Value);
            SyncPicker();
            Invalidate();
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>Midnight for a date-only field, the full value when a time is shown.</summary>
        private DateTime Normalize(DateTime value) => _picker.ShowUpDown ? value : value.Date;

        private string ValueFormat => _picker.ShowUpDown ? DateTimeFormat : DateFormat;

        /// <summary>
        /// Pushes the current value into the platform picker and keeps its
        /// appearance in step with the rest of the field. An empty field is shown by
        /// giving the picker a literal custom format, so the placeholder is drawn in
        /// the picker's own font at the right inset instead of being painted over
        /// the top of it.
        /// </summary>
        private void SyncPicker()
        {
            if (_picker == null)
                return;

            if (_value.HasValue)
                _picker.Value = _value.Value;

            _picker.CustomFormat = _value.HasValue ? ValueFormat : _placeholder;

            InputState state = State;
            _picker.BackColor = InputChrome.Fill(state);
            _picker.ForeColor = _value.HasValue
                ? InputChrome.TextTint(state)
                : InputChrome.PlaceholderTint(state);

            // A disabled field has nothing to clear.
            _clear.Visible = Enabled && _value.HasValue;
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            if (_clear == null || _picker == null)
                return;

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            _clearSize = Math.Max(Theme.Scaled(20, scale), _clear.PreferredSize.Width);

            int top = Math.Max(0, (Height - _clearSize) / 2);
            int right = Theme.Scaled(Theme.Space2, scale);
            _clear.SetBounds(Width - _clearSize - right, top, _clearSize, _clearSize);

            // The picker is inset on every side so its raised edge falls inside the
            // band this control paints itself, and is never allowed to leave it.
            int inset = Math.Max(1, Theme.Scaled(FrameInset, scale));
            _picker.SetBounds(
                inset,
                inset,
                Math.Max(1, Width - inset * 2),
                Math.Max(1, Height - inset * 2));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;

            // The picker only ever covers the inside of this rectangle; the frame
            // band around it, and therefore the whole look of the field, is ours.
            InputChrome.Paint(g, InputChrome.Bounds(this, scale), scale, State);
        }

        protected override bool IsInputKey(Keys keyData) => true;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button != MouseButtons.Left || !Enabled)
                return;

            // Clicking the clear button must not also open the calendar.
            if (_clear.Bounds.Contains(e.Location))
                return;

            // The picker is always on screen, so the click is already inside it and
            // the calendar opens from the same gesture that focused the field.
            SetFocused(true);
            _picker.Focus();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Handled || !Enabled)
                return;

            // The standard "open the drop-down" keys, so the calendar is reachable
            // from the keyboard without a pointer.
            if (e.KeyCode == Keys.F4 || e.KeyCode == Keys.Space)
            {
                SetFocused(true);
                _picker.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
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
    }
}
