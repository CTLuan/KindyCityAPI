﻿using FluentValidation;
using KindyCity.Application.Commands.Auth.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Application.Validators.Auth
{
    public class CreateEmployeeValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[@$!%*?&]").WithMessage("Password must contain at least one special character.");
        }
    }
}
