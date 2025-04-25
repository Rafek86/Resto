using Resto.Application.Common.CQRS;
using Resto.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Customers.Queries.GetCutomerByEmail
{
   public class GetCustomerByEmailHandler(ICustomerService customerService) :IQueryHandler<GetCustomerByEmailQuery, GetCustomerByEmailResponse>
    {
        private readonly ICustomerService customerService = customerService;

        public async Task<GetCustomerByEmailResponse> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            return await customerService.GetCustomerByEmailAsync(request);
        }
    }
}
