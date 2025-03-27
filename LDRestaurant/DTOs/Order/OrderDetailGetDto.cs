namespace LDRestaurant.DTOs.Order
{
    public record OrderDetailGetDto
    {
        public string Id { get; set; }
        public string MealName { get; set; }
        //public string RestaurantName { get; set; } eger bir sifarisde olan restaranlar ferqli olsaydi, detail icerisinden adini cekecekdik. Lakin, bizim proyektde sifarisler yalniz 1 restorandna alina bildiyine gore restaran adini order dto-da vermeyimiz kifayet edir.
        public double Unit { get; set; }
        public double Price { get; set; }
    }
}
