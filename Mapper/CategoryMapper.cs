using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;

namespace PersonalExpenseTracker.Mapper
{
    public class CategoryMapper
    {
        public static Category ToCategory(CreateCategoryDto dto)
        {
            return new Category
            {
                Name = dto.Name,
                Description = dto.Description ?? string.Empty,
                Type = dto.Type,
                Emoji = dto.Emoji ?? string.Empty
            };
        }

        public static Category ToCategory(UpdateCategoryDto dto, Category existingCategory)
        {
            existingCategory.Name = dto.Name;
            existingCategory.Description = dto.Description ?? string.Empty;
            existingCategory.Type = dto.Type;
            existingCategory.Emoji = dto.Emoji ?? string.Empty;
            return existingCategory;
        }

        public static CategoryResponseDto ToCategoryResponseDto(Category category)
        {
            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description ?? string.Empty,
                Type = category.Type,
                Emoji = category.Emoji ?? string.Empty,
                CreatedAt = category.CreatedAt
            };
        }
    }
}
