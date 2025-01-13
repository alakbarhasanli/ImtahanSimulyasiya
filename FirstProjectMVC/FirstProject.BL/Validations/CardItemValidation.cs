using FirstProject.BL.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.BL.Validations
{
    public class CardItemValidation:AbstractValidator<CardItemCreateDto>
    {
        public CardItemValidation()
        {
            RuleFor(c => c.Title).NotEmpty().NotNull().WithMessage("Require Title").MinimumLength(4).WithMessage("Must be at least 4 chars");
            RuleFor(g => g.Description).NotEmpty().NotNull().WithMessage("Require Description").MinimumLength(4).WithMessage("Must be at least 4 chars");
            RuleFor(g => g.CardPhoto).NotEmpty().NotNull().WithMessage("Require Game Photo");
        }
    }
}
