using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Dtos;

namespace PersonalExpenseTracker.Features.Dashboard
{
    public interface DashboardService
    {
        DashboardSummaryDto GetDashboardSummary();

        List<TransactionResponseDto> GetRecentTransactions(int limit = 10);
    }
}
