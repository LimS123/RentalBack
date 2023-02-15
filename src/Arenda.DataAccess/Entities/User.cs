namespace Arenda.DataAccess.Entities
{
    public class User
    {
        public User()
        {
            UserRoles = new List<UserRole>();
            RefreshTokens = new List<UserRefreshToken>();
            UserConstructions= new List<UserConstruction>();
            UserOrders = new List<UserOrder>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<UserRefreshToken> RefreshTokens { get; set; }
        public List<UserConstruction> UserConstructions { get; set; }
        public List<UserApplication> UserApplications { get; set; }
        public List<UserOrder> UserOrders { get; set; }
    }
}
