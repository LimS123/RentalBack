using Arenda.WebAPI.Messages;
using AutoMapper;

namespace Arenda.WebAPI.Infrastructure.Mappings
{
    public class GetConstructionsProfile : Profile
    {
        public GetConstructionsProfile()
        {
            CreateMap<List<BusinessLogic.Models.Construction>, GetConstructionsResponse>()
                .ForMember(
                    dest => dest.Constructions,
                    opt => opt.MapFrom(x => x)
                );

            CreateMap<BusinessLogic.Models.Construction, Construction>();
        }
    }
}
