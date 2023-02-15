using Arenda.BusinessLogic.Models;
using Arenda.WebAPI.Messages;
using AutoMapper;

namespace Arenda.WebAPI.Infrastructure.Mappings
{
    public class CreateOrderProfile : Profile
    {
        public CreateOrderProfile()
        {
            CreateMap<CreateOrderRequest, CreateOrder>();
        }
    }
}
