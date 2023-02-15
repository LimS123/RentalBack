namespace Arenda.BusinessLogic.Models
{
    public class RefreshTokenOptions
    {
        public int SizeInBytes { get; set; }

        public TimeSpan TokenLifetime { get; set; }
    }
}
