using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PersonalExpenseTracker.Views.UI
{
    /// <summary>
    /// Central design-token palette for Finora.
    /// Orange/amber is the Finora brand accent and is used intentionally -
    /// never as an all-over background colour.
    /// </summary>
    public class Colors
    {
        // Primary Brand - Orange/Amber
        public static readonly Color PrimaryOrange = Color.FromArgb(245, 158, 11);      // #F59E0B
        public static readonly Color PrimaryHover = Color.FromArgb(217, 119, 6);        // #D97706
        public static readonly Color PrimaryPressed = Color.FromArgb(180, 83, 9);       // #B45309
        public static readonly Color PrimarySoft = Color.FromArgb(254, 243, 199);       // #FEF3C7
        public static readonly Color PrimaryBorder = Color.FromArgb(253, 230, 138);     // #FDE68A

        // Background & Surface
        public static readonly Color Background = Color.FromArgb(248, 248, 247);        // #F8F8F7
        public static readonly Color Surface = Color.FromArgb(255, 255, 255);           // #FFFFFF
        public static readonly Color SurfaceSecondary = Color.FromArgb(250, 250, 249);  // #FAFAF9
        public static readonly Color SurfaceElevated = Color.FromArgb(255, 255, 255);   // #FFFFFF
        public static readonly Color SurfaceHover = Color.FromArgb(244, 244, 245);       // #F4F4F5
        public static readonly Color SurfaceSunken = Color.FromArgb(243, 242, 240);     // #F3F2F0

        // Foreground & Text
        public static readonly Color Foreground = Color.FromArgb(24, 24, 27);           // #18181B
        public static readonly Color SecondaryText = Color.FromArgb(82, 82, 91);        // #52525B
        public static readonly Color MutedText = Color.FromArgb(113, 113, 122);         // #71717A
        public static readonly Color FaintText = Color.FromArgb(161, 161, 170);         // #A1A1AA
        public static readonly Color OnPrimary = Color.FromArgb(255, 255, 255);         // #FFFFFF

        // Border
        public static readonly Color Border = Color.FromArgb(228, 228, 231);            // #E4E4E7
        public static readonly Color BorderStrong = Color.FromArgb(212, 212, 216);      // #D4D4D8
        public static readonly Color BorderDark = Color.FromArgb(163, 163, 175);        // #A3A3AF
        public static readonly Color BorderSoft = Color.FromArgb(237, 237, 239);        // #EDEDEF

        // Semantic Colors - Success (income)
        public static readonly Color Success = Color.FromArgb(22, 163, 74);             // #16A34A
        public static readonly Color SuccessSoft = Color.FromArgb(220, 252, 231);       // #DCFCE7
        public static readonly Color SuccessBorder = Color.FromArgb(187, 247, 208);     // #BBF7D0

        // Semantic Colors - Danger (expense / destructive)
        public static readonly Color Danger = Color.FromArgb(220, 38, 38);              // #DC2626
        public static readonly Color DangerSoft = Color.FromArgb(254, 226, 226);        // #FEE2E2
        public static readonly Color DangerBorder = Color.FromArgb(254, 202, 202);      // #FECACA

        // Semantic Colors - Warning
        public static readonly Color Warning = Color.FromArgb(217, 119, 6);             // #D97706
        public static readonly Color WarningSoft = Color.FromArgb(254, 243, 199);       // #FEF3C7

        // Semantic Colors - Info
        public static readonly Color Info = Color.FromArgb(37, 99, 235);                // #2563EB
        public static readonly Color InfoSoft = Color.FromArgb(219, 234, 254);          // #DBEAFE

        // Chart & data-viz
        public static readonly Color ChartGrid = Color.FromArgb(237, 237, 236);         // #EDEDEC
        public static readonly Color ChartTrack = Color.FromArgb(243, 242, 240);        // #F3F2F0
        public static readonly Color ChartLabel = Color.FromArgb(161, 161, 170);        // #A1A1AA

        // Scrim / overlay
        public static readonly Color Scrim = Color.FromArgb(28, 25, 23);

        // Legacy compatibility (used in existing code)
        public static readonly Color ControlBackground = Background;
        public static readonly Color FormBackground = Background;
        public static readonly Color PanelBackground = Surface;
    }
}
