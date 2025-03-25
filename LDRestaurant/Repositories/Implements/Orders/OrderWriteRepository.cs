using LDRestaurant.Models;
using LDRestaurant.Repositories.Interfaces.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDRestaurant.Repositories.Implements.Orders
{
    public class OrderWriteRepository: WriteRepository<Order>, IOrderWriteRepository
    {
    }
}
