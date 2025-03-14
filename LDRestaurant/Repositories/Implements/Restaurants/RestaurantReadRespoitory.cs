using LDRestaurant.Models;
using LDRestaurant.Repositories.Interfaces.Restaurants;

namespace LDRestaurant.Repositories.Implements.Restaurants
{
    public class RestaurantReadRespoitory:ReadRepository<Restaurant>, IRestaurantReadRepository
    {
    }
}
