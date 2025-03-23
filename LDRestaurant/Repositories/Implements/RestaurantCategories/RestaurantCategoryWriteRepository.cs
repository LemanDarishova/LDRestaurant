using LDRestaurant.Models;
using LDRestaurant.Repositories.Interfaces.RestaurantCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDRestaurant.Repositories.Implements.RestaurantCategories
{
    public class RestaurantCategoryWriteRepository : WriteRepository<RestaurantCategory>, IRestaurantCategoryWriteRepository
    {
    }
}
