using LDRestaurant.DTOs.Order;

namespace LDRestaurant.Services.Interfaces
{
    public interface IOrderService:IGenericService<OrderCreateDto, OrderUpdateDto, OrderGetAllDto, OrderGetSingleDto>
    {
    }
}
