using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.Apartment;
using Business.Configuration.Validator.FluentValidation.Bill;
using DAL.Abstract;
using DAL.Concrete.EF;
using DTO.Bill;
using FluentValidation;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly IUserRepository _user;
        private IMapper _mapper;

        public BillService(IBillRepository billRepository, IUserRepository user, IMapper mapper)
        {
            _billRepository = billRepository;
            _user = user;
            _mapper = mapper;
        }

        public CommandResponse Delete(DeleteBillRequest bill)
        {
            var validator = new DeleteBillRequestValidator();
            validator.Validate(bill).ThrowIfException();
            var entity = _mapper.Map<Bill>(bill);

            _billRepository.Delete(entity);
            _billRepository.SaveChanges();

            return new CommandResponse
            {
                Status = true,
                Messsage = $"Id={bill.Id} Fatura Silindi",
                Created_At=DateTime.Now, 
            };
        }

        public IEnumerable<Bill> GetAll()
        {
           return _billRepository.GetAll();
        }

        public IEnumerable<SearchBillResponse> GetUserBill()
        {
            throw new NotImplementedException();
        }

        public CommandResponse Insert(CreateBillRequest bill)
        {
            var validator = new CreateBillRequestValidator();
            validator.Validate(bill).ThrowIfException();
            var entity = _mapper.Map<Bill>(bill);
            
            _billRepository.Add(entity);
            _billRepository.SaveChanges();

            return new CommandResponse
            {
                Status = true,
                Messsage = $"Fatura Eklendi",

            };
        }

        public CommandResponse Update(UpdateBillRequest bill)
        {
            var validator = new UpdateBillRequestValidator();
            validator.Validate(bill).ThrowIfException();

            var entity = _billRepository.Get(x => x.Id == bill.Id);
            var user = _user.Get(x => x.Id == bill.UserId);
            if (entity == null)
            {
                return new CommandResponse()
                {
                    Status = false,
                    Messsage = "Veri tabanında bu Id de kayıt bulunmamaktadır"
                };
            }

            var mappedEntity = _mapper.Map(bill, entity);

            _billRepository.Update(mappedEntity);
            _billRepository.SaveChanges();
           
            return new CommandResponse
            {
                Status = true,
                Messsage = $"Fatura bilgileriniz güncellendi. Id={bill.Id} UserName={user.Name}",
                Created_At = DateTime.Now,  
            };
        }
    }
}
