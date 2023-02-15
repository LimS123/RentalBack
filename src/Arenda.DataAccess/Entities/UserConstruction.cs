namespace Arenda.DataAccess.Entities
{
    public class UserConstruction
    {
        public Guid UserId { get; set; }
        public Guid ConstructionId { get; set; }
        public User User { get; set; }
        public Construction Construction { get; set; }
    }
}
