using LDRestaurant.Exceptions;
using LDRestaurant.Models;
using LDRestaurant.Repositories.Implements;
using LDRestaurant.Repositories.Interfaces;
using LDRestaurant.Services.Interfaces.Helper;

namespace LDRestaurant.Services.Implements.Helper
{
    public class GetModelService : IGetModelService
    {
        private readonly IReastaurantRepository _restaurantRepository;
        private readonly IMealCategoryRepository _mealCategoryRepository;

        public GetModelService()
        {
            _restaurantRepository = new RestaurantRepository();
            _mealCategoryRepository = new MealCategoryRepository();
        }
        public async Task<MealCategory> GetMealCategoryAsyn(Guid mealCategoryId)
        {
            var category = await _mealCategoryRepository.GetSingleAsync(c => c.Id == mealCategoryId && !c.isDeleted, false);
            if (category == null) throw new NotFoundException("category");
            return category;
        }

        public async Task<Restaurant> GetRestaurantAsync(Guid restaurantId)
        {
            var restaurant = await _restaurantRepository.GetSingleAsync(r => r.Id == restaurantId && !r.isDeleted, false);
            if (restaurant == null) throw new NotFoundException("restaurant");
            return restaurant;
        }
    }
}
