using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// Rounded bordered wrapper around the native ComboBox. Keeps the native
    /// drop-down behaviour (including <see cref="ComboBoxStyle.DropDownList"/>)
    /// and adds the shared field chrome plus a crisp custom chevron.
    /// </summary>
    public class AppComboField : Control, IDesiredHeight
    {
        private readonly FlatComboBox _combo;
        private readonly Panel _chevron;
        private float _scale = 1f;
        private bool _focused;
        private bool _hover;

        /// <summary>
        /// Height the field asks its host for: the standard input height, but
        /// never less than the drop-down list needs for one item.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DesiredHeight
        {
            get
            {
                float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
                int standard = Theme.Scaled(Theme.InputHeight, scale);
                return Math.Max(standard, _combo.PreferredHeight + Theme.Scaled(2, scale));
            }
        }

        public AppComboField()
        {
            // Create the child combo first: setting properties such as Font or
            // Height raises OnFontChanged / OnLayout, which forward to it.
            _combo = new FlatComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                BackColor = InputChrome.Fill(InputState.Rest),
                ForeColor = InputChrome.TextTint(InputState.Rest),
                Font = Typography.BodyLarge,
                DrawMode = DrawMode.Normal
            };

            _chevron = new Panel
            {
                BackColor = InputChrome.Fill(InputState.Rest),
                TabStop = false
            };
            _chevron.Paint += Chevron_Paint;
            _chevron.MouseDown += (_, e) =>
            {
                if (e.Button == MouseButtons.Left && Enabled)
                    _combo.DroppedDown = true;
            };

            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            BackColor = InputChrome.Fill(InputState.Rest);
            ForeColor = Colors.Foreground;
            Font = Typography.BodyLarge;
            Cursor = Cursors.Hand;
            Height = Theme.Scaled(Theme.InputHeight, 1f);
            TabStop = false;

            _combo.GotFocus += (_, _) => SetFocusState(true);
            _combo.LostFocus += (_, _) => SetFocusState(false);
            _combo.MouseEnter += (_, _) => SetHover(true);
            _combo.MouseLeave += (_, _) => SetHover(false);
            _chevron.MouseEnter += (_, _) => SetHover(true);
            _chevron.MouseLeave += (_, _) => SetHover(false);

            Controls.Add(_combo);
            Controls.Add(_chevron);
        }

        [Category("Behavior")]
        [DefaultValue(ComboBoxStyle.DropDownList)]
        public ComboBoxStyle DropDownStyle
        {
            get => _combo.DropDownStyle;
            set => _combo.DropDownStyle = value;
        }

        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ComboBox.ObjectCollection Items => _combo.Items;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object? SelectedItem
        {
            get => _combo.SelectedItem;
            set => _combo.SelectedItem = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get => _combo.SelectedIndex;
            set => _combo.SelectedIndex = value;
        }

        [Category("Data")]
        [DefaultValue("")]
        public string DisplayMember
        {
            get => _combo.DisplayMember;
            set => _combo.DisplayMember = value;
        }

        [Category("Data")]
        [DefaultValue("")]
        public string ValueMember
        {
            get => _combo.ValueMember;
            set => _combo.ValueMember = value;
        }

        /// <summary>Data source for list-bound combo boxes (kept native).</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object? DataSource
        {
            get => _combo.DataSource;
            set => _combo.DataSource = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ComboBox Combo => _combo;

        [Browsable(false)]
        public event EventHandler? SelectedIndexChanged
        {
            add => _combo.SelectedIndexChanged += value;
            remove => _combo.SelectedIndexChanged -= value;
        }

        /// <summary>Current interaction state, used by the shared chrome painter.</summary>
        public InputState State
        {
            get
            {
                if (!Enabled)
                    return InputState.Disabled;

                if (_focused || _combo.Focused)
                    return InputState.Focus;

                return _hover ? InputState.Hover : InputState.Rest;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
            if (_combo.IsHandleCreated)
                UnthemeCombo();
            ApplyChrome();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (_combo.IsHandleCreated)
                RepaintCombo();
            base.OnHandleDestroyed(e);
        }

        /// <summary>
        /// Removes the visual-styles theme from the native combo. Themed combos
        /// paint their own border and button around the whole client area, which
        /// draws a hard rectangle inside the rounded field.
        /// </summary>
        private void UnthemeCombo()
        {
            try
            {
                SetWindowTheme(_combo.Handle, null, null);
            }
            catch (Exception)
            {
                // Theming is cosmetic only - never fail because of it.
            }
        }

        private void RepaintCombo()
        {
            try
            {
                SetWindowTheme(_combo.Handle, "ComboBox", null);
            }
            catch (Exception)
            {
                // Ignored.
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (_combo != null)
                _combo.Font = Font;
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            if (_combo == null || _chevron == null)
                return;

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            int inset = Theme.Scaled(1, scale);
            int left = Theme.Scaled(InputChrome.PaddingX, scale);
            int arrowZone = Theme.Scaled(InputChrome.ArrowZone, scale);
            int radius = Theme.Scaled(Theme.RadiusMd, scale);

            // A ComboBox derives its own height from the font metrics and
            // silently overrides whatever height it is handed, so it can never be
            // made to fill a 40px field. Centre it vertically instead: the text
            // is then optically centred and the leftover band shows the field's
            // own fill, which is the same colour, so the seam is invisible.
            int comboRight = Math.Max(left + arrowZone, Width - radius);
            int inner = Math.Max(0, Height - inset * 2);
            int width = Math.Max(0, comboRight - left);

            _combo.SetBounds(left, inset, width, inner);
            int natural = _combo.Height;
            _combo.SetBounds(left, Math.Max(0, (Height - natural) / 2), width, natural);

            // The native arrow always ends up under the custom chevron, and
            // nothing is allowed to paint over the trailing corner arc.
            int chevronLeft = Math.Max(left, comboRight - arrowZone);
            _chevron.SetBounds(chevronLeft, inset, Math.Max(0, comboRight - chevronLeft), inner);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            InputChrome.Paint(g, InputChrome.Bounds(this, scale), scale, State);
        }

        private void Chevron_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            int size = Theme.Scaled(14, scale);
            Icons.DrawCentered(g, Icons.ChevronDown, size, _chevron.ClientRectangle, Colors.MutedText);
        }

        private void ApplyChrome()
        {
            if (_combo == null || _chevron == null)
                return;

            Color fill = InputChrome.Fill(State);
            BackColor = fill;
            _combo.BackColor = fill;
            _chevron.BackColor = fill;
            _combo.ForeColor = InputChrome.TextTint(State);
            _chevron.Invalidate();
            Invalidate();
        }

        private void SetFocusState(bool focused)
        {
            if (_focused == focused)
                return;

            _focused = focused;
            if (focused)
            {
                OnGotFocus(EventArgs.Empty);
            }
            else
            {
                OnLostFocus(EventArgs.Empty);
            }

            ApplyChrome();
        }

        private void SetHover(bool hover)
        {
            if (_hover == hover)
                return;

            _hover = hover;
            ApplyChrome();
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
                _combo.Focus();
        }

        /// <summary>Moves keyboard focus to the wrapped combo box.</summary>
        public bool FocusInput()
        {
            if (IsDisposed || !Enabled)
                return false;

            return _combo.Focus();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (_combo == null)
                return;

            _combo.Enabled = Enabled;
            if (!Enabled)
            {
                _focused = false;
                _hover = false;
            }

            ApplyChrome();
        }

        /// <summary>
        /// ComboBox without the non-client border Windows draws for
        /// <see cref="FlatStyle.Flat"/>, so only the rounded host is visible.
        /// </summary>
        private sealed class FlatComboBox : ComboBox
        {
            private const int WM_NCPAINT = 0x0085;

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_NCPAINT)
                {
                    m.Result = IntPtr.Zero;
                    return;
                }

                base.WndProc(ref m);
            }
        }

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int SetWindowTheme(IntPtr hwnd, string? subAppName, string? subIdList);
    }
}
