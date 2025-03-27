using LDRestaurant.DTOs.Order;

namespace LDRestaurant.Services.Interfaces
{
    public interface IOrderService
    {
        public Task AddAsync(OrderCreateDto addDto);
        public Task RemoveAsync(Guid id);
        public Task DeleteAsync(Guid id);
        public Task RecoverAsync(Guid id);
        public Task<OrderGetSingleDto> GetSingleAsync(Guid id);
        public Task<List<OrderGetAllDto>> GetAllAsync(Guid customerId);
    }
}
