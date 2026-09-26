using System;
using System.Collections.Generic;
using System.Linq;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Exceptions;

namespace PersonalExpenseTracker.Features.Transactions.Impls
{
    public class TransactionRepositoryImpl : TransactionRepository
    {
        private static List<Transaction> transactions = new List<Transaction>();
        private static long nextId = 1;

        public Transaction Save(Transaction transaction)
        {
            transaction.Id = nextId++;
            transaction.CreatedAt = DateTime.Now;
            transactions.Add(transaction);
            return transaction;
        }

        public Transaction FindById(long id)
        {
            return transactions.FirstOrDefault(t => t.Id == id);
        }

        public List<Transaction> FindAll()
        {
            return new List<Transaction>(transactions);
        }

        public List<Transaction> FindByCategory(long categoryId)
        {
            return transactions.Where(t => t.Category.Id == categoryId).ToList();
        }

        public Transaction Update(Transaction transaction)
        {
            var existingTransaction = FindById(transaction.Id);
            if (existingTransaction == null)
                return null;

            existingTransaction.Category = transaction.Category;
            existingTransaction.Type = transaction.Type;
            existingTransaction.Amount = transaction.Amount;
            existingTransaction.Date = transaction.Date;
            existingTransaction.Description = transaction.Description;
            return existingTransaction;
        }

        public void Delete(long id)
        {
            var transaction = FindById(id);
            if (transaction != null)
            {
                transactions.Remove(transaction);
            }
        }

        public bool ExistsById(long id)
        {
            return transactions.Any(t => t.Id == id);
        }
    }
}
