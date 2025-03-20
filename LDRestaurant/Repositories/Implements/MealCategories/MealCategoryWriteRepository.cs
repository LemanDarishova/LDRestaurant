using LDRestaurant.Models;
using LDRestaurant.Repositories.Interfaces.MealCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDRestaurant.Repositories.Implements.MealCategories
{
    public class MealCategoryWriteRepository : WriteRepository<MealCategory>, IMealCategoryWriteRepository
    {
        public Task<MealCategory> GetSingleAsync(Func<object, object> value, bool v)
        {
            throw new NotImplementedException();
        }
    }
}
