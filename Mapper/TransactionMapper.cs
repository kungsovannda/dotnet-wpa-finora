using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;

namespace PersonalExpenseTracker.Mapper
{
    public class TransactionMapper
    {
        public static Transaction ToTransaction(CreateTransactionDto dto, Category category)
        {
            return new Transaction
            {
                Category = category,
                Type = dto.Type,
                Amount = dto.Amount,
                Date = dto.Date,
                Description = dto.Description
            };
        }

        public static Transaction ToTransaction(UpdateTransactionDto dto, Transaction existingTransaction, Category category)
        {
            existingTransaction.Category = category;
            existingTransaction.Type = dto.Type;
            existingTransaction.Amount = dto.Amount;
            existingTransaction.Date = dto.Date;
            existingTransaction.Description = dto.Description;
            return existingTransaction;
        }

        public static TransactionResponseDto ToTransactionResponseDto(Transaction transaction)
        {
            return new TransactionResponseDto
            {
                Id = transaction.Id,
                CategoryId = transaction.Category.Id,
                CategoryName = transaction.Category.Name,
                Type = transaction.Type,
                Amount = transaction.Amount,
                Date = transaction.Date,
                Description = transaction.Description,
                CreatedAt = transaction.CreatedAt
            };
        }
    }
}
