using FluentValidation;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class AuthValidation : AbstractValidator<RegisterCreateDto>
    {
        public AuthValidation()
        {
            RuleFor(b => b.FirstName).NotEmpty()
.WithMessage("Name cannot be empty")
.NotNull().WithMessage("Name cannot be null")
.MaximumLength(30).WithMessage("Maximum length is 30");

            RuleFor(b => b.LastName).NotEmpty()
           .WithMessage("Surname cannot be empty")
           .NotNull().WithMessage("Surname cannot be null")
           .MaximumLength(50).WithMessage("Surname Maximum length is 50");

            RuleFor(b => b.Password).Equal(b => b.ConfirmPassword).WithMessage("Password Doesnt Matched");


        }
    }
}
