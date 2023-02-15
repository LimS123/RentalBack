
namespace Arenda.BusinessLogic.Models
{
    public class CreateOrder
    {
        public Guid ConstructionId { get; set; }
        public DateTime StartedAtUtc { get; set; }
        public DateTime EndedAtUtc { get; set; }
    }
}
