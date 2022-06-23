namespace EvDekorasyonu.Domain.Dtos
{
    public class LoginDto : BaseDto
    {
        public LoginDto()
        {

        }

        public LoginDto(string email, string password, bool rememberMe)
        {
            Email = email;
            Password = password;
            RememberMe = rememberMe;

        }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
