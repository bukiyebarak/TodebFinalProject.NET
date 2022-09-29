using DTO.Apartment;
using DTO.Bill;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.Bill
{
    public class CreateBillRequestValidator: AbstractValidator<CreateBillRequest>
    {
        public CreateBillRequestValidator()
        {
            RuleFor(x => x.Dues).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Electricity).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Water).NotEmpty().GreaterThan(0);
            RuleFor(x => x.NaturalGas).NotEmpty().GreaterThan(0);
        }
    }
}
