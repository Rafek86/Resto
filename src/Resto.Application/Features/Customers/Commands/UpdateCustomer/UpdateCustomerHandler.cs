using Resto.Application.Common.CQRS;
using Resto.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerHandler(ICustomerService customerService) :ICommandHandler<UpdateCustomerCommand, UpdateCustomerResult>
    {
        private readonly ICustomerService _customerService = customerService;

        public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
           return await _customerService.UpdateCustomerAsync(request);
        }
    }

}
