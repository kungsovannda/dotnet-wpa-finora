using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Controls
{

    public partial class Header : UserControl
    {

        private bool _fitting;

        public Header()
        {
            InitializeComponent();
            FitTitles();
            RefreshContext();
        }

        private void FitTitles()
        {
            if (lbQuote == null || lbContext == null || titles == null || _fitting)
                return;

            _fitting = true;
            try
            {
                int quote = Math.Max(lbQuote.PreferredHeight, 1);
                int date = Math.Max(lbContext.PreferredHeight, 1);

                if (titles.RowStyles[1].Height != quote)
                    titles.RowStyles[1].Height = quote;
                if (titles.RowStyles[2].Height != date)
                    titles.RowStyles[2].Height = date;
            }
            finally
            {
                _fitting = false;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            FitTitles();
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            FitTitles();
        }

        /// <summary>Quote shown on the leading edge.</summary>
        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Quote
        {
            get => lbQuote.Text;
            set => lbQuote.Text = value ?? string.Empty;
        }

        /// <summary>Secondary line under the quote (today's date by default).</summary>
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

        public void RefreshContext()
        {
            if (lbQuote == null || lbContext == null)
                return;

            DateTime now = DateTime.Now;
            lbContext.Text = now.ToString("dddd, d MMMM", CultureInfo.CurrentCulture);
        }


        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
                RefreshContext();
        }
    }
}
