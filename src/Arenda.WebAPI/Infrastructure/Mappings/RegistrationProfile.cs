using Arenda.BusinessLogic.Models;
using Arenda.WebAPI.Messages;
using AutoMapper;

namespace Arenda.WebAPI.Infrastructure.Mappings
{
    public class RegistrationProfile : Profile
    {
        public RegistrationProfile()
        {
            CreateMap<RegistrationRequest, CreateUser>();
            CreateMap<User, RegistrationResponse>();
        }
    }
}
