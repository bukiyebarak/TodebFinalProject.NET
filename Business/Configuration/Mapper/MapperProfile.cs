using AutoMapper;
using DTO.Apartment;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateApartmentRequest, Apartment>();
        }
    }
}
