namespace Arenda.BusinessLogic.Models
{
    public class CreateConstruction
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Type { get; set; }
        public double Square { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int? NumberOfRooms { get; set; }
        public int? Floor { get; set; }
        public List<(byte[], string)> Images { get; set; }
    }
}
