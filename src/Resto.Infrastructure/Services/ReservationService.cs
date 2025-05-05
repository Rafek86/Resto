using Mapster;
using Resto.Application.Common.Exceptions;
using Resto.Application.Common.Interfaces.Repositories;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Features.Reservations.Commands.Create;
using Resto.Application.Features.Reservations.Commands.Delete;
using Resto.Application.Features.Reservations.Commands.Update;
using Resto.Application.Features.Reservations.Queries.GetAllById;
using Resto.Application.Features.Reservations.Queries.GetById;
using Resto.Domain.Models;

namespace Resto.Application.Services
{
   public class ReservationService(IReservationRepository reservationRepository) : IReservationService
    {
        private readonly IReservationRepository _reservationRepository = reservationRepository;

        public async Task<CreateReservationResult> AddAsync(CreateReservationCommand command)
        {
            var reservation = Reservation.Create(
                command.customerId,
                command.TableNumber,
                command.ReservationDate,
                command.PartySize
            );

            await _reservationRepository.AddAsync(reservation);

            return new CreateReservationResult(reservation.Id);
        }

        public async Task<DeleteReservationResult> DeleteByIdAsync(DeleteReservationCommand command)
        {
            var reservation = await _reservationRepository.GetByIdAsync(command.Id);

            if (reservation == null)
            {
                throw new NotFoundException(nameof(Reservation), command.Id);
            }

            reservation.Delete();

            await _reservationRepository.DeleteByIdAsync(reservation);

            return new DeleteReservationResult(true);
        }

        public async Task<IEnumerable<GetReservationsResponse>> GetAllAsync(GetReservationsQuery query)
        {
            var reservations = await _reservationRepository.GetAllAsync();

            return reservations.Adapt<IEnumerable<GetReservationsResponse>>();
        }

        public async Task<IEnumerable<GetReservationsResponse>> GetByCustomerIdAsync(GetReservationsQuery query)
        {
            var reservations = await _reservationRepository.GetByCustomerIdAsync(query.CustomerId);

            return reservations.Adapt<IEnumerable<GetReservationsResponse>>();
        }

        public async Task<GetReservationByIdResponse> GetByIdAsync(GetReservationByIdQuery query)
        {
            var reservation = await _reservationRepository.GetByIdAsync(query.reservationId);

            if (reservation == null)
            {
                throw new NotFoundException(nameof(Reservation), query.reservationId);
            }

            return reservation.Adapt<GetReservationByIdResponse>();
        }

        public async Task<UpdateReservationResult> UpdateByIdAsync(UpdateReservationCommand command)
        {
            var reservation = await _reservationRepository.GetByIdAsync(command.ReservationId);

            if (reservation == null)
            {
                throw new NotFoundException(nameof(Reservation), command.ReservationId);
            }

            reservation.Update(
                command.ReservationDate,
                command.PartySize,
                command.TablesStatus
            );

            await _reservationRepository.UpdateByIdAsync(reservation);

            return new UpdateReservationResult(true);
        }
    }
}
