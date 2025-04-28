using Resto.Application.DTOs;
using Resto.Application.Features.Reservations.Commands.Create;
using Resto.Application.Features.Reservations.Commands.Delete;
using Resto.Application.Features.Reservations.Commands.Update;
using Resto.Application.Features.Reservations.Queries.GetAllById;
using Resto.Application.Features.Reservations.Queries.GetById;
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
        Task<GetReservationByIdResponse> GetByIdAsync(GetReservationByIdQuery query);
        Task<IEnumerable<GetReservationsResponse>> GetAllAsync(GetReservationsQuery query);
        Task<IEnumerable<GetReservationsResponse>> GetByCustomerIdAsync(GetReservationsQuery query);
        Task<CreateReservationResult> AddAsync(CreateReservationCommand command);
        Task<UpdateReservationResult> UpdateByIdAsync(UpdateReservationCommand command);
        Task<DeleteReservationResult> DeleteByIdAsync(DeleteReservationCommand command);
   }
}
