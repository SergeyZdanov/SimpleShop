using Shared;

namespace Services.Models.Order
{
    public class UpdateOrder
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public int? OrderNumber { get; set; }
        public OrderStatus? Status { get; set; }
    }
}
