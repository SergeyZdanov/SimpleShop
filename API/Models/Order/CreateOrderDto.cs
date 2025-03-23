using API.Models.OrderItem;
using Shared;

namespace API.Models.Order
{
    public class CreateOrderDto
    {
        public Guid CustomerId { get; set; }

        public int? OrderNumber { get; set; }

        public OrderStatus? Status { get; set; }
        public List<CreateOrderItemDto> Items { get; set; }
    }
}
