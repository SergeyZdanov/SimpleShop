namespace API.Models.OrderItem
{
    public class OrderItemResponseDto
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }

        public string? ItemName { get; set; }

        public int ItemsCount { get; set; }
        public Decimal ItemPrice { get; set; }
    }
}
