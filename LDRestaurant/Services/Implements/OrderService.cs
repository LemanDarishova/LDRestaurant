using LDRestaurant.DTOs.Order;
using LDRestaurant.Exceptions;
using LDRestaurant.Models;
using LDRestaurant.Repositories.Interfaces.OrderDetails;
using LDRestaurant.Repositories.Interfaces.Orders;
using LDRestaurant.Services.Interfaces;
using LDRestaurant.Services.Interfaces.Helper;

namespace LDRestaurant.Services.Implements
{
    public class OrderService : IOrderService
    {
        private readonly IOrderWriteRepository _writeRepository;
        private readonly IOrderDetailWriteRepository _detailWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IGetModelService _getEntity;

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

        public async Task DeleteAsync(Guid id)
        {
            var order = await _orderReadRepository.GetSingleAsync(o => o.Id == id && !o.isDeleted, true, "Details");
            if (order == null) throw new NotFoundException("order");

            if(order.Details.Count()>0)
            {
                foreach(var detail in order.Details)
                {
                    _detailWriteRepository.Delete(detail);
                }

            }
            _writeRepository.Delete(order);
            await _detailWriteRepository.SaveAsync();
            await _writeRepository.SaveAsync();
        }

        public Task<List<OrderGetAllDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderGetSingleDto> GetSingleAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task RecoverAsync(Guid id)
        {
            var order = await _orderReadRepository.GetSingleAsync(o => o.Id == id && o.isDeleted, true, "Details");
            if (order == null) throw new NotFoundException("order");

            if (order.Details.Count() > 0)
            {
                foreach (var detail in order.Details)
                {
                    _detailWriteRepository.Recover(detail);
                }

            }
            _writeRepository.Recover(order);
            await _detailWriteRepository.SaveAsync();
            await _writeRepository.SaveAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var order = await _orderReadRepository.GetSingleAsync(o => o.Id == id, true, "Details");
            if (order == null) throw new NotFoundException("order");

            if (order.Details.Count() > 0)
            {
                foreach (var detail in order.Details)
                {
                    _detailWriteRepository.Remove(detail);
                }

            }
            _writeRepository.Remove(order);
            await _detailWriteRepository.SaveAsync();
            await _writeRepository.SaveAsync();
        }

        public Task UpdateAsync(Guid id, OrderUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
