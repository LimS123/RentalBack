namespace Arenda.DataAccess.Entities
{
    public class UserRefreshToken
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime IssuedAtUtc { get; set; }
        public DateTime ExpiresAtUtc { get; set; }
        public User User { get; set; }
    }
}
