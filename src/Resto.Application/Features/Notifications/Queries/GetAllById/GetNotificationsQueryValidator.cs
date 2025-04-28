using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Notifications.Queries.GetAllById
{
    public class GetNotificationsQueryValidator :AbstractValidator<GetNotificationsQuery>
    {
        public GetNotificationsQueryValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Customer Id is Required");
        }
    }
}
