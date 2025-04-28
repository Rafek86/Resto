using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.MenuItems.Queries.GetAll
{
  public class GetAllMenuItemsQueryValidator : AbstractValidator<GetAllMenuItemsQuery>
    {
        public GetAllMenuItemsQueryValidator() 
        { 
        RuleFor(x => x.PageNumber)
            .GreaterThan(0).WithMessage("Page number must be greater than 0.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0).WithMessage("Page size must be greater than 0.")
                .LessThanOrEqualTo(100).WithMessage("Page size must be less than or equal to 100.");

        }
    }
}
