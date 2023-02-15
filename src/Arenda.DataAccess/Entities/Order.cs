namespace Arenda.DataAccess.Entities
{
    public class Order
    {
        public Order()
        {
            UserOrders = new List<UserOrder>();
        }

        public Guid Id { get; set; }
        public DateTime StartedAtUtc { get; set; }
        public DateTime EndedAtUtc { get; set; }
        public List<UserOrder> UserOrders { get; set; }
    }
}
