using DTO.Bill;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Validator.FluentValidation.Bill
{
    public class UpdateBillRequestValidator:AbstractValidator<UpdateBillRequest>
    {
        public UpdateBillRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Dues).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Electricity).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Water).NotEmpty().GreaterThan(0);
            RuleFor(x => x.NaturalGas).NotEmpty().GreaterThan(0);
        }
    }
}
