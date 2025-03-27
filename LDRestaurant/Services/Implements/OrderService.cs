using LDRestaurant.DTOs.Order;
using LDRestaurant.Exceptions;
using LDRestaurant.Models;
using LDRestaurant.Repositories.Implements.OrderDetails;
using LDRestaurant.Repositories.Implements.Orders;
using LDRestaurant.Repositories.Interfaces.OrderDetails;
using LDRestaurant.Repositories.Interfaces.Orders;
using LDRestaurant.Services.Implements.Helper;
using LDRestaurant.Services.Interfaces;
using LDRestaurant.Services.Interfaces.Helper;
using Microsoft.EntityFrameworkCore;

namespace LDRestaurant.Services.Implements
{
    public class OrderService : IOrderService
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderDetailWriteRepository _detailWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IGetModelService _getEntity;

        public OrderService()
        {
            _orderWriteRepository = new OrderWriteRepository();
            _detailWriteRepository = new OrderDetailWriteRepository();
            _orderReadRepository = new OrderReadRepository();
            _getEntity = new GetModelService();
        }
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
                order.Details.Add(detail);
                await _detailWriteRepository.AddAsync(detail);
            }

            order.TotalPrice += order.Details.Sum(od => od.Price);

            await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.SaveAsync();
            await _detailWriteRepository.SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await _orderReadRepository.GetSingleAsync(o => o.Id == id && !o.isDeleted, true, "Details");
            if (order == null) throw new NotFoundException("order");

            if (order.Details.Count() > 0)
            {
                foreach (var detail in order.Details)
                {
                    _detailWriteRepository.Delete(detail);
                }

            }
            _orderWriteRepository.Delete(order);
            await _detailWriteRepository.SaveAsync();
            await _orderWriteRepository.SaveAsync();
        }

        public async Task<List<OrderGetAllDto>> GetAllAsync(Guid customerId)
        {
            var customer = await _getEntity.GetCustomerAsync(customerId);
            var query = _orderReadRepository.GetAllWhere(o => o.CustomerID == customer.Id, false, "Details", "Customer");
            var dtos = new List<OrderGetAllDto>();
            dtos = await query.Select(order => new OrderGetAllDto
            {
                Id = order.Id.ToString(),
                OrderTrackingNumber = order.TrackingID,
                TotalPrice = order.TotalPrice,
                CustomerName = order.Customer.FullName,
                TotalCounts = order.Details.Sum(d => d.Unit)
            }).ToListAsync();
            return dtos;
        }

        public async Task<OrderGetSingleDto> GetSingleAsync(Guid id)
        {
            var order = await _orderReadRepository.GetSingleAsync(o => o.Id == id, false, "Details.Meal.Restaurant", "Customer");
            if (order == null) throw new NotFoundException("order");
            var dto = new OrderGetSingleDto()
            {
                Id = order.Id.ToString(),
                OrderTrackingNumber = order.TrackingID,
                TotalPrice = order.TotalPrice,
                CustomerName = order.Customer.FullName,
                TotalCounts = order.Details.Sum(d => d.Unit),
                RestaurantName = order.Details.FirstOrDefault().Meal.Restaurant.Name,
                DetailGetDtos = order.Details.Select(detail => new OrderDetailGetDto
                {
                    Id = detail.Id.ToString(),
                    MealName = detail.Meal.Name,
                    Price = detail.Price,
                    Unit = detail.Unit
                }).ToList()
            };
            return dto;
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
            _orderWriteRepository.Recover(order);
            await _detailWriteRepository.SaveAsync();
            await _orderWriteRepository.SaveAsync();
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
            _orderWriteRepository.Remove(order);
            await _detailWriteRepository.SaveAsync();
            await _orderWriteRepository.SaveAsync();
        }

    }
}
