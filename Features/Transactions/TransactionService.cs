using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Dtos;

namespace PersonalExpenseTracker.Features.Transactions
{
    public interface TransactionService
    {
        TransactionResponseDto CreateTransaction(CreateTransactionDto dto);

        TransactionResponseDto GetTransactionById(long id);

        List<TransactionResponseDto> GetAllTransactions();

        List<TransactionResponseDto> GetTransactionsByCategory(long categoryId);

        /// <summary>Search, filter and sort, evaluated in the database.</summary>
        List<TransactionResponseDto> SearchTransactions(TransactionFilter filter);

        TransactionResponseDto UpdateTransaction(UpdateTransactionDto dto);

        void DeleteTransaction(long id);
    }
}
