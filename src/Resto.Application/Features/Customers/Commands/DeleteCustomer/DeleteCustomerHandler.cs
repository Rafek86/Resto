using Resto.Application.Common.CQRS;
using Resto.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerHandler(ICustomerService customerService) : ICommandHandler<DeleteCustomerCommand, DeleteCustomerResult>
    {
        private readonly ICustomerService _customerService = customerService;

        public Task<DeleteCustomerResult> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
           return _customerService.DeleteCustomerAsync(request);
        }
    }
}
