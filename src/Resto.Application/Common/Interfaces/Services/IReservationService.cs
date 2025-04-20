using Resto.Application.DTOs;
using Resto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Interfaces.Services
{
   public interface IReservationService
    {
        Task<Reservation> GetByIdAsync(string id);
        Task<IEnumerable<ReservationDto>> GetAllAsync();
        Task<IEnumerable<ReservationDto>> GetByCustomerIdAsync(string customerId);
        Task<ReservationDto> AddAsync(string customerId, int TableNumber, int PartySize);
        Task<bool> UpdateByIdAsync(string Id, ReservationDto reservation);
        Task<bool> DeleteByIdAsync(string Id);
    }
}
