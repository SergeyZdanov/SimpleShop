namespace Services.Models.OrderItem
{
    public class UpdateOrderItem
    {
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }

        public Guid ItemId { get; set; }

        public int ItemsCount { get; set; }
        public Decimal ItemPrice { get; set; }
    }
}
