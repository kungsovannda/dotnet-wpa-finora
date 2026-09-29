using Microsoft.Extensions.DependencyInjection;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Features.Dashboard;
using PersonalExpenseTracker.Features.Transactions;
using PersonalExpenseTracker.Views.UI;
using System;
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
            ApplyTheming();
        }

        private void ApplyTheming()
        {
            BackColor = Colors.Background;

            dgv.DefaultCellStyle.BackColor = Colors.Surface;
            dgv.DefaultCellStyle.ForeColor = Colors.Foreground;
            dgv.DefaultCellStyle.Font = Typography.Body;
            dgv.DefaultCellStyle.Padding = new Padding(12, 4, 12, 4);
            dgv.DefaultCellStyle.SelectionBackColor = Colors.PrimarySoft;
            dgv.DefaultCellStyle.SelectionForeColor = Colors.Foreground;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Colors.SurfaceSecondary;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Colors.Foreground;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Colors.Surface;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Colors.MutedText;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Colors.Surface;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Colors.MutedText;

            dgv.EnableHeadersVisualStyles = false;

            dgv.CellFormatting += Dgv_CellFormatting;
            dgv.DataBindingComplete += Dgv_DataBindingComplete;
        }

        private void btnAddTransaction_Click(object? sender, EventArgs e)
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
            StyleDataGridView();
            UpdateEmptyState();
        }

        private void Dgv_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            StyleColumns();
            UpdateEmptyState();
        }

        private void StyleDataGridView()
        {
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    row.Height = 44;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                }
            }
        }

        private void StyleColumns()
        {
            if (!dgv.Columns.Contains("CategoryName"))
                return;

            Hide("Id");
            Hide("CategoryId");
            Hide("CreatedAt");

            if (Column("CategoryName") is { } category)
            {
                category.HeaderText = "Category";
                category.FillWeight = 26;
                category.DisplayIndex = 0;
            }

            if (Column("Type") is { } type)
            {
                type.HeaderText = "Type";
                type.FillWeight = 14;
                type.DisplayIndex = 1;
            }

            if (Column("Amount") is { } amount)
            {
                amount.HeaderText = "Amount";
                amount.FillWeight = 18;
                amount.DisplayIndex = 2;
                amount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                amount.DefaultCellStyle.Font = Typography.BodyMedium;
            }

            if (Column("Date") is { } date)
            {
                date.HeaderText = "Date";
                date.FillWeight = 18;
                date.DisplayIndex = 3;
            }

            if (Column("Description") is { } description)
            {
                description.HeaderText = "Description";
                description.FillWeight = 24;
                description.DisplayIndex = 4;
            }
        }

        private DataGridViewColumn? Column(string columnName) =>
            dgv.Columns.Contains(columnName) ? dgv.Columns[columnName] : null;

        private void Hide(string columnName)
        {
            if (Column(columnName) is { } column)
                column.Visible = false;
        }

        private void Dgv_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgv.Rows.Count || e.ColumnIndex < 0)
                return;

            if (dgv.Rows[e.RowIndex].DataBoundItem is not TransactionResponseDto item)
                return;

            string column = dgv.Columns[e.ColumnIndex].Name;
            bool isIncome = item.Type == TransactionType.INCOME;

            switch (column)
            {
                case "Amount":
                    e.Value = (isIncome ? "+" : "-") + item.Amount.ToString("C");
                    e.CellStyle.ForeColor = isIncome ? Colors.Success : Colors.Danger;
                    e.CellStyle.Font = Typography.BodyMedium;
                    e.FormattingApplied = true;
                    break;

                case "Type":
                    e.Value = isIncome ? "Income" : "Expense";
                    e.CellStyle.ForeColor = isIncome ? Colors.Success : Colors.Danger;
                    e.FormattingApplied = true;
                    break;

                case "Date":
                    e.Value = item.Date.ToString("MMM d, yyyy");
                    e.CellStyle.ForeColor = Colors.SecondaryText;
                    e.FormattingApplied = true;
                    break;

                case "Description":
                    e.CellStyle.ForeColor = Colors.MutedText;
                    break;
            }
        }

        private void UpdateEmptyState()
        {
            bool hasItems = dgv.Rows.Count > 0;
            dgv.Visible = hasItems;
            empty.Visible = !hasItems;
        }

        private void LoadSummary()
        {
            var summary = _dashboardController.GetDashboardSummary();

            cardBalance.Value = summary.TotalBalance.ToString("C");
            cardBalance.Support = "Current balance";
            cardIncome.Value = summary.TotalIncome.ToString("C");
            cardIncome.Support = "Money received";
            cardExpense.Value = summary.TotalExpense.ToString("C");
            cardExpense.Support = "Money spent";
            cardTransaction.Value = summary.TransactionCount.ToString();
            cardTransaction.Support = "Activity entries";
        }

        private void TransactionControl_Load(object sender, EventArgs e)
        {
            LoadTransaction();
            LoadSummary();
        }
    }
}
