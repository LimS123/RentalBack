using Arenda.WebAPI.Messages;
using AutoMapper;

namespace Arenda.WebAPI.Infrastructure.Mappings
{
    public class GetEndDateProfile : Profile
    {
        public GetEndDateProfile()
        {
            CreateMap<DateTime, GetEndDateResponse>()
                .ForMember(
                    dest => dest.EndDate,
                    opt => opt.MapFrom(x => x)
                );

            CreateMap<DateTime, DateTime>();
        }
    }
}
