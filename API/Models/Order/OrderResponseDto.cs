using API.Models.OrderItem;
using Shared;

namespace API.Models.Order
{
    public class OrderResponseDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        public string? CustomerName { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public int? OrderNumber { get; set; }
        public OrderStatus? Status { get; set; }

        public List<OrderItemResponseDto> Items { get; set; } = new();
    }
}
