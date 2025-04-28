using Resto.Application.DTOs;
using Resto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Interfaces.Repositories
{
   public interface IReservationRepository
    {
        Task<Reservation> GetByIdAsync(string Id);
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<IEnumerable<Reservation>> GetByCustomerIdAsync(string customerId);
        Task<string> AddAsync(Reservation reservation);
        Task<string> UpdateByIdAsync(Reservation reservation);
        Task<string> DeleteByIdAsync(Reservation reservation);
    }
}
