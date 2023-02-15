namespace Arenda.WebAPI.Messages
{
    public class AuthenticateRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
