using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Dtos;

namespace PersonalExpenseTracker.Features.Dashboard
{
    public interface DashboardService
    {
        DashboardSummaryDto GetDashboardSummary();

        List<TransactionResponseDto> GetRecentTransactions(int limit = 10);

        /// <summary>Headline saving-goal figures, reused from the goals service.</summary>
        SavingGoalOverviewDto GetSavingsOverview();
    }
}
