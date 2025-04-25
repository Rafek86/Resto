using Resto.Application.Common.Pagination;
using Resto.Application.DTOs;
using Resto.Application.Features.Customers.Commands.CreateCustomer;
using Resto.Application.Features.Customers.Commands.DeleteCustomer;
using Resto.Application.Features.Customers.Commands.UpdateCustomer;
using Resto.Application.Features.Customers.Queries.GetAllCustomers;
using Resto.Application.Features.Customers.Queries.GetCustomerById;
using Resto.Application.Features.Customers.Queries.GetCutomerByEmail;

namespace Resto.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<CreateCustomerResult> AddCustomerAsync(CreateCustomerCommand command);
        Task<GetCustomerByIdResponse> GetCustomerByIdAsync(GetCustomerByIdQuery query);
        Task<GetCustomerByEmailResponse> GetCustomerByEmailAsync(GetCustomerByEmailQuery quey);
        Task<PagedResult<GetCustomerResponse>> GetPagedCustomersAsync(GetCustomersQuery query);
        Task<UpdateCustomerResult> UpdateCustomerAsync(UpdateCustomerCommand command);
        Task<DeleteCustomerResult> DeleteCustomerAsync(DeleteCustomerCommand command);
    }
}
