using System.ComponentModel.DataAnnotations;

namespace API.Models.Order
{
    public class ConfirmOrderDto
    {
        [Required]
        public Guid OrderId { get; set; }

        public DateTime? ShipmentDate { get; set; }
    }
}
