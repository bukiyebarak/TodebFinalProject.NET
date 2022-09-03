using DTO.Apartment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Validator.FluentValidation.Apartment
{
    public class UpdateApartmentRequestValidator:AbstractValidator<UpdateApartmentRequest>
    {
        public UpdateApartmentRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Block).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Floor).NotEmpty();
            RuleFor(x => x.No).NotEmpty();
        }
    }
}
