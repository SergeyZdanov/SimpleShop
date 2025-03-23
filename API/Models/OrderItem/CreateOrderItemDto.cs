namespace API.Models.OrderItem
{
    public class CreateOrderItemDto
    {
        public Guid OrderId { get; set; }

        public Guid ItemId { get; set; }

        public int ItemsCount { get; set; }

        public int ItemPrice { get; set; }
    }
}
