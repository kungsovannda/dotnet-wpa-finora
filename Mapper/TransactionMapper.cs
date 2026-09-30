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
                CategoryId = category.Id,
                Type = dto.Type,
                Amount = dto.Amount,
                Date = dto.Date,
                Description = dto.Description,
                PaymentMethod = dto.PaymentMethod,
                Reference = OrEmpty(dto.Reference),
                Merchant = OrEmpty(dto.Merchant)
            };
        }

        public static Transaction ToTransaction(UpdateTransactionDto dto, Transaction existingTransaction, Category category)
        {
            existingTransaction.Category = category;
            existingTransaction.CategoryId = category.Id;
            existingTransaction.Type = dto.Type;
            existingTransaction.Amount = dto.Amount;
            existingTransaction.Date = dto.Date;
            existingTransaction.Description = dto.Description;
            existingTransaction.PaymentMethod = dto.PaymentMethod;
            existingTransaction.Reference = OrEmpty(dto.Reference);
            existingTransaction.Merchant = OrEmpty(dto.Merchant);
            return existingTransaction;
        }

        public static TransactionResponseDto ToTransactionResponseDto(Transaction transaction)
        {
            return new TransactionResponseDto
            {
                Id = transaction.Id,
                CategoryId = transaction.CategoryId,
                CategoryName = transaction.Category?.Name ?? string.Empty,
                Type = transaction.Type,
                Amount = transaction.Amount,
                Date = transaction.Date,
                Description = transaction.Description,
                PaymentMethod = transaction.PaymentMethod,
                Reference = OrEmpty(transaction.Reference),
                Merchant = OrEmpty(transaction.Merchant),
                CreatedAt = transaction.CreatedAt,
                UpdatedAt = transaction.UpdatedAt
            };
        }

        /// <summary>
        /// The optional text columns are non-nullable in the schema, so an empty
        /// text field in the dialog arrives here as an empty string rather than
        /// a null that would fail the insert.
        /// </summary>
        private static string OrEmpty(string? value) => value ?? string.Empty;
    }
}
