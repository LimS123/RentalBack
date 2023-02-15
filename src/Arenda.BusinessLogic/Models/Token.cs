namespace Arenda.BusinessLogic.Models
{
    public class Token
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? TokenType { get; set; }
        public DateTime IssuedAtUtc { get; init; }
        public DateTime JwtTokenExpiresAtUtc { get; init; }
        public DateTime RefreshTokenExpiresAtUtc { get; init; }
    }
}
