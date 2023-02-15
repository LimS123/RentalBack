namespace Arenda.DataAccess.Entities
{
    public class UserApplication
    {
        public Guid ApplicationId { get; set; }
        public Guid UserId { get; set; }
        public Application Application { get; set; }
        public User User { get; set; }
    }
}
