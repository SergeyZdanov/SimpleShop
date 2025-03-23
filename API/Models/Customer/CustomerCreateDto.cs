using System.ComponentModel.DataAnnotations;

namespace API.Models.Customer
{
    public class CustomerCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Code format: XXXX-YYYY")]
        public string Code { get; set; }
        public string Address { get; set; }
        public int? Discount { get; set; }
    }
}
