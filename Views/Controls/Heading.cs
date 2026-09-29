using System;
using System.ComponentModel;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Controls
{
    /// <summary>
    /// Page / dialog title block. The two labels are sized from their own
    /// preferred height so a larger font can never be clipped by the control
    /// or by the layout cell that hosts it.
    /// </summary>
    public partial class Heading : UserControl
    {
        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Title
        {
            get => lbTitle.Text;
            set => lbTitle.Text = value ?? string.Empty;
        }

        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string description
        {
            get => lbDescription.Text;
            set => lbDescription.Text = value ?? string.Empty;
        }

        public Heading()
        {
            InitializeComponent();
            lbTitle.FontChanged += (_, _) => FitToContent();
            lbDescription.FontChanged += (_, _) => FitToContent();
            FitToContent();
        }

        /// <summary>
        /// Grows the docked labels to the height their font actually needs.
        /// Without this a 15pt title inside a 24px label is cut off top and bottom.
        /// </summary>
        private void FitToContent()
        {
            if (lbTitle == null || lbDescription == null)
                return;

            int title = Math.Max(lbTitle.PreferredHeight, 1);
            int desc = Math.Max(lbDescription.PreferredHeight, 1);

            if (lbTitle.Height != title)
                lbTitle.Height = title;

            if (lbDescription.Height != desc)
                lbDescription.Height = desc;

            int wanted = title + desc + lbDescription.Margin.Vertical;
            if (AutoSize && Height != wanted)
                Height = wanted;
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            FitToContent();
        }
    }
}
