using System.ComponentModel.DataAnnotations;

namespace API.Models.Customer
{
    public class UpdateCustomerDto
    {
        /* [Required(ErrorMessage = "Id is required")]*/
        public Guid Id { get; set; }
        /* [StringLength(100)]*/
        public string Name { get; set; }

        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Code format: XXXX-YYYY")]
        public string Code { get; set; }
        /*   [StringLength(200)]*/
        public string Address { get; set; }
        /*[Range(0, 100)]*/
        public decimal? Discount { get; set; }
    }
}
