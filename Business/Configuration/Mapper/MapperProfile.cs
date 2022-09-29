using AutoMapper;
using DTO.Apartment;
using DTO.Bill;
using DTO.User;
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
            CreateMap<CreateUserRegisterRequest, User>();
            CreateMap<UpdateApartmentRequest, Apartment>();
            CreateMap<DeleteApartmentRequest,Apartment>();
            CreateMap<CreateBillRequest,Bill>();
            CreateMap<DeleteBillRequest,Bill>();
            CreateMap<UpdateBillRequest, Bill>();
        }
    }
}
