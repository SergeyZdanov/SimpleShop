namespace Services.Models.Auth
{
    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? CustomerId { get; set; }
        public bool IsManager { get; set; }
    }
}
