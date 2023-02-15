namespace Arenda.BusinessLogic.Models
{
    public class JwtTokenOptions
    {
        public TimeSpan TokenLifetime { get; set; }

        public string? Issuer { get; set; }

        public string? EncryptionKey { get; set; }

        public string SecurityAlgorithm { get; set; } = "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256";
    }
}
