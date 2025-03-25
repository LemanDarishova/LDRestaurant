namespace LDRestaurant.DTOs.Order
{
    public class OrderGetAllDto
    {
        public string Id { get; set; }
        public string OrderTrackingNumber { get; set; }
        public string CustomerName { get; set; }
        public double TotalPrice { get; set; }
        public double TotalCounts { get; set; }
    }
}
