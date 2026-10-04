using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Dtos;

namespace PersonalExpenseTracker.Features.SavingGoals
{
    public class SavingGoalController
    {
        private readonly SavingGoalService _savingGoalService;

        public SavingGoalController(SavingGoalService savingGoalService)
        {
            _savingGoalService = savingGoalService;
        }

        public SavingGoalResponseDto CreateSavingGoal(CreateSavingGoalDto dto)
        {
            return _savingGoalService.CreateSavingGoal(dto);
        }

        public SavingGoalResponseDto GetSavingGoal(long id)
        {
            return _savingGoalService.GetSavingGoalById(id);
        }

        public List<SavingGoalResponseDto> GetAllSavingGoals()
        {
            return _savingGoalService.GetAllSavingGoals();
        }

        public List<SavingGoalResponseDto> GetActiveSavingGoals()
        {
            return _savingGoalService.GetActiveSavingGoals();
        }

        public SavingGoalResponseDto UpdateSavingGoal(UpdateSavingGoalDto dto)
        {
            return _savingGoalService.UpdateSavingGoal(dto);
        }

        public void DeleteSavingGoal(long id)
        {
            _savingGoalService.DeleteSavingGoal(id);
        }

        public SavingGoalResponseDto AddContribution(AddGoalContributionDto dto)
        {
            return _savingGoalService.AddContribution(dto);
        }

        public void RemoveContribution(long savingGoalId, long contributionId)
        {
            _savingGoalService.RemoveContribution(savingGoalId, contributionId);
        }

        public List<SavingGoalContributionDto> GetContributions(long savingGoalId)
        {
            return _savingGoalService.GetContributions(savingGoalId);
        }

        public SavingGoalOverviewDto GetOverview()
        {
            return _savingGoalService.GetOverview();
        }
    }
}
