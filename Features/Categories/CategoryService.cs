using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;

namespace PersonalExpenseTracker.Features.Categories
{
    public interface CategoryService
    {
        CategoryResponseDto CreateCategory(CreateCategoryDto dto);

        CategoryResponseDto GetCategoryById(long id);

        List<CategoryResponseDto> GetAllCategories();

        CategoryResponseDto UpdateCategory(UpdateCategoryDto dto);

        void DeleteCategory(long id);
    }
}
