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
                Description = dto.Description,
                Type = dto.Type,
                Emoji = dto.Emoji
            };
        }

        public static Category ToCategory(UpdateCategoryDto dto, Category existingCategory)
        {
            existingCategory.Name = dto.Name;
            existingCategory.Description = dto.Description;
            existingCategory.Type = dto.Type;
            existingCategory.Emoji = dto.Emoji;
            return existingCategory;
        }

        public static CategoryResponseDto ToCategoryResponseDto(Category category)
        {
            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Type = category.Type,
                Emoji = category.Emoji,
                CreatedAt = category.CreatedAt
            };
        }
    }
}
