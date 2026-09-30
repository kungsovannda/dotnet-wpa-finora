using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Dtos;

namespace PersonalExpenseTracker.Features.SavingGoals
{
    public interface SavingGoalService
    {
        SavingGoalResponseDto CreateSavingGoal(CreateSavingGoalDto dto);

        SavingGoalResponseDto GetSavingGoalById(long id);

        List<SavingGoalResponseDto> GetAllSavingGoals();

        List<SavingGoalResponseDto> GetActiveSavingGoals();

        SavingGoalResponseDto UpdateSavingGoal(UpdateSavingGoalDto dto);

        void DeleteSavingGoal(long id);

        /// <summary>
        /// Records money put towards a goal. Intentionally not a transaction:
        /// savings you already own are neither income nor an expense.
        /// </summary>
        SavingGoalResponseDto AddContribution(AddGoalContributionDto dto);

        void RemoveContribution(long savingGoalId, long contributionId);

        List<SavingGoalContributionDto> GetContributions(long savingGoalId);

        SavingGoalOverviewDto GetOverview();
    }
}
