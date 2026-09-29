using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// Single-glyph emoji input. Renders the value as a large colour emoji via
    /// GDI+ (the only combination WinForms offers that keeps the colour font),
    /// accepts direct typing / paste, backspace, arrow-free editing and raises
    /// <see cref="Control.Click"/> so a dialog can open the picker next to it.
    /// Maximum two grapheme clusters, mirroring <see cref="Emoji.Normalize"/>.
    /// </summary>
    public class EmojiInput : Control, IDesiredHeight
    {
        private string _glyph = string.Empty;
        private float _scale = 1f;
        private bool _hover;
        private bool _focused;
        private const int MaxClusters = 2;

        public EmojiInput()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.Selectable, true);

            BackColor = InputChrome.Fill(InputState.Rest);
            Font = Typography.BodyLarge;
            Cursor = Cursors.Hand;
            TabStop = true;
            Height = Theme.Scaled(Theme.InputHeight, 1f);
        }

        /// <summary>Height the field asks its host for.</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DesiredHeight
        {
            get
            {
                float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
                int standard = Theme.Scaled(Theme.InputHeight, scale);
                int glyph = Theme.Scaled(24, scale) + Theme.Scaled(Theme.Space2, scale) * 2;
                return Math.Max(standard, glyph);
            }
        }

        /// <summary>Current interaction state, used by the shared chrome painter.</summary>
        public InputState State
        {
            get
            {
                if (!Enabled)
                    return InputState.Disabled;

                if (_focused)
                    return InputState.Focus;

                return _hover ? InputState.Hover : InputState.Rest;
            }
        }

        /// <summary>Current value; always normalised to at most two clusters.</summary>
        [Category("Data")]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Glyph
        {
            get => _glyph;
            set
            {
                string next = Emoji.Normalize(value);
                if (string.Equals(_glyph, next, StringComparison.Ordinal))
                    return;

                _glyph = next;
                Invalidate();
            }
        }

        /// <summary>Shown when no glyph has been picked yet.</summary>
        [Category("Appearance")]
        [DefaultValue("")]
        public string Placeholder
        {
            get => PlaceholderText;
            set
            {
                PlaceholderText = value ?? string.Empty;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string PlaceholderText { get; set; } = string.Empty;

        [Category("Appearance")]
        [DefaultValue(24F)]
        public float EmojiSize
        {
            get => _emojiSize;
            set
            {
                _emojiSize = value <= 0 ? 24f : value;
                Invalidate();
            }
        }

        private float _emojiSize = 24f;

        /// <summary>Raised whenever the value actually changes.</summary>
        [Browsable(false)]
        public event EventHandler? GlyphChanged;

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            var rect = InputChrome.Bounds(this, scale);

            InputState state = State;
            InputChrome.Paint(g, rect, scale, state);

            int padX = Theme.Scaled(InputChrome.PaddingX, scale);
            var content = new RectangleF(
                rect.X + padX,
                rect.Y,
                Math.Max(0, rect.Width - padX * 2),
                rect.Height);

            if (string.IsNullOrEmpty(_glyph))
            {
                string hint = string.IsNullOrEmpty(PlaceholderText) ? "Choose an emoji" : PlaceholderText;
                Theme.DrawText(g, hint, Typography.Body, content, Colors.FaintText, StringAlignment.Center);
                return;
            }

            int pixels = Theme.Scaled(Math.Max(8, (int)Math.Round(_emojiSize * 0.75f)), scale);
            EmojiRenderer.Draw(g, _glyph, pixels, content);
        }

        protected override bool IsInputKey(Keys keyData) => true;

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar == (char)8)   // backspace
            {
                RemoveLastCluster();
                e.Handled = true;
                return;
            }

            if (e.KeyChar == (char)27)  // escape
            {
                return;
            }

            if (char.IsControl(e.KeyChar))
                return;

            AppendClusters(e.KeyChar.ToString());
            e.Handled = true;
        }

        private void RemoveLastCluster()
        {
            if (string.IsNullOrEmpty(_glyph))
                return;

            var clusters = Split(_glyph);
            if (clusters.Count == 0)
            {
                _glyph = string.Empty;
            }
            else
            {
                clusters.RemoveAt(clusters.Count - 1);
                _glyph = string.Concat(clusters);
            }

            OnGlyphChanged();
        }

        private void AppendClusters(string addition)
        {
            var clusters = Split(_glyph);
            foreach (var cluster in Split(Emoji.Normalize(addition)))
            {
                if (clusters.Count >= MaxClusters)
                    break;
                clusters.Add(cluster);
            }

            _glyph = string.Concat(clusters);
            OnGlyphChanged();
        }

        private static System.Collections.Generic.List<string> Split(string value)
        {
            var result = new System.Collections.Generic.List<string>();
            if (string.IsNullOrEmpty(value))
                return result;

            var enumerator = StringInfo.GetTextElementEnumerator(value);
            while (enumerator.MoveNext())
            {
                var cluster = (string)enumerator.Current;
                if (cluster.Length > 0)
                    result.Add(cluster);
            }

            return result;
        }

        private void OnGlyphChanged()
        {
            Invalidate();
            GlyphChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>True when the caret-like ring should be drawn.</summary>
        public void SetFocused(bool focused)
        {
            if (_focused == focused)
                return;

            _focused = focused;
            Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            _focused = true;
            Invalidate();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            _focused = false;
            Invalidate();
            base.OnLostFocus(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _hover = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _hover = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (!Enabled)
            {
                _hover = false;
                _focused = false;
            }

            BackColor = InputChrome.Fill(State);
            Invalidate();
        }
    }
}
