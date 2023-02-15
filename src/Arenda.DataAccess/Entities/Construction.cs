namespace Arenda.DataAccess.Entities
{
    public class Construction
    {
        public Construction()
        {
            Images = new List<Image>();
            UserConstructions = new List<UserConstruction>();
            UserOrders = new List<UserOrder>();
        }

        public Guid Id { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public ConstructionType Type { get; set; }
        public double Square { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int? NumberOfRooms { get; set; }
        public int? Floor { get; set; }
        public List<Image> Images { get; set; }
        public List<UserConstruction> UserConstructions { get; set; }
        public List<UserOrder> UserOrders { get; set; }
    }
}
