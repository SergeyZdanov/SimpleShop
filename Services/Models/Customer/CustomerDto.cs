using Services.Models.Order;

namespace Services.Models.Customer
{
    public partial class CustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Address { get; set; }
        public int? Discount { get; set; }
        public virtual ICollection<OrderDto> Orders { get; set; } = new List<OrderDto>();
    }
}
