using AutoMapper;
using DAS.Application.Models.ViewModels;
using DAS.Domain.Models.DAS;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAS.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VMUser, User>();
            CreateMap<User, VMUser>();
        }
    }
}