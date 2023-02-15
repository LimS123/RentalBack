using Arenda.WebAPI.Messages;
using AutoMapper;

namespace Arenda.WebAPI.Infrastructure.Mappings
{
    public class GetApplicationsProfile : Profile
    {
        public GetApplicationsProfile()
        {
            CreateMap<List<BusinessLogic.Models.Application>, GetApplicationsResponse>()
                .ForMember(
                    dest => dest.Applications,
                    opt => opt.MapFrom(x => x)
                );

            CreateMap<BusinessLogic.Models.Application, Application>();
        }
    }
}
