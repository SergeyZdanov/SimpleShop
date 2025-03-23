namespace Database.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public int ItemsCount { get; set; }
        public Decimal ItemPrice { get; set; }
        public virtual Item? Item { get; set; } = null!;
        public virtual Order? Order { get; set; } = null!;
    }
}
