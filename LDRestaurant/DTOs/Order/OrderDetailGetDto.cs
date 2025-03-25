namespace LDRestaurant.DTOs.Order
{
    public record OrderDetailGetDto
    {
        public string Id { get; set; }
        public string MealName { get; set; }
        public string RestaurantName { get; set; }
        public double Unit { get; set; }
        public double Price { get; set; }
    }
}
