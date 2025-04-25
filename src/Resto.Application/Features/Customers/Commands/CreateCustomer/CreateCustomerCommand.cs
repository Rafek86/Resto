using Resto.Application.Common.CQRS;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Customers.Commands.CreateCustomer
{
   public record CreateCustomerCommand(string Name , string Email)
        :ICommand<CreateCustomerResult>;

    public record CreateCustomerResult(string Id);
}
