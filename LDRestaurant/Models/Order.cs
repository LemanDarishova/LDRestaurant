using LDRestaurant.Models.BaseModels;

namespace LDRestaurant.Models
{
    public class Order:BaseEntity
    {
        public string TrackingID { get; set; }
        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }
        public double TotalPrice { get; set; }

        public ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>();
    }
}
