using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Dtos;

namespace PersonalExpenseTracker.Features.Dashboard
{
    public class DashboardController
    {
        private readonly DashboardService _dashboardService;

        public DashboardController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public DashboardSummaryDto GetDashboardSummary()
        {
            return _dashboardService.GetDashboardSummary();
        }

        public List<TransactionResponseDto> GetRecentTransactions(int limit = 10)
        {
            return _dashboardService.GetRecentTransactions(limit);
        }
    }
}
