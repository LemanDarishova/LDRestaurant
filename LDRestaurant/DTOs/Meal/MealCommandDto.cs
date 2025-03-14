namespace LDRestaurant.DTOs.Meal
{
    public record MealCommandDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        //public IFormFile file { get; set; }        
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public Guid RestaurantID { get; set; } // foreign key (burada int yoxsa Guid yazilmalidir daha dogru olsun deye?)
        public Guid CategoryID { get; set; }
    }
}
