namespace LDRestaurant.DTOs.Restaurant;

public record RestaurantCommandDto //record vs class interview sualidir.
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Phone { get; set; }
}
//dto-daki propertyler ile modeldeki propertyler eyni tipde olmaya biler.