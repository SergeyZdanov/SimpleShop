namespace API.Models.Item
{
    public class UpdateItemDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = null!;
        public string? Name { get; set; }
        public Decimal? Price { get; set; }
        public string? Category { get; set; }
    }
}
