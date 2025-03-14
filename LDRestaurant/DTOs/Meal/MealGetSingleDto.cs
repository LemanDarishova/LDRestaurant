using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDRestaurant.DTOs.Meal;

public record MealGetSingleDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImageName { get; set; }
    public string ImgUrl { get; set; }
    public string Category { get; set; }
    public string Restaurant { get; set; }


}
