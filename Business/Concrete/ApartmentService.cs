using AutoMapper;
using BackgroundJobs.Abstract;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.Apartment;
using DAL.Abstract;
using DTO.Apartment;
using FluentValidation;
using Hangfire.Common;
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
        private readonly IUserRepository _user;
        private IMapper _mapper;
        private IJobs _jobs;
       
        public ApartmentService(IApartmentRepository apartmentRepository, IMapper mapper, IJobs jobs,IUserRepository user)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _jobs = jobs;
            _user = user;
        }
        public CommandResponse Delete(DeleteApartmentRequest apartment)
        {
            var validator = new DeleteApartmentRequestValidator();
            validator.Validate(apartment).ThrowIfException();
            var entity = _mapper.Map<Apartment>(apartment);

            _apartmentRepository.Delete(entity);
            _apartmentRepository.SaveChanges();
            return new CommandResponse
            {
                Status = true,
                Messsage = $"Id={apartment.Id} olan  Apartman Silindi",
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
            var user = _user.Get(x => x.Id == apartment.UserId);

            _apartmentRepository.Add(entity);
            _apartmentRepository.SaveChanges();

            _jobs.FireAndForget(entity.Id, user.Name);
            _jobs.DelayedJob(entity.Id, entity.Floor, TimeSpan.FromSeconds(15));

            return new CommandResponse
            {
                Status = true,
                Messsage = $"Daire Eklendi",

            };
        }

        public CommandResponse Update(UpdateApartmentRequest apartment)
        {
            var validator = new UpdateApartmentRequestValidator();
            validator.Validate(apartment).ThrowIfException();

            var entity = _apartmentRepository.Get(x => x.Id == apartment.Id);
            var user = _user.Get(x => x.Id == apartment.UserId);
            if (entity == null)
            {
                return new CommandResponse()
                {
                    Status = false,
                    Messsage = "Veri tabanında bu Id de kayıt bulunmamaktadır"
                };
            }

            var mappedEntity = _mapper.Map(apartment, entity);

            _apartmentRepository.Update(mappedEntity);
            _apartmentRepository.SaveChanges();

            return new CommandResponse
            {
                Status = true,
                Messsage = $"Daire bilgileriniz güncellendi. Id={apartment.Id} UserName={user.Name}",
            };
        }
    }
}
