using System;
using System.Collections.Generic;
using System.Linq;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Exceptions;
using PersonalExpenseTracker.Mapper;

namespace PersonalExpenseTracker.Features.Categories.Impls
{
    public class CategoryServiceImpl : CategoryService
    {
        private readonly CategoryRepository _repository;

        public CategoryServiceImpl(CategoryRepository repository)
        {
            _repository = repository;
        }

        public CategoryResponseDto CreateCategory(CreateCategoryDto dto)
        {
            ValidateCreateCategoryDto(dto);

            if (_repository.ExistsByName(dto.Name))
            {
                throw new DuplicateCategoryException(dto.Name);
            }

            var category = CategoryMapper.ToCategory(dto);
            var savedCategory = _repository.Save(category);

            return CategoryMapper.ToCategoryResponseDto(savedCategory);
        }

        public CategoryResponseDto GetCategoryById(long id)
        {
            var category = _repository.FindById(id);
            if (category == null)
            {
                throw new CategoryNotFoundException(id);
            }

            return CategoryMapper.ToCategoryResponseDto(category);
        }

        public List<CategoryResponseDto> GetAllCategories()
        {
            var categories = _repository.FindAll();
            return categories.Select(c => CategoryMapper.ToCategoryResponseDto(c)).ToList();
        }

        public CategoryResponseDto UpdateCategory(UpdateCategoryDto dto)
        {
            ValidateUpdateCategoryDto(dto);

            if (!_repository.ExistsById(dto.Id))
            {
                throw new CategoryNotFoundException(dto.Id);
            }

            var existingCategory = _repository.FindById(dto.Id);
            var otherCategoryWithSameName = _repository.FindAll()
                .FirstOrDefault(c => c.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase) && c.Id != dto.Id);

            if (otherCategoryWithSameName != null)
            {
                throw new DuplicateCategoryException(dto.Name);
            }

            if (existingCategory == null)
            {
                throw new CategoryNotFoundException(dto.Id);
            }

            var updatedCategory = CategoryMapper.ToCategory(dto, existingCategory);
            _repository.Update(updatedCategory);

            return CategoryMapper.ToCategoryResponseDto(updatedCategory);
        }

        public void DeleteCategory(long id)
        {
            if (!_repository.ExistsById(id))
            {
                throw new CategoryNotFoundException(id);
            }

            // Deleting a category that still has transactions would take real
            // financial history with it, so the category is kept until it is
            // empty. The user is told how many records are in the way rather
            // than being offered a silent cascade.
            int inUse = _repository.CountTransactions(id);
            if (inUse > 0)
            {
                throw new ValidationException(inUse == 1
                    ? "This category still has 1 transaction. Move or delete it before removing the category."
                    : $"This category still has {inUse} transactions. Move or delete them before removing the category.");
            }

            _repository.Delete(id);
        }

        private void ValidateCreateCategoryDto(CreateCategoryDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ValidationException("Category name cannot be null or empty.");
            }

            if (dto.Name.Length > 100)
            {
                throw new ValidationException("Category name cannot exceed 100 characters.");
            }
        }

        private void ValidateUpdateCategoryDto(UpdateCategoryDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ValidationException("Category name cannot be null or empty.");
            }

            if (dto.Name.Length > 100)
            {
                throw new ValidationException("Category name cannot exceed 100 characters.");
            }
        }
    }
}

