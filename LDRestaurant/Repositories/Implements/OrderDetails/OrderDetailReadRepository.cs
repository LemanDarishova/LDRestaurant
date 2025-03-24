using LDRestaurant.Models;
using LDRestaurant.Repositories.Interfaces.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDRestaurant.Repositories.Implements.OrderDetails
{
    public class OrderDetailReadRepository : ReadRepository<OrderDetail>, IOrderDetailReadRepository
    {
    }
}
