using Arenda.WebAPI.Messages;
using AutoMapper;

namespace Arenda.WebAPI.Infrastructure.Mappings
{
    public class GetFilterConstructionsProfile : Profile
    {
        public GetFilterConstructionsProfile()
        {
            CreateMap<GetFilterConstructionsRequest, BusinessLogic.Models.ConstructionFilter>();
            CreateMap<List<BusinessLogic.Models.Construction>, GetFilterConstructionsResponse>()
                .ForMember(
                    dest => dest.Constructions,
                    opt => opt.MapFrom(x => x)
                );
        }
    }
}
