using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.Apartment;
using DAL.Abstract;
using DTO.Apartment;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Business.Concrete
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private IMapper _mapper;
       
        public ApartmentService(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
           
        }
        public CommandResponse Delete(Apartment apartment)
        {
            _apartmentRepository.Delete(apartment);
            _apartmentRepository.SaveChanges();
            return new CommandResponse
            {
                Status = true,
                Messsage = "Apartman Silindi",

            };
        }

        public IEnumerable<Apartment> GetAll()
        {
           return _apartmentRepository.GetAll();
        }

        public CommandResponse Insert(CreateApartmentRequest apartment)
        {
            var validator = new CreateApartmentRequestValidator();
            validator.Validate(apartment).ThrowIfException();
            var entity = _mapper.Map<Apartment>(apartment);

            _apartmentRepository.Add(entity);
            _apartmentRepository.SaveChanges();
            return new CommandResponse
            {
                Status = true,
                Messsage = $"Daire Eklendi",

            };
        }

        public CommandResponse Update(Apartment apartment)
        {
            _apartmentRepository.Update(apartment);
            _apartmentRepository.SaveChanges();
            return new CommandResponse
            {
                Status = true,
                Messsage = $"Daire Güncellendi",

            };
        }
    }
}
