using LDRestaurant.DTOs.Order;
using LDRestaurant.Models;
using LDRestaurant.Repositories.Interfaces.OrderDetails;
using LDRestaurant.Repositories.Interfaces.Orders;
using LDRestaurant.Services.Interfaces;
using LDRestaurant.Services.Interfaces.Helper;

namespace LDRestaurant.Services.Implements
{
    public class OrderService : IOrderService
    {
        private IOrderWriteRepository _writeRepository;
        private IOrderDetailWriteRepository _detailWriteRepository;
        private IGetModelService _getEntity;

        private string GenerateTrackingNumber()
        {
            var date = DateTime.Now.AddHours(4);
            var trackingString = $"{date}";
            return trackingString;
        }

        public async Task AddAsync(OrderCreateDto addDto)
        {
            var customer = await _getEntity.GetCustomerAsync(addDto.CustomerID);
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerID = customer.Id,
                TrackingID = GenerateTrackingNumber()
            };
            foreach (var detailDto in addDto.DetailsDtos)
            {
                var meal = await _getEntity.GetMealAsync(detailDto.MealID);
                var detail = new OrderDetail
                {
                    Id = Guid.NewGuid(),
                    MealID = meal.Id,
                    Unit = detailDto.Unit,
                    Price = (meal.Price * detailDto.Unit),
                    OrderID = order.Id
                };
                await _detailWriteRepository.AddAsync(detail);
            }

            order.TotalPrice = order.Details.Sum(od => od.Price);

            await _writeRepository.AddAsync(order);
            await _writeRepository.SaveAsync();
            await _detailWriteRepository.SaveAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderGetAllDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderGetSingleDto> GetSingleAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RecoverAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, OrderUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
