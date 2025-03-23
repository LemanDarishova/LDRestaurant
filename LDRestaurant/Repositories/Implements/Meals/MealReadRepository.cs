using LDRestaurant.Models;
using LDRestaurant.Repositories.Interfaces.Meals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDRestaurant.Repositories.Implements.Meals
{
    public class MealReadRepository : ReadRepository<Meal>,  IMealReadRepository
    {
    }
}
