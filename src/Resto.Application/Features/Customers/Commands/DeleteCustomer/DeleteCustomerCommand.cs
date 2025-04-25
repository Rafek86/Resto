using Resto.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Customers.Commands.DeleteCustomer
{
    public record DeleteCustomerCommand(string Id):ICommand<DeleteCustomerResult>;

    public record DeleteCustomerResult(bool isSuccess);
}
