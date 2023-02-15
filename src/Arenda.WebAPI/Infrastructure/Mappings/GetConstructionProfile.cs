using Arenda.WebAPI.Messages;
using AutoMapper;

namespace Arenda.WebAPI.Infrastructure.Mappings
{
    public class GetConstructionProfile : Profile
    {
        public GetConstructionProfile()
        {
            CreateMap<BusinessLogic.Models.Construction, GetConstructionResponse>();
        }
    }
}
