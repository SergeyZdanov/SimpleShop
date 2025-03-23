namespace API.Models.Customer
{
    public class CustomerResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public decimal? Discount { get; set; }
    }
}
