using LDRestaurant.Models;

namespace LDRestaurant.Services.Interfaces.Helper
{
    public interface IGetModelService
    {
        Task<MealCategory> GetMealCategoryAsyn(Guid mealCategoryId);
        Task<Restaurant> GetRestaurantAsync(Guid restaurantId);
        Task<RestaurantCategory> GetRestaurantCategoryAsync(Guid restaurantCategoryId);
        Task<Customer> GetCustomerAsync(Guid customerId);
        Task<Meal> GetMealAsync(Guid mealId);
        Task<Order> GetOrderAsync(Guid OrderId);
    }
}
