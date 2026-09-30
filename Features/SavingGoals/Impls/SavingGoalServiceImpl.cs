using System;
using System.Collections.Generic;
using System.Linq;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Exceptions;
using PersonalExpenseTracker.Mapper;

namespace PersonalExpenseTracker.Features.SavingGoals.Impls
{
    public class SavingGoalServiceImpl : SavingGoalService
    {
        private const int NameMaxLength = 100;
        private const int DescriptionMaxLength = 255;

        private readonly SavingGoalRepository _repository;

        public SavingGoalServiceImpl(SavingGoalRepository repository)
        {
            _repository = repository;
        }

        public SavingGoalResponseDto CreateSavingGoal(CreateSavingGoalDto dto)
        {
            ValidateGoal(dto.Name, dto.Description, dto.TargetAmount);

            if (_repository.FindAll().Any(g => g.Name.Equals(dto.Name?.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                throw new DuplicateSavingGoalException(dto.Name);
            }

            var goal = SavingGoalMapper.ToSavingGoal(dto);
            goal.Name = goal.Name.Trim();
            var saved = _repository.Save(goal);

            return SavingGoalMapper.ToResponseDto(saved);
        }

        public SavingGoalResponseDto GetSavingGoalById(long id)
        {
            var goal = _repository.FindById(id);
            if (goal == null)
            {
                throw new SavingGoalNotFoundException(id);
            }

            return SavingGoalMapper.ToResponseDto(goal, _repository.FindContributions(id).Count);
        }

        public List<SavingGoalResponseDto> GetAllSavingGoals()
        {
            return _repository.FindAll()
                .Select(g => SavingGoalMapper.ToResponseDto(g, _repository.FindContributions(g.Id).Count))
                .ToList();
        }

        public List<SavingGoalResponseDto> GetActiveSavingGoals()
        {
            return _repository.FindActive()
                .Select(g => SavingGoalMapper.ToResponseDto(g, _repository.FindContributions(g.Id).Count))
                .ToList();
        }

        public SavingGoalResponseDto UpdateSavingGoal(UpdateSavingGoalDto dto)
        {
            ValidateGoal(dto.Name, dto.Description, dto.TargetAmount);

            var existingGoal = _repository.FindById(dto.Id);
            if (existingGoal == null)
            {
                throw new SavingGoalNotFoundException(dto.Id);
            }

            var duplicate = _repository.FindAll()
                .FirstOrDefault(g => g.Name.Equals(dto.Name?.Trim(), StringComparison.OrdinalIgnoreCase) && g.Id != dto.Id);

            if (duplicate != null)
            {
                throw new DuplicateSavingGoalException(dto.Name);
            }

            SavingGoalMapper.ToSavingGoal(dto, existingGoal);
            existingGoal.Name = existingGoal.Name.Trim();
            var updated = _repository.Update(existingGoal);

            return SavingGoalMapper.ToResponseDto(updated ?? existingGoal, _repository.FindContributions(dto.Id).Count);
        }

        public void DeleteSavingGoal(long id)
        {
            if (_repository.FindById(id) == null)
            {
                throw new SavingGoalNotFoundException(id);
            }

            _repository.Delete(id);
        }

        public SavingGoalResponseDto AddContribution(AddGoalContributionDto dto)
        {
            if (dto.Amount <= 0m)
            {
                throw new ValidationException("Contribution amount must be greater than zero.");
            }

            if (!string.IsNullOrWhiteSpace(dto.Note) && dto.Note.Length > DescriptionMaxLength)
            {
                throw new ValidationException($"Contribution note cannot exceed {DescriptionMaxLength} characters.");
            }

            var goal = _repository.FindById(dto.SavingGoalId);
            if (goal == null)
            {
                throw new SavingGoalNotFoundException(dto.SavingGoalId);
            }

            if (goal.IsArchived)
            {
                throw new ValidationException("Contributions cannot be added to an archived saving goal.");
            }

            // The saved total is written here, never accumulated by the caller,
            // and in the same SaveChanges as the contribution row, so the
            // ledger and the total cannot drift apart.
            goal.CurrentAmount += dto.Amount;

            var contribution = new SavingGoalContribution
            {
                Amount = dto.Amount,
                Date = dto.Date ?? DateTime.Now,
                Note = dto.Note?.Trim() ?? string.Empty
            };

            _repository.AddContribution(goal, contribution);

            return SavingGoalMapper.ToResponseDto(goal, _repository.FindContributions(goal.Id).Count);
        }

        public void RemoveContribution(long savingGoalId, long contributionId)
        {
            var goal = _repository.FindById(savingGoalId);
            if (goal == null)
            {
                throw new SavingGoalNotFoundException(savingGoalId);
            }

            var contribution = _repository.FindContributions(savingGoalId)
                .FirstOrDefault(c => c.Id == contributionId);

            if (contribution == null)
            {
                throw new ValidationException("That contribution no longer exists.");
            }

            goal.CurrentAmount = Math.Max(0m, goal.CurrentAmount - contribution.Amount);
            _repository.RemoveContribution(goal, contributionId);
        }

        public List<SavingGoalContributionDto> GetContributions(long savingGoalId)
        {
            if (_repository.FindById(savingGoalId) == null)
            {
                throw new SavingGoalNotFoundException(savingGoalId);
            }

            return _repository.FindContributions(savingGoalId)
                .Select(SavingGoalMapper.ToContributionDto)
                .ToList();
        }

        public SavingGoalOverviewDto GetOverview()
        {
            var goals = _repository.FindAll();
            var live = goals.Where(g => !g.IsArchived).ToList();

            var target = live.Sum(g => g.TargetAmount);
            var saved = live.Sum(g => g.CurrentAmount);

            return new SavingGoalOverviewDto
            {
                TotalGoals = goals.Count,
                ActiveGoals = live.Count(g => g.Status == SavingGoalStatus.IN_PROGRESS),
                CompletedGoals = live.Count(g => g.Status == SavingGoalStatus.COMPLETED),
                OverdueGoals = live.Count(g => g.Status == SavingGoalStatus.OVERDUE),
                TotalTargetAmount = target,
                TotalSavedAmount = saved,
                OverallProgressPercentage = target <= 0m
                    ? 0m
                    : Math.Min(100m, Math.Round(saved / target * 100m, 2))
            };
        }

        private void ValidateGoal(string name, string? description, decimal targetAmount)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ValidationException("Saving goal name cannot be null or empty.");
            }

            if (name.Length > NameMaxLength)
            {
                throw new ValidationException($"Saving goal name cannot exceed {NameMaxLength} characters.");
            }

            if (!string.IsNullOrWhiteSpace(description) && description.Length > DescriptionMaxLength)
            {
                throw new ValidationException($"Saving goal description cannot exceed {DescriptionMaxLength} characters.");
            }

            if (targetAmount <= 0m)
            {
                throw new ValidationException("Target amount must be greater than zero.");
            }
        }
    }
}
