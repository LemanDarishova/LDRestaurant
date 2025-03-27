using LDRestaurant.Exceptions;
using LDRestaurant.Migrations;
using LDRestaurant.Models;
using LDRestaurant.Repositories.Implements;
using LDRestaurant.Repositories.Implements.Customers;
using LDRestaurant.Repositories.Implements.MealCategories;
using LDRestaurant.Repositories.Implements.Meals;
using LDRestaurant.Repositories.Implements.Orders;
using LDRestaurant.Repositories.Implements.RestaurantCategories;
using LDRestaurant.Repositories.Implements.Restaurants;
using LDRestaurant.Repositories.Interfaces;
using LDRestaurant.Repositories.Interfaces.Customers;
using LDRestaurant.Repositories.Interfaces.MealCategories;
using LDRestaurant.Repositories.Interfaces.Meals;
using LDRestaurant.Repositories.Interfaces.OrderDetails;
using LDRestaurant.Repositories.Interfaces.Orders;
using LDRestaurant.Repositories.Interfaces.RestaurantCategories;
using LDRestaurant.Repositories.Interfaces.Restaurants;
using LDRestaurant.Services.Interfaces.Helper;
using System.Net.Http.Headers;

namespace LDRestaurant.Services.Implements.Helper
{

    public class GetModelService : IGetModelService
    {

        private readonly IMealCategoryReadRepository _mealcategoryreadRepository;    //bu nece yazilmalidir?
        private readonly IRestaurantCategoryReadRepository _rcategoryreadRepository;
        private readonly IRestaurantReadRepository _restaurantreadRepository;
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly IMealReadRepository _mealReadRepository;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderDetailReadRepository _orderDetailReadRepository;

        public GetModelService()
        {
            _mealcategoryreadRepository = new MealCategoryReadRepository();
            _rcategoryreadRepository = new RestaurantCategoryReadRepository();
            _restaurantreadRepository = new RestaurantReadRespoitory();
            _customerReadRepository = new CustomerReadRepository();
            _mealReadRepository = new MealReadRepository();
            _orderReadRepository = new OrderReadRepository();
        }

        public async Task<Customer> GetCustomerAsync(Guid customerId)
        {
            var customer = await _customerReadRepository.GetSingleAsync(c => c.Id == customerId && !c.isDeleted, false);
            if (customer == null) throw new NotFoundException("customer");
            return customer;
        }

        public async Task<Meal> GetMealAsync(Guid mealId)
        {
            var meal = await _mealReadRepository.GetSingleAsync(c => c.Id == mealId && !c.isDeleted, false);
            if (meal == null) throw new NotFoundException("meal");
            return meal;
        }

        public async Task<MealCategory> GetMealCategoryAsyn(Guid mealCategoryId)
        {
            var category = await _mealcategoryreadRepository.GetSingleAsync(c => c.Id == mealCategoryId && !c.isDeleted, false);
            if (category == null) throw new NotFoundException("category");
            return category;
        }

        public async Task<Order> GetOrderAsync(Guid OrderId)
        {
            var order = await _orderReadRepository.GetSingleAsync(c => c.Id == OrderId && !c.isDeleted, false);
            if (order == null) throw new NotFoundException("order");
            return order;
        }

        public async Task<OrderDetail> GetOrderDetailAsync(Guid OrderDetailId)
        {
            var orderdetail = await _orderDetailReadRepository.GetSingleAsync(c => c.Id == OrderDetailId && !c.isDeleted, false);
            if (orderdetail == null) throw new NotFoundException("order");
            return orderdetail;
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
