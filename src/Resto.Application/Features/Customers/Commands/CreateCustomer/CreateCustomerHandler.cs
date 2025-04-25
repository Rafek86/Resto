using Mapster;
using Resto.Application.Common.CQRS;
using Resto.Application.DTOs;
using Resto.Application.Interfaces.Services;
using Resto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerHandler(ICustomerService customerService) : ICommandHandler<CreateCustomerCommand, CreateCustomerResult>
    {
        private readonly ICustomerService _customerService = customerService;

        public async Task<CreateCustomerResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
                return await _customerService.AddCustomerAsync(request);
        } 
    }
}
