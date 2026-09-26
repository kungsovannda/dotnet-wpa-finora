using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Features.Transactions
{
    public interface TransactionRepository
    {
        Transaction Save(Transaction transaction);

        Transaction FindById(long id);

        List<Transaction> FindAll();

        List<Transaction> FindByCategory(long categoryId);

        Transaction Update(Transaction transaction);

        void Delete(long id);

        bool ExistsById(long id);
    }
}
