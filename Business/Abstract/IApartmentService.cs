using Business.Configuration.Response;
using DTO.Apartment;
using Models.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IApartmentService
    {
        public IEnumerable<Apartment> GetAll();
        public CommandResponse Insert(CreateApartmentRequest apartment);
        public CommandResponse Update(UpdateApartmentRequest apartment);
        public CommandResponse Delete(DeleteApartmentRequest apartment);
    }
}
