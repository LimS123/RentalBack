namespace Arenda.WebAPI.Messages
{
    public class GetFilterConstructionsRequest
    {
        public double MinCost { get; set; }
        public double MaxCost { get; set; }
        public bool? CreatedAtUtcOrder { get; set; }
        public string? Type { get; set; }
        public double MinSquare { get; set; }
        public double MaxSquare { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public int? NumberOfRooms { get; set; }
        public int? Floor { get; set; }
    }
}
