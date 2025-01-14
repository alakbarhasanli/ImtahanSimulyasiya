using FluentValidation;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class TechniciansValidation:AbstractValidator<TechnicianCreateDto>
    {
        public TechniciansValidation()
        {
            RuleFor(t => t.Name).NotEmpty().NotNull().WithMessage("Must Be Name").MinimumLength(5).WithMessage("Must at lest 5 chars");
            RuleFor(t => t.Profession).NotEmpty().NotNull().WithMessage("Must Be Profession").MinimumLength(5).WithMessage("Must at lest 5 chars");
            RuleFor(t => t.ServiceId).NotEmpty().NotNull().WithMessage("Must Be ServiceId").GreaterThan(0).WithMessage("Such Id doesnt exist");
            RuleFor(t => t.TechniciansPhoto).NotEmpty().NotNull().WithMessage("Must Be Photo");
        }
    }
}
