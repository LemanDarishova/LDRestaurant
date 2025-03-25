namespace LDRestaurant.DTOs.Order
{
    public class OrderCreateDto
    {
        public Guid CustomerID { get; set; }
        public ICollection<OrderDetailCreateDto> DetailsDtos { get; set; } = new List<OrderDetailCreateDto>();
    }
}
