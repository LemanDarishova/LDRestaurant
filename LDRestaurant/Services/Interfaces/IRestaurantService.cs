using LDRestaurant.DTOs.Restaurant;

namespace LDRestaurant.Services.Interfaces;

public interface IRestaurantService : IGenericService<RestaurantCommandDto, RestaurantCommandDto, RestaurantGetAllDto, RestaurantGetSingleDto>
{
}
