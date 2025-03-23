using Shared;

namespace Database.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public int? OrderNumber { get; set; }
        public OrderStatus? Status { get; set; }
        public virtual Customer? Customer { get; set; } = null!;
        public virtual ICollection<OrderItem> ItemOrders { get; set; }
    }
}
