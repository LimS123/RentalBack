using Arenda.BusinessLogic.Models;
using Arenda.WebAPI.Infrastructure.Mappings.Converters;
using Arenda.WebAPI.Messages;
using AutoMapper;

namespace Arenda.WebAPI.Infrastructure.Mappings
{
    public class UpdateConstructionProfile : Profile
    {
        public UpdateConstructionProfile()
        {
            CreateMap<UpdateConstructionRequest, UpdateConstruction>();
            CreateMap<BusinessLogic.Models.Construction, UpdateConstructionResponse>();

            CreateMap<IFormFile, (byte[], string)>()
                .ConvertUsing(new NewImageTypeConverter());
        }
    }
}
