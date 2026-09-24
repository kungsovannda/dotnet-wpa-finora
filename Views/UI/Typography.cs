using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenseTracker.Views.UI
{
    public class Typography
    {
        public static readonly Font PageTitle =
            new("Inter", 24F, FontStyle.Bold);

        public static readonly Font SectionTitle =
            new("Inter", 16F, FontStyle.Bold);

        public static readonly Font Body =
            new("Inter", 10F, FontStyle.Regular);

        public static readonly Font BodyMedium =
            new("Inter", 10F, FontStyle.Bold);

        public static readonly Font Caption =
            new("Inter", 9F, FontStyle.Regular);

        public static readonly Font Button =
            new("Inter", 10F, FontStyle.Bold);

        public static readonly Font Amount =
            new("Inter", 24F, FontStyle.Bold);

        public static void Apply(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.Font = new Font("Lexend", control.Font.Size, control.Font.Style);

                if (control.HasChildren)
                {
                    Apply(control);
                }
            }
        }
    }
}
