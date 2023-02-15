namespace Arenda.WebAPI.Messages
{
    public class CreateOrderRequest
    {
        public Guid ConstructionId { get; set; }
        public DateTime StartedAtUtc { get; set; }
        public DateTime EndedAtUtc { get; set; }
    }
}
