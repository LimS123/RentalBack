namespace Arenda.DataAccess.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public Guid ConstructionId { get; set; }
        public string MediaType { get; set; }
        public byte[] Data { get; set; }
        public Construction Construction { get; set; }
    }
}
