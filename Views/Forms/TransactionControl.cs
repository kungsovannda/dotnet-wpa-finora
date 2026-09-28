using Microsoft.Extensions.DependencyInjection;
using PersonalExpenseTracker.Features.Dashboard;
using PersonalExpenseTracker.Features.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.Forms
{
    public partial class TransactionControl : UserControl
    {
        private readonly IServiceProvider serviceProvider;
        private readonly TransactionController _controller;
        private readonly DashboardController _dashboardController;
        public TransactionControl(IServiceProvider serviceProvider, TransactionController controller, DashboardController dashboardController)
        {
            _dashboardController = dashboardController;
            _controller = controller;
            this.serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            var dialog = serviceProvider.GetRequiredService<TransactionDialog>();
            dialog.ShowDialog(this);
            if (dialog.DialogResult == DialogResult.OK)
            {
                _controller.CreateTransaction(dialog.GetData());
                LoadTransaction();
                LoadSummary();
            }
        }

        private void LoadTransaction()
        {
            var transactions = _controller.GetAllTransactions();
            dgv.DataSource = transactions;
        }

        private void LoadSummary()
        {
            var summary = _dashboardController.GetDashboardSummary();
            cardBalance.Value = summary.TotalBalance.ToString("C");
            cardIncome.Value = summary.TotalIncome.ToString("C");
            cardExpense.Value = summary.TotalExpense.ToString("C");
            cardTransaction.Value = summary.TransactionCount.ToString();
        }

        private void TransactionControl_Load(object sender, EventArgs e)
        {
            LoadTransaction();
            LoadSummary();
        }
    }
}
