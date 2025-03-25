using LDRestaurant.Models;
using LDRestaurant.Repositories.Interfaces.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDRestaurant.Repositories.Implements.Customers
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
    }
}
