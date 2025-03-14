using LDRestaurant.Models.BaseModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace LDRestaurant.Models;

public class Meal : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImageName { get; set; }
    public string ImgUrl { get; set; }
    //Relations
    [ForeignKey(nameof(Restaurant))] //adlar eyni olmadiqda, FK casdirmasin deye bele yazilir.
    public Guid RestaurantID { get; set; } // foreign key (burada int yoxsa Guid yazilmalidir daha dogru olsun deye?)
    public Restaurant Restaurant { get; set; } //navigation property
    [ForeignKey(nameof(MealCategory))]
    public Guid CategoryID { get; set; }
    public MealCategory MealCategory { get; set; }
}
