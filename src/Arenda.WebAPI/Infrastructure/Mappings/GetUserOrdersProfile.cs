using Arenda.WebAPI.Messages;
using AutoMapper;

namespace Arenda.WebAPI.Infrastructure.Mappings
{
    public class GetUserOrdersProfile : Profile
    {
        public GetUserOrdersProfile()
        {
            CreateMap<List<BusinessLogic.Models.Order>, GetUserOrdersResponse>()
                .ForMember(
                    dest => dest.Orders,
                    opt => opt.MapFrom(x => x)
                );

            CreateMap<BusinessLogic.Models.Order, Order>();
        }
    }
}
