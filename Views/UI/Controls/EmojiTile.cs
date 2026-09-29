using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// Soft rounded tile with a centred colour emoji - the visual anchor of a
    /// category card.
    /// </summary>
    public class EmojiTile : Control
    {
        private string _glyph = string.Empty;
        private float _emojiSize = 22f;
        private float _scale = 1f;

        public EmojiTile()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Size = new Size(Theme.Scaled(44, 1f), Theme.Scaled(44, 1f));
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

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TileColor
        {
            get => BackColor == Color.Transparent ? Colors.SurfaceSunken : BackColor;
            set
            {
                BackColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(Theme.RadiusMd)]
        public int Radius
        {
            get; set;
        } = Theme.RadiusMd;

        [Category("Appearance")]
        [DefaultValue(22F)]
        public float EmojiSize
        {
            get => _emojiSize;
            set
            {
                _emojiSize = value;
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

            float scale = _scale <= 0 ? Theme.ScaleOf(this) : _scale;
            var rect = new RectangleF(0, 0, Width, Height);
            int radius = Theme.Scaled(Radius, scale);

            using (var brush = new SolidBrush(TileColor))
            using (var path = Theme.RoundedPath(rect, radius))
            {
                g.FillPath(brush, path);
            }

            if (string.IsNullOrEmpty(_glyph))
                return;

            int pixels = Theme.Scaled(Math.Max(8, (int)Math.Round(_emojiSize * 0.75f)), scale);
            EmojiRenderer.Draw(g, _glyph, pixels, new RectangleF(0f, 0f, Width, Height));
        }
    }
}
