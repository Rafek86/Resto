using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.MenuItems.Queries.GetByCategory
{
    public class GetByCategoryQueryValidator : AbstractValidator<GetByCategoryQuery>
    {
        public GetByCategoryQueryValidator()
        {
            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required.")
                .Length(2, 50).WithMessage("Category must be between 2 and 50 characters.");
        }
    }
}
