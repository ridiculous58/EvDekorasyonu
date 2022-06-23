namespace EvDekorasyonu.Domain.Dtos
{
    public class RegisterDto : BaseDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
