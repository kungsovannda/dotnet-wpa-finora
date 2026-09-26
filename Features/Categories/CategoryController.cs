using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Dtos;

namespace PersonalExpenseTracker.Features.Categories
{
    public class CategoryController
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public CategoryResponseDto CreateCategory(CreateCategoryDto dto)
        {
            return _categoryService.CreateCategory(dto);
        }

        public CategoryResponseDto GetCategory(long id)
        {
            return _categoryService.GetCategoryById(id);
        }

        public List<CategoryResponseDto> GetAllCategories()
        {
            return _categoryService.GetAllCategories();
        }

        public CategoryResponseDto UpdateCategory(UpdateCategoryDto dto)
        {
            return _categoryService.UpdateCategory(dto);
        }

        public void DeleteCategory(long id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}

