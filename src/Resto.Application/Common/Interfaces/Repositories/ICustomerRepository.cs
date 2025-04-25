using Resto.Application.Common.Pagination;
using Resto.Application.DTOs;
using Resto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Interfaces.Repositories
{
   public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(string id);
        Task<PagedResult<Customer>> GetPagedCustomersAsync(int pageNumber, int pageSize);
        Task<string> AddAsync(Customer customer);
        Task<string> UpdateAsync(Customer customer);
        Task<string> DeleteAsync(Customer customer);
        Task<Customer> GetByEmailAsync(string email);
    }
}
