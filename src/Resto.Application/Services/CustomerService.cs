using Mapster;
using Resto.Application.Common.Exceptions;
using Resto.Application.Common.Interfaces.Repositories;
using Resto.Application.Common.Pagination;
using Resto.Application.DTOs;
using Resto.Application.Features.Customers.Commands.CreateCustomer;
using Resto.Application.Features.Customers.Commands.DeleteCustomer;
using Resto.Application.Features.Customers.Commands.UpdateCustomer;
using Resto.Application.Features.Customers.Queries.GetAllCustomers;
using Resto.Application.Features.Customers.Queries.GetCustomerById;
using Resto.Application.Features.Customers.Queries.GetCutomerByEmail;
using Resto.Application.Interfaces.Services;
using Resto.Domain.Models;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository=customerRepository;


    public async Task<CreateCustomerResult> AddCustomerAsync(CreateCustomerCommand command)
    {
        if (await _customerRepository.GetByEmailAsync(command.Email) is not null)
            throw new ConflictException("Customer with this email already exists.");

        var customer = Customer.Create(command.Name, command.Email);
        await _customerRepository.AddAsync(customer);

        return new CreateCustomerResult(customer.Id);
    }

    public async Task<UpdateCustomerResult> UpdateCustomerAsync(UpdateCustomerCommand command)
    {
        if (await _customerRepository.GetByIdAsync(command.Id) is not { } customer)
            throw new NotFoundException("Customer", "Id");

        var existingByEmail = await _customerRepository.GetByEmailAsync(command.Email);
        if (existingByEmail is not null && existingByEmail.Id != customer.Id)
            throw new ConflictException("Customer with this email already exists.");

        customer.Update(command.Name, command.Email);

        await _customerRepository.UpdateAsync(customer);

        return new UpdateCustomerResult(true);
    }


    public async Task<DeleteCustomerResult> DeleteCustomerAsync(DeleteCustomerCommand command)
    {
        if (await _customerRepository.GetByIdAsync(command.Id) is not { } customer)
            throw new NotFoundException("Customer", "Id");

        customer.Delete();
        await _customerRepository.DeleteAsync(customer);
        return new DeleteCustomerResult(true);
    }

    public async Task<PagedResult<GetCustomerResponse>> GetPagedCustomersAsync(GetCustomersQuery query)
    {
        var result = await _customerRepository.GetPagedCustomersAsync(query.PageNumber, query.PageSize);

        //var mappedItems = result.Items
        //    .Select(c => new GetCustomerResponse(c.Id, c.Name, c.Email));

        var mappedItems = result.Items.Adapt<IEnumerable<GetCustomerResponse>>();

        return new PagedResult<GetCustomerResponse>
        {
            Items = mappedItems,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize,
            TotalItems = result.TotalItems
        };
    }

   public async Task<GetCustomerByIdResponse> GetCustomerByIdAsync(GetCustomerByIdQuery query)
    {
        if(await _customerRepository.GetByIdAsync(query.Id) is not { } customer)
            throw new NotFoundException("Customer", "Id");

        return new GetCustomerByIdResponse(customer.Adapt<CustomerDto>());
    }

    public async Task<GetCustomerByEmailResponse> GetCustomerByEmailAsync(GetCustomerByEmailQuery quey)
    {
      if(await _customerRepository.GetByEmailAsync(quey.Email) is not { } customer)
            throw new NotFoundException("Customer", "Email");

        return new GetCustomerByEmailResponse(customer.Adapt<CustomerDto>());
    }




}