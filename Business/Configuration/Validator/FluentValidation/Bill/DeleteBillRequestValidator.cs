using DTO.Bill;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.Bill
{
    public class DeleteBillRequestValidator:AbstractValidator<DeleteBillRequest>
    {
        public DeleteBillRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
