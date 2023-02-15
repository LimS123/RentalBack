namespace Arenda.BusinessLogic.Models
{
    public class UpdateUser
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
