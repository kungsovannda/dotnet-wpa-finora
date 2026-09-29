using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Controls
{
    /// <summary>
    /// Application bar above the content area. The brand lives in the sidebar,
    /// so this bar only carries lightweight session context (a time-aware
    /// greeting plus today's date) on the left and the profile circle on the right.
    /// </summary>
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
            FitTitles();
            RefreshContext();
        }

        /// <summary>
        /// Gives the greeting row the height its font actually needs, so the
        /// heading is never clipped by the app bar (or by a DPI change).
        /// </summary>
        private void FitTitles()
        {
            if (lbGreeting == null || titles == null)
                return;

            int needed = Math.Max(lbGreeting.PreferredHeight, 1) + 2;
            if (titles.RowStyles[0].Height != needed)
                titles.RowStyles[0].Height = needed;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            FitTitles();
        }

        /// <summary>Time-aware greeting shown on the leading edge.</summary>
        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Greeting
        {
            get => lbGreeting.Text;
            set => lbGreeting.Text = value ?? string.Empty;
        }

        /// <summary>Secondary line under the greeting (today's date by default).</summary>
        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Context
        {
            get => lbContext.Text;
            set => lbContext.Text = value ?? string.Empty;
        }

        /// <summary>Profile initials rendered in the trailing circle.</summary>
        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string UserName
        {
            get => avatar.Initials;
            set => avatar.Initials = string.IsNullOrWhiteSpace(value)
                ? "U"
                : value.Trim().Substring(0, 1).ToUpperInvariant();
        }

        /// <summary>Refreshes the greeting/date (called on load and when re-shown).</summary>
        public void RefreshContext()
        {
            if (lbGreeting == null || lbContext == null)
                return;

            DateTime now = DateTime.Now;
            lbGreeting.Text = GreetingFor(now);
            lbContext.Text = now.ToString("dddd, d MMMM", CultureInfo.CurrentCulture);
        }

        private static string GreetingFor(DateTime moment)
        {
            int hour = moment.Hour;

            if (hour < 12)
                return "Good morning";

            if (hour < 18)
                return "Good afternoon";

            return "Good evening";
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                FitTitles();
                RefreshContext();
            }
        }
    }
}
