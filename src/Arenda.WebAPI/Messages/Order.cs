namespace Arenda.WebAPI.Messages
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime StartedAtUtc { get; set; }
        public DateTime EndedAtUtc { get; set; }
        public Guid ConstructionId { get; set; }
    }
}
