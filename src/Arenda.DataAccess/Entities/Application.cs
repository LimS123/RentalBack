namespace Arenda.DataAccess.Entities
{
    public class Application
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "Я хотел бы стать арендодателем";
        public bool Status { get; set; } = false;
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovedAtUtc { get; set; }
        public List<UserApplication> UserApplications { get; set; }
    }
}
