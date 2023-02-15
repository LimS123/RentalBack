using Arenda.BusinessLogic.Models;
using Arenda.WebAPI.Messages;
using AutoMapper;

namespace Arenda.WebAPI.Infrastructure.Mappings
{
    public class AuthenticateProfile : Profile
    {
        public AuthenticateProfile()
        {
            CreateMap<Token, AuthenticateResponse>();
        }
    }
}
