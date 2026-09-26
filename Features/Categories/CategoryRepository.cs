using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Features.Categories
{
    public interface CategoryRepository
    {
        Category Save(Category category);

        Category FindById(long id);

        List<Category> FindAll();

        Category Update(Category category);

        void Delete(long id);

        bool ExistsByName(string name);

        bool ExistsById(long id);
    }
}
