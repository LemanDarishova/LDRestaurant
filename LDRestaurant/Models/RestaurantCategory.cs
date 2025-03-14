using LDRestaurant.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDRestaurant.Models;

public class RestaurantCategory : BaseCategory
{
   public ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();

}
