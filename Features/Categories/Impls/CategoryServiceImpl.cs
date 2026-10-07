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

            // With soft delete in place, we keep the category row but mark it
            // as deleted so existing transactions that reference it remain
            // intact for historical reporting. The old blocking rule that
            // forced the category to be empty is no longer needed.

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

