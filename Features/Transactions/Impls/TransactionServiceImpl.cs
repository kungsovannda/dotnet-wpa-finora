using System;
using System.Collections.Generic;
using System.Linq;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Exceptions;
using PersonalExpenseTracker.Mapper;

namespace PersonalExpenseTracker.Features.Transactions.Impls
{
    public class TransactionServiceImpl : TransactionService
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly Features.Categories.CategoryRepository _categoryRepository;

        public TransactionServiceImpl(TransactionRepository transactionRepository, Features.Categories.CategoryRepository categoryRepository)
        {
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
        }

        public TransactionResponseDto CreateTransaction(CreateTransactionDto dto)
        {
            ValidateCreateTransactionDto(dto);

            var category = _categoryRepository.FindById(dto.CategoryId);
            if (category == null)
            {
                throw new CategoryNotFoundException(dto.CategoryId);
            }

            var transaction = TransactionMapper.ToTransaction(dto, category);
            var savedTransaction = _transactionRepository.Save(transaction);

            return TransactionMapper.ToTransactionResponseDto(savedTransaction);
        }

        public TransactionResponseDto GetTransactionById(long id)
        {
            var transaction = _transactionRepository.FindById(id);
            if (transaction == null)
            {
                throw new TransactionNotFoundException(id);
            }

            return TransactionMapper.ToTransactionResponseDto(transaction);
        }

        public List<TransactionResponseDto> GetAllTransactions()
        {
            var transactions = _transactionRepository.FindAll();
            return transactions.Select(t => TransactionMapper.ToTransactionResponseDto(t)).ToList();
        }

        public List<TransactionResponseDto> GetTransactionsByCategory(long categoryId)
        {
            if (!_categoryRepository.ExistsById(categoryId))
            {
                throw new CategoryNotFoundException(categoryId);
            }

            var transactions = _transactionRepository.FindByCategory(categoryId);
            return transactions.Select(t => TransactionMapper.ToTransactionResponseDto(t)).ToList();
        }

        public List<TransactionResponseDto> SearchTransactions(TransactionFilter filter)
        {
            var transactions = _transactionRepository.Find(filter ?? new TransactionFilter());
            return transactions.Select(t => TransactionMapper.ToTransactionResponseDto(t)).ToList();
        }

        public TransactionResponseDto UpdateTransaction(UpdateTransactionDto dto)
        {
            ValidateUpdateTransactionDto(dto);

            if (!_transactionRepository.ExistsById(dto.Id))
            {
                throw new TransactionNotFoundException(dto.Id);
            }

            var category = _categoryRepository.FindById(dto.CategoryId);
            if (category == null)
            {
                throw new CategoryNotFoundException(dto.CategoryId);
            }

            var existingTransaction = _transactionRepository.FindById(dto.Id);
            if (existingTransaction == null)
            {
                throw new TransactionNotFoundException(dto.Id);
            }

            var updatedTransaction = TransactionMapper.ToTransaction(dto, existingTransaction, category);
            _transactionRepository.Update(updatedTransaction);

            return TransactionMapper.ToTransactionResponseDto(updatedTransaction);
        }

        public void DeleteTransaction(long id)
        {
            if (!_transactionRepository.ExistsById(id))
            {
                throw new TransactionNotFoundException(id);
            }

            _transactionRepository.Delete(id);
        }

        private void ValidateCreateTransactionDto(CreateTransactionDto dto)
        {
            if (dto.Amount <= 0)
            {
                throw new ValidationException("Transaction amount must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(dto.Description) || dto.Description.Length > 255)
            {
                throw new ValidationException("Transaction description must be provided and not exceed 255 characters.");
            }

            if (!string.IsNullOrWhiteSpace(dto.Merchant) && dto.Merchant.Length > 120)
            {
                throw new ValidationException("Merchant cannot exceed 120 characters.");
            }

            if (!string.IsNullOrWhiteSpace(dto.Reference) && dto.Reference.Length > 64)
            {
                throw new ValidationException("Reference cannot exceed 64 characters.");
            }
        }

        private void ValidateUpdateTransactionDto(UpdateTransactionDto dto)
        {
            if (dto.Amount <= 0)
            {
                throw new ValidationException("Transaction amount must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(dto.Description) || dto.Description.Length > 255)
            {
                throw new ValidationException("Transaction description must be provided and not exceed 255 characters.");
            }

            if (!string.IsNullOrWhiteSpace(dto.Merchant) && dto.Merchant.Length > 120)
            {
                throw new ValidationException("Merchant cannot exceed 120 characters.");
            }

            if (!string.IsNullOrWhiteSpace(dto.Reference) && dto.Reference.Length > 64)
            {
                throw new ValidationException("Reference cannot exceed 64 characters.");
            }
        }
    }
}
