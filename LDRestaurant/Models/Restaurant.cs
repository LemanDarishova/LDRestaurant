using LDRestaurant.Models.BaseModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace LDRestaurant.Models
{
    public class Restaurant:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }

        //Relations

        [ForeignKey(nameof(RestoranCategory))]
        public Guid CategoryID { get; set; }
        public RestaurantCategory RestoranCategory { get; set; }
        public ICollection<Meal> Meals { get; set; } = new List<Meal>();// one-to-many elaqe., null olma sertinde kod partlamasin
        
    }
}
