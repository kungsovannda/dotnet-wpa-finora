using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Features.SavingGoals
{
    public interface SavingGoalRepository
    {
        SavingGoal Save(SavingGoal goal);

        SavingGoal? FindById(long id);

        List<SavingGoal> FindAll();

        List<SavingGoal> FindActive();

        SavingGoal? Update(SavingGoal goal);

        void Delete(long id);

        List<SavingGoalContribution> FindContributions(long savingGoalId);

        /// <summary>
        /// Writes the contribution row and the goal's new saved total in one
        /// save, so the total can never drift from the ledger behind it.
        /// </summary>
        void AddContribution(SavingGoal goal, SavingGoalContribution contribution);

        /// <summary>Removes a contribution and restates the goal's saved total.</summary>
        void RemoveContribution(SavingGoal goal, long contributionId);
    }
}
