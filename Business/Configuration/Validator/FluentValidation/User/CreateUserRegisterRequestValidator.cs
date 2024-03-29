﻿using DTO.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Validator.FluentValidation.User
{
    public class CreateUserRegisterRequestValidator : AbstractValidator<CreateUserRegisterRequest>
    {
        public CreateUserRegisterRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x=>x.Surname).NotEmpty().WithMessage("Kullanıcı ikinci adı boş geçilemez");
            RuleFor(x => x.UserPassword).NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Phone).Length(11).NotEmpty();
        }
    }

}
