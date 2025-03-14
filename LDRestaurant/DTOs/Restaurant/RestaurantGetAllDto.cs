namespace LDRestaurant.DTOs.Restaurant;

public record RestaurantGetAllDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
