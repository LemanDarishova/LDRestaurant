namespace LDRestaurant.DTOs.Order
{
    public record OrderDetailCreateDto
    {
        public Guid MealID { get; set; }
        public double Unit { get; set; }
    }
}
