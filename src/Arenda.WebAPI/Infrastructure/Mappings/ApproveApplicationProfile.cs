using Arenda.WebAPI.Messages;
using AutoMapper;

namespace Arenda.WebAPI.Infrastructure.Mappings
{
    public class ApproveApplicationProfile : Profile
    {
        public ApproveApplicationProfile()
        {
            CreateMap<BusinessLogic.Models.Application, ApproveApplicationResponse>();
        }
    }
}
