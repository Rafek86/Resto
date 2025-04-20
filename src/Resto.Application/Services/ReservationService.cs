using Resto.Application.Common.Interfaces.Repositories;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.DTOs;
using Resto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Services
{
    class ReservationService(IReservationRepository reservationRepository) :IReservationService
    {
        private readonly IReservationRepository reservationRepository = reservationRepository;

        public async Task<ReservationDto> AddAsync(string customerId, int TableNumber, int PartySize)
        {
          return await reservationRepository.AddAsync(customerId, TableNumber, PartySize);
        }

        public async Task<bool> DeleteByIdAsync(string Id)
        {
            return await reservationRepository.DeleteByIdAsync(Id);
        }

        public async Task<IEnumerable<ReservationDto>> GetAllAsync()
        {
            return await reservationRepository.GetAllAsync();
        }

        public async Task<IEnumerable<ReservationDto>> GetByCustomerIdAsync(string customerId)
        {
            return await reservationRepository.GetByCustomerIdAsync(customerId);
        }

        public async Task<Reservation> GetByIdAsync(string id)
        {
          return await reservationRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateByIdAsync(string Id, ReservationDto reservation)
        {
            return await reservationRepository.UpdateByIdAsync(Id, reservation);
        }
    }
}
