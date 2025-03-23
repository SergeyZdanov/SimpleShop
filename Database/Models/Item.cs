namespace Database.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = null!;
        public string? Name { get; set; }
        public Decimal? Price { get; set; }
        public string Category { get; set; }
        public virtual ICollection<OrderItem> ItemOrders { get; set; } = new List<OrderItem>();
    }
}
