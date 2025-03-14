using LDRestaurant.DTOs.Meal;

namespace LDRestaurant.Services.Interfaces;

public interface IMealService : IGenericService<MealCommandDto, MealCommandDto, MealGetAllDto, MealGetSingleDto>
{
}
