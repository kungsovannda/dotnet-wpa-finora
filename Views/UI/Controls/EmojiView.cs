using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// Centred emoji renderer. Delegates to <see cref="EmojiRenderer"/>, which
    /// caches a tightly cropped bitmap per glyph, so the glyph is always crisp
    /// and optically centred inside the tile.
    /// </summary>
    public class EmojiView : Control
    {
        private string _glyph = string.Empty;
        private float _emojiSize = 20f;
        private float _scale = 1f;
        private Color? _tint;

        public EmojiView()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string Glyph
        {
            get => _glyph;
            set
            {
                _glyph = value ?? string.Empty;
                Invalidate();
            }
        }

        /// <summary>Point size used for the glyph.</summary>
        [Category("Appearance")]
        [DefaultValue(20F)]
        public float EmojiSize
        {
            get => _emojiSize;
            set
            {
                _emojiSize = value;
                Invalidate();
            }
        }

        /// <summary>Optional glyph colour; defaults to <see cref="EmojiRenderer.DefaultTint"/>.</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color? Tint
        {
            get => _tint;
            set
            {
                _tint = value;
                Invalidate();
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _scale = Theme.ScaleOf(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Theme.SetupQuality(g);

            if (string.IsNullOrEmpty(_glyph))
                return;

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            int pixels = Theme.Scaled(Math.Max(8, (int)Math.Round(_emojiSize * 0.75f)), scale);
            EmojiRenderer.Draw(g, _glyph, pixels, ClientRectangle, _tint);
        }
    }
}
