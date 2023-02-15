using Arenda.BusinessLogic.Models;
using Arenda.WebAPI.Messages;
using AutoMapper;

namespace Arenda.WebAPI.Infrastructure.Mappings
{
    public class GetUserProfile : Profile
    {
        public GetUserProfile()
        {
            CreateMap<User, GetUserResponse>();
        }
    }
}
