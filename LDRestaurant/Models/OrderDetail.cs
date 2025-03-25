using LDRestaurant.Models.BaseModels;

namespace LDRestaurant.Models
{
    public class OrderDetail:BaseEntity
    {
        public Guid OrderID { get; set; }
        public Order Order { get; set; }
        public Guid MealID { get; set; }
        public Meal Meal { get; set; }
        public double Unit { get; set; } //porsiya
        public double Price { get; set; } //porsiyaya uygun qiymet
    }
}
