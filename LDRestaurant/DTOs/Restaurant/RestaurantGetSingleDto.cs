namespace LDRestaurant.DTOs.Restaurant;

public record RestaurantGetSingleDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Phone { get; set; }
    public string CategoryName { get; set; }
}
