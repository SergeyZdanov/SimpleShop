using System.ComponentModel.DataAnnotations;

namespace API.Models.User
{
    public class UpdateRoleDto
    {
        [Required(ErrorMessage = "Роль обязательна.")]
        public string Role { get; set; }
    }
}

