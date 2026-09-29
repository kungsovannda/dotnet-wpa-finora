using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.UI
{
    /// <summary>
    /// Type scale for Finora. Every font instance is created through
    /// <see cref="Create"/> so the family resolution stays in one place
    /// (Segoe UI is always present on Windows, which keeps the UI stable
    /// on machines where a display font is not installed).
    /// </summary>
    public class Typography
    {
        private const string Family = "Lexend";
        private const string SemiboldFamily = "Lexend Semibold";
        private const string LightFamily = "Lexend Light";

        private static readonly bool HasSemiboldFamily = IsInstalled(SemiboldFamily);
        private static readonly bool HasLightFamily = IsInstalled(LightFamily);

        private static bool IsInstalled(string family)
        {
            try
            {
                using var installed = new System.Drawing.Text.InstalledFontCollection();
                return installed.Families.Any(f =>
                    string.Equals(f.Name, family, StringComparison.OrdinalIgnoreCase));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Creates a font from the Finora type scale.</summary>
        public static Font Create(float size, FontStyle style = FontStyle.Regular, bool semibold = false)
        {
            var family = semibold && HasSemiboldFamily ? SemiboldFamily : Family;
            return new Font(family, size, style, GraphicsUnit.Point);
        }

        /// <summary>Creates a light-weight (thin) display font.</summary>
        public static Font CreateLight(float size, FontStyle style = FontStyle.Regular)
        {
            var family = HasLightFamily ? LightFamily : Family;
            return new Font(family, size, style, GraphicsUnit.Point);
        }

        // Display / page level
        public static readonly Font Display =
            Create(26F, FontStyle.Bold);

        public static readonly Font PageTitle =
            Create(22F, FontStyle.Bold);

        public static readonly Font HeadingLarge =
            Create(18F, FontStyle.Bold);

        public static readonly Font SectionTitle =
            Create(15F, FontStyle.Bold);

        public static readonly Font HeadingSmall =
            Create(13F, FontStyle.Bold);

        public static readonly Font BrandTitle =
            Create(15F, FontStyle.Regular, semibold: true);

        // Body text
        public static readonly Font BodyLarge =
            Create(12F);

        public static readonly Font Body =
            Create(10.5F);

        public static readonly Font BodyMedium =
            Create(10.5F, FontStyle.Regular, semibold: true);

        public static readonly Font BodySemibold =
            Create(10.5F, FontStyle.Regular, semibold: true);

        public static readonly Font BodySmall =
            Create(9.5F);

        public static readonly Font BodySmallMedium =
            Create(9.5F, FontStyle.Regular, semibold: true);

        // Button & control text
        public static readonly Font Button =
            Create(10.5F, FontStyle.Regular, semibold: true);

        public static readonly Font ButtonSmall =
            Create(9.5F, FontStyle.Regular, semibold: true);

        // Special typography
        public static readonly Font Amount =
            Create(20F, FontStyle.Regular, semibold: true);

        public static readonly Font AmountLarge =
            Create(24F, FontStyle.Regular, semibold: true);

        public static readonly Font Caption =
            Create(9F);

        public static readonly Font CaptionMedium =
            Create(9F, FontStyle.Regular, semibold: true);

        public static readonly Font Overline =
            Create(8.5F, FontStyle.Bold);

        public static readonly Font Label =
            Create(10.5F, FontStyle.Regular, semibold: true);

        public static readonly Font EmojiFont =
            new Font("Segoe UI Emoji", 20F, FontStyle.Regular, GraphicsUnit.Point);

        /// <summary>
        /// Re-anchors a control tree onto the Finora type scale while preserving
        /// the intended size / weight of each control.
        /// </summary>
        public static void Apply(Control parent)
        {
            if (parent == null)
                return;

            foreach (Control control in parent.Controls)
            {
                control.Font = Resolve(control.Font);
                Apply(control);
            }
        }

        private static Font Resolve(Font font)
        {
            if (font == null)
                return Body;

            var semibold = font.FontFamily != null &&
                           font.FontFamily.Name.IndexOf("Semibold", StringComparison.OrdinalIgnoreCase) >= 0;

            var style = font.Style;
            if (semibold)
                style &= ~FontStyle.Bold;

            return Create(font.Size, style, semibold);
        }
    }
}
