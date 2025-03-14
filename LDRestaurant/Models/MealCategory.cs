using LDRestaurant.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDRestaurant.Models;

public class MealCategory:BaseEntity
{
    public string Name { get; set; }

    //Relations
    public ICollection<Meal> Meals { get; set; } = new List<Meal>();

}
