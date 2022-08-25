using DTO.Apartment;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.Apartment
{
    public class CreateApartmentRequestValidator:AbstractValidator<CreateApartmentRequest>
    {
        public CreateApartmentRequestValidator()
        {
            RuleFor(x => x.Block).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Floor).NotEmpty();
            RuleFor(x => x.No).NotEmpty();
        }
    }

}
