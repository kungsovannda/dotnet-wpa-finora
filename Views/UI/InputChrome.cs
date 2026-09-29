using System;
using System.Drawing;

namespace PersonalExpenseTracker.Views.UI
{
    /// <summary>Interaction state shared by every input control.</summary>
    public enum InputState
    {
        /// <summary>Idle.</summary>
        Rest,

        /// <summary>Pointer is over the field.</summary>
        Hover,

        /// <summary>The field owns keyboard focus.</summary>
        Focus,

        /// <summary>The field cannot be edited.</summary>
        Disabled
    }

    /// <summary>
    /// Single source of truth for how a form input looks. Every input
    /// (text, combo, emoji) paints through <see cref="Paint"/> so the fill,
    /// hairline and focus ring are identical across all dialogs.
    /// </summary>
    public static class InputChrome
    {
        /// <summary>Corner radius of every input.</summary>
        public const int Radius = Theme.RadiusMd;

        /// <summary>Horizontal text inset (keeps text aligned with captions).</summary>
        public const int PaddingX = Theme.Space3;

        /// <summary>Gap between a leading icon and the text.</summary>
        public const int IconGap = Theme.Space2;

        /// <summary>Size of an optional leading adornment.</summary>
        public const int IconSize = 16;

        /// <summary>Width reserved on the trailing edge for a drop-down arrow.</summary>
        public const int TrailingAffordance = 32;

        /// <summary>
        /// Width the native drop-down arrow occupies at the trailing edge of a
        /// ComboBox. The custom chevron has to cover at least this much.
        /// </summary>
        public const int ArrowZone = 22;

        /// <summary>Background of the field for the given state.</summary>
        public static Color Fill(InputState state)
        {
            switch (state)
            {
                case InputState.Focus:
                case InputState.Hover:
                    // Lift to pure white so the active field separates from the
                    // #FAFAF9 rest state and from the white dialog surface.
                    return Colors.Surface;
                case InputState.Disabled:
                    return Colors.SurfaceSunken;
                default:
                    return Colors.SurfaceSecondary;
            }
        }

        /// <summary>Hairline colour of the field for the given state.</summary>
        public static Color Border(InputState state)
        {
            switch (state)
            {
                case InputState.Focus:
                    return Colors.PrimaryOrange;
                case InputState.Hover:
                    return Colors.BorderStrong;
                case InputState.Disabled:
                    return Colors.BorderSoft;
                default:
                    return Colors.Border;
            }
        }

        /// <summary>Colour of a leading adornment for the given state.</summary>
        public static Color IconTint(InputState state)
        {
            switch (state)
            {
                case InputState.Focus:
                    return Colors.PrimaryHover;
                case InputState.Disabled:
                    return Colors.FaintText;
                default:
                    return Colors.MutedText;
            }
        }

        /// <summary>Text colour of the typed value for the given state.</summary>
        public static Color TextTint(InputState state) =>
            state == InputState.Disabled ? Colors.MutedText : Colors.Foreground;

        /// <summary>Builds the standard field bounds (hairline drawn inside the control).</summary>
        public static RectangleF Bounds(Control control, float scale) =>
            new RectangleF(0.5f * scale, 0.5f * scale,
                           control.Width - scale, control.Height - scale);

        /// <summary>
        /// Paints the focus ring, fill and hairline for an input.
        /// </summary>
        public static void Paint(Graphics g, RectangleF rect, float scale, InputState state)
        {
            float radius = Theme.Scaled(Radius, scale);

            if (state == InputState.Focus)
            {
                using var ring = new SolidBrush(Color.FromArgb(38, 245, 158, 11));
                using var ringPath = Theme.RoundedPath(
                    new RectangleF(rect.X - 3f * scale, rect.Y - 3f * scale,
                                   rect.Width + 6f * scale, rect.Height + 6f * scale),
                    radius + 3f);
                g.FillPath(ring, ringPath);
            }

            Theme.PaintSurface(g, rect, radius, Fill(state), Border(state), scale, shadow: false);
        }
    }
}
