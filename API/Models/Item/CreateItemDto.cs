namespace API.Models.Item
{
    public class CreateItemDto
    {
        public string Code { get; set; } = null!;

        public string? Name { get; set; }

        public Decimal? Price { get; set; }

        public string? Category { get; set; }
    }
}
