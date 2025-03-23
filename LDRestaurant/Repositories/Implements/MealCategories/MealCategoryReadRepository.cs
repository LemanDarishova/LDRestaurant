using LDRestaurant.Models;
using LDRestaurant.Repositories.Interfaces.MealCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDRestaurant.Repositories.Implements.MealCategories
{
    public class MealCategoryReadRepository : ReadRepository<MealCategory>, IMealCategoryReadRepository
    {
    }
}
