namespace Arenda.WebAPI.Messages
{
    public class GetUserOrdersResponse
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
