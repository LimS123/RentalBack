﻿using Arenda.BusinessLogic.Models;
using Arenda.WebAPI.Messages;
using AutoMapper;

namespace Arenda.WebAPI.Infrastructure.Mappings
{
    public class RefreshTokenProfile : Profile
    {
        public RefreshTokenProfile()
        {
            CreateMap<Token, RefreshResponse>();
        }
    }
}
