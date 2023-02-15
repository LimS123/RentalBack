namespace Arenda.DataAccess.Entities
{
    public class UserOrder
    {
        public Guid UserId { get; set; }
        public Guid ConstructionId { get; set; }
        public Guid OrderId { get; set; }
        public User User { get; set; }
        public Construction Construction { get; set; }
        public Order Order { get; set; }
    }
}
