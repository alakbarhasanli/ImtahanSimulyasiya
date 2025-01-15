using FluentValidation;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class CategoryValidation:AbstractValidator<CategoryCreateDto>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Title).NotNull().NotEmpty().WithMessage("Require Title").MinimumLength(4).WithMessage("Must be At least 4 char");
        }
    }
}
