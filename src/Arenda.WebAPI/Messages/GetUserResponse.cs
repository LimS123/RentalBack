﻿namespace Arenda.WebAPI.Messages
{
    public class GetUserResponse
    {
        public Guid? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Role { get; set; }
    }
}
