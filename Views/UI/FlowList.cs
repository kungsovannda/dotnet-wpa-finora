using System;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.UI
{
    /// <summary>
    /// Row sizing for the scrolling <see cref="FlowLayoutPanel"/> lists (recent
    /// transactions, saving goals and the report rows).
    ///
    /// A row has to fit the width that is actually visible: the moment the
    /// vertical scrollbar shows up it takes its own width out of the panel, and
    /// a row laid out at the old width drags a horizontal scrollbar in with it
    /// - even when there is nothing to scroll sideways.
    /// </summary>
    public static class FlowList
    {
        /// <summary>Breathing room kept between a row and the panel edge.</summary>
        private const int EdgeGap = 4;

        /// <summary>
        /// The width a row needs to fill the panel without ever triggering a
        /// horizontal scrollbar. <c>ClientSize</c> already excludes a vertical
        /// scrollbar that is showing, so the width is read fresh every pass.
        /// </summary>
        public static int RowWidth(FlowLayoutPanel host)
        {
            if (host == null)
                return 0;

            return Math.Max(0, host.ClientSize.Width - EdgeGap);
        }

        /// <summary>
        /// Sizes every row to the panel's visible width. The scrollbar reacts
        /// to the first pass, so the measurement is repeated until it settles;
        /// three passes is enough for every layout and keeps a pathological
        /// case from looping forever. Call this with the panel's layout
        /// resumed, never while it is suspended.
        /// </summary>
        public static void FitRows(FlowLayoutPanel host)
        {
            if (host == null || host.IsDisposed)
                return;

            int previous = int.MinValue;
            for (int pass = 0; pass < 3; pass++)
            {
                int width = RowWidth(host);
                foreach (Control row in host.Controls)
                {
                    if (row.Width != width)
                        row.Width = width;
                }

                if (width == previous)
                    return;

                previous = width;
            }
        }
    }
}
