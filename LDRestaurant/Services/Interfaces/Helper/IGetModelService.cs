using LDRestaurant.Models;

namespace LDRestaurant.Services.Interfaces.Helper
{
    public interface IGetModelService
    {
        Task<MealCategory> GetMealCategoryAsyn(Guid mealCategoryId);
        Task<Restaurant> GetRestaurantAsync(Guid restaurantId);
    }
}
