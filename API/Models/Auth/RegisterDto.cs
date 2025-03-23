namespace API.Models.Auth
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? CustomerId { get; set; }
        public bool IsManager { get; set; }
    }
}
