using Arenda.DataAccess.Models;
using AutoMapper;

namespace Arenda.BusinessLogic.Infrastructure.Mappings
{
    public class ConstructionFilterProfile : Profile
    {
        public ConstructionFilterProfile()
        {
            CreateMap<Models.ConstructionFilter, ConstructionFilter>();
        }
    }
}
