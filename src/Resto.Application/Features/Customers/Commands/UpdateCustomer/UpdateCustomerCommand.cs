using Resto.Application.Common.CQRS;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Resto.Application.Features.Customers.Commands.UpdateCustomer
{
    public record UpdateCustomerCommand(string Id,string Name,string Email) :ICommand<UpdateCustomerResult>;

    public record UpdateCustomerResult(bool isSuccess);
}
