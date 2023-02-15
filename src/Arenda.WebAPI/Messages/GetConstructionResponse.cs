namespace Arenda.WebAPI.Messages
{
    public class GetConstructionResponse
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public string PhoneNumber { get; set; }
        public double? Price { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public string? Name { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? Type { get; set; }
        public double Square { get; set; }
        public int Year { get; set; }
        public string? Description { get; set; }
        public int? NumberOfRooms { get; set; }
        public int? Floor { get; set; }
        public IEnumerable<Image>? Images { get; set; }
    }
}
