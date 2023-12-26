using AutoMapper;
using PhoenixMerch.Entities.Concrete;
using PhoenixMerch.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixMerch.Business.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
        }
    }
}
