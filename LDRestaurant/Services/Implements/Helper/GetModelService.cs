using LDRestaurant.Exceptions;
using LDRestaurant.Migrations;
using LDRestaurant.Models;
using LDRestaurant.Repositories.Implements;
using LDRestaurant.Repositories.Implements.MealCategories;
using LDRestaurant.Repositories.Implements.RestaurantCategories;
using LDRestaurant.Repositories.Implements.Restaurants;
using LDRestaurant.Repositories.Interfaces;
using LDRestaurant.Repositories.Interfaces.MealCategories;
using LDRestaurant.Repositories.Interfaces.RestaurantCategories;
using LDRestaurant.Repositories.Interfaces.Restaurants;
using LDRestaurant.Services.Interfaces.Helper;
using System.Net.Http.Headers;

namespace LDRestaurant.Services.Implements.Helper
{

    public class GetModelService : IGetModelService
    {

        private readonly IReadRepository<MealCategory> _mealcategoryreadRepository;    //bu nece yazilmalidir?
        private readonly IReadRepository<RestaurantCategory> _rcategoryreadRepository;
        private readonly IReadRepository<Restaurant> _restaurantreadRepository;

        public GetModelService()
        {
            _mealcategoryreadRepository = new ReadRepository<MealCategory>();
            _rcategoryreadRepository = new ReadRepository<RestaurantCategory>();
            _restaurantreadRepository = new ReadRepository<Restaurant>();
        }
        public async Task<MealCategory> GetMealCategoryAsyn(Guid mealCategoryId)
        {
            var category = await _mealcategoryreadRepository.GetSingleAsync(c => c.Id == mealCategoryId && !c.isDeleted, false);
            if (category == null) throw new NotFoundException("category");
            return category;
        }

        public async Task<Restaurant> GetRestaurantAsync(Guid restaurantId)
        {
            var restaurant = await _restaurantreadRepository.GetSingleAsync(r => r.Id == restaurantId && !r.isDeleted, false);
            if (restaurant == null) throw new NotFoundException("restaurant");
            return restaurant;
        }

        public async Task<RestaurantCategory> GetRestaurantCategoryAsync(Guid restaurantCategoryId)
        {
            var category = await _rcategoryreadRepository.GetSingleAsync(r => r.Id == restaurantCategoryId && !r.isDeleted, false);
            if (category == null) throw new NotFoundException("restaurant category");
            return category;
        }
    }
}
