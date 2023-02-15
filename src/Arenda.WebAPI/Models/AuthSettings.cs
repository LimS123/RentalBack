namespace Arenda.WebAPI.Models
{
    public class AuthSettings
    {
        public string? EncryptionKey { get; set; }
        public string? Issuer { get; set; }
        public bool ValidateAudience { get; set; }
        public IEnumerable<string>? ValidAudiences { get; set; }
        public string? SecurityAlgorithm { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}
