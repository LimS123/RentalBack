namespace Arenda.DataAccess.Entities
{
    public class Role
    {
        public Role()
        {
            UserRoles = new List<UserRole>();
        }

        public Guid Id { get; set; }
        public RoleType Type { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
