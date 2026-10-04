using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Dtos;

namespace PersonalExpenseTracker.Features.Transactions
{
    public class TransactionController
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public TransactionResponseDto CreateTransaction(CreateTransactionDto dto)
        {
            return _transactionService.CreateTransaction(dto);
        }

        public TransactionResponseDto GetTransaction(long id)
        {
            return _transactionService.GetTransactionById(id);
        }

        public List<TransactionResponseDto> GetAllTransactions()
        {
            return _transactionService.GetAllTransactions();
        }

        public List<TransactionResponseDto> GetTransactionsByCategory(long categoryId)
        {
            return _transactionService.GetTransactionsByCategory(categoryId);
        }

        public List<TransactionResponseDto> SearchTransactions(TransactionFilter filter)
        {
            return _transactionService.SearchTransactions(filter);
        }

        public TransactionResponseDto UpdateTransaction(UpdateTransactionDto dto)
        {
            return _transactionService.UpdateTransaction(dto);
        }

        public void DeleteTransaction(long id)
        {
            _transactionService.DeleteTransaction(id);
        }
    }
}
