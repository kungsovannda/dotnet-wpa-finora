using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.Controls
{
    public partial class Heading : UserControl
    {
        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public String Title
        {
            get => lbTitle.Text;
            set => lbTitle.Text = value;
        }

        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public String description
        {
            get => lbDescription.Text;
            set => lbDescription.Text = value;
        }

        public Heading()
        {
            InitializeComponent();
        }
    }
}
