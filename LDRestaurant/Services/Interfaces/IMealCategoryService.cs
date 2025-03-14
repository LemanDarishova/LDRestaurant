using LDRestaurant.DTOs.MealCategory;

namespace LDRestaurant.Services.Interfaces;

public interface IMealCategoryService : IGenericService<MealCategoryCommandDto, MealCategoryCommandDto, MealCategoryGetDto, MealCategoryGetDto>
{
}
