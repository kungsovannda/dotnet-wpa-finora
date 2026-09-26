using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PersonalExpenseTracker.Features.Dashboard;
using PersonalExpenseTracker.Features.Dashboard.Impls;

namespace PersonalExpenseTracker.Views.Forms
{
    public partial class DashboardControl : UserControl
    {
        private readonly DashboardController _controller;
        public DashboardControl(DashboardController controller)
        {
            InitializeComponent();
            _controller = controller;
            var summary = _controller.GetDashboardSummary();
            cardBalance.Value = summary.TotalBalance.ToString("C");
            cardIncome.Value = summary.TotalIncome.ToString("C");
            cardExpense.Value = summary.TotalExpense.ToString("C");
            cardTransaction.Value = summary.TransactionCount.ToString();
        }
    }
}
