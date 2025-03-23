namespace Services.Models.OrderItem
{
    public class OrderItemDto
    {
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public int ItemsCount { get; set; }
        public Decimal ItemPrice { get; set; }
    }
}
