using System;
using System.Collections.Generic;
using System.Linq;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Features.Categories.Impls
{
    public class CategoryRepositoryImpl : CategoryRepository
    {
        private static List<Category> categories = new List<Category>();
        private static long nextId = 1;

        public Category Save(Category category)
        {
            category.Id = nextId++;
            category.CreatedAt = DateTime.Now;
            categories.Add(category);
            return category;
        }

        public Category FindById(long id)
        {
            return categories.FirstOrDefault(c => c.Id == id);
        }

        public List<Category> FindAll()
        {
            return new List<Category>(categories);
        }

        public Category Update(Category category)
        {
            var existingCategory = FindById(category.Id);
            if (existingCategory == null)
                return null;

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            return existingCategory;
        }

        public void Delete(long id)
        {
            var category = FindById(id);
            if (category != null)
            {
                categories.Remove(category);
            }
        }

        public bool ExistsByName(string name)
        {
            return categories.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public bool ExistsById(long id)
        {
            return categories.Any(c => c.Id == id);
        }
    }
}
