namespace Database.Models
{
    public partial class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Address { get; set; }
        public int? Discount { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
