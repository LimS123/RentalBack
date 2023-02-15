using Arenda.WebAPI.Messages;
using AutoMapper;

namespace Arenda.WebAPI.Infrastructure.Mappings
{
    public class CreateConstructionProfile : Profile
    {
        public CreateConstructionProfile()
        {
            CreateMap<CreateConstructionRequest, BusinessLogic.Models.CreateConstruction>();
            CreateMap<BusinessLogic.Models.Construction, CreateConstructionResponse>();

            CreateMap<BusinessLogic.Models.Image, Image>();
        }
    }
}
