using Shared;

namespace API.Models.Order
{
    public class UpdateOrderDto
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime? ShipmentDate { get; set; }
        public int? OrderNumber { get; set; }
        public OrderStatus? Status { get; set; }

    }
}
