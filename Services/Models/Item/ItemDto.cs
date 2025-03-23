using Services.Models.OrderItem;

namespace Services.Models.Item
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = null!;
        public string? Name { get; set; }
        public Decimal? Price { get; set; }
        public string Category { get; set; }
        public virtual ICollection<OrderItemDto> ItemOrders { get; set; } = new List<OrderItemDto>();
    }
}
