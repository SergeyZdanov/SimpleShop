namespace API.Models.OrderItem
{
    public class UpdateOrderItemDto
    {
        public Guid OrderItemId { get; set; }

        public Guid OrderId { get; set; }

        public Guid ItemId { get; set; }

        public int ItemsCount { get; set; }

        public Decimal ItemPrice { get; set; }
    }
}
