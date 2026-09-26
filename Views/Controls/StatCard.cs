using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.Controls
{
    public partial class StatCard : UserControl
    {
        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Title
        {
            get => lbTitle.Text;
            set => lbTitle.Text = value;
        }

        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Value
        {
            get => lbValue.Text;
            set => lbValue.Text = value;
        }
        public StatCard()
        {
            InitializeComponent();
        }
    }
}
