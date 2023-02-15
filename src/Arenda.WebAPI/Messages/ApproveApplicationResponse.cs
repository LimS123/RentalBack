namespace Arenda.WebAPI.Messages
{
    public class ApproveApplicationResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime ApprovedAtUtc { get; set; }
    }
}
