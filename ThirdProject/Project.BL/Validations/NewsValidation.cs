using FluentValidation;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class NewsValidation:AbstractValidator<NewsCreateDto>
    {
        public NewsValidation()
        {
            RuleFor(n => n.Title).NotNull().NotEmpty().WithMessage("Require Title").MinimumLength(10).WithMessage("Must be At least 10 char");
            RuleFor(n => n.Description).NotNull().NotEmpty().WithMessage("Require Description").MinimumLength(10).WithMessage("Must be At least 10 char");
            RuleFor(n => n.CategoryId).NotNull().NotEmpty().WithMessage("Require CategoryId");
            RuleFor(n => n.NewsPhoto).NotNull().NotEmpty().WithMessage("Require NewsPhoto");

        }
    }
}
