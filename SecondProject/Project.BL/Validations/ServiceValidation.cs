using FluentValidation;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class ServiceValidation:AbstractValidator<ServiceCreatedto>
    {
        public ServiceValidation()
        {
            RuleFor(s => s.Name).NotEmpty().NotNull().WithMessage("Must Be Name").MinimumLength(5).WithMessage("Must at lest 5 chars");
        }
    }
}
