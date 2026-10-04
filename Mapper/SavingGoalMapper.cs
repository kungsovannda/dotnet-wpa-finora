using System;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;

namespace PersonalExpenseTracker.Mapper
{
    public class SavingGoalMapper
    {
        public static SavingGoal ToSavingGoal(CreateSavingGoalDto dto)
        {
            return new SavingGoal
            {
                Name = dto.Name,
                Description = dto.Description ?? string.Empty,
                Emoji = dto.Emoji ?? string.Empty,
                TargetAmount = dto.TargetAmount,
                CurrentAmount = 0m,
                TargetDate = dto.TargetDate
            };
        }

        public static SavingGoal ToSavingGoal(UpdateSavingGoalDto dto, SavingGoal existingGoal)
        {
            existingGoal.Name = dto.Name;
            existingGoal.Description = dto.Description ?? string.Empty;
            existingGoal.Emoji = dto.Emoji ?? string.Empty;
            existingGoal.TargetAmount = dto.TargetAmount;
            existingGoal.TargetDate = dto.TargetDate;
            existingGoal.IsArchived = dto.IsArchived;
            return existingGoal;
        }

        /// <summary>
        /// Progress and status come from the domain, so the card, the list and
        /// the reports can never disagree about a goal.
        /// </summary>
        public static SavingGoalResponseDto ToResponseDto(SavingGoal goal, int contributionCount = 0)
        {
            return new SavingGoalResponseDto
            {
                Id = goal.Id,
                Name = goal.Name,
                Description = goal.Description ?? string.Empty,
                Emoji = goal.Emoji ?? string.Empty,
                TargetAmount = goal.TargetAmount,
                CurrentAmount = goal.CurrentAmount,
                RemainingAmount = goal.RemainingAmount,
                ProgressPercentage = goal.ProgressPercentage,
                TargetDate = goal.TargetDate,
                IsArchived = goal.IsArchived,
                Status = goal.Status,
                ContributionCount = contributionCount,
                CreatedAt = goal.CreatedAt
            };
        }

        public static SavingGoalContributionDto ToContributionDto(SavingGoalContribution contribution)
        {
            return new SavingGoalContributionDto
            {
                Id = contribution.Id,
                SavingGoalId = contribution.SavingGoalId,
                Amount = contribution.Amount,
                Date = contribution.Date,
                Note = contribution.Note ?? string.Empty,
                CreatedAt = contribution.CreatedAt
            };
        }
    }
}
