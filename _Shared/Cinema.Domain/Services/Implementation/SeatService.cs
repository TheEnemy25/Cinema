using Cinema.Infrastructure.Entities;
using Cinema.Infrastructure.Enums;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class SeatService : BaseService<Seat>, ISeatService
    {
        public SeatService(IBaseRepository<Seat> repository) : base(repository)
        {
        }

        public async Task<bool> AreSeatsAvailableAsync(Guid sessionId, IEnumerable<Guid> seatIds)
        {
            var areSeatsAvailable = await _repository
                .Query()
                .Where(session => session.Id == sessionId)
                .AnyAsync(session => seatIds.All(seatId => session.SessionSeats.Any(ss => ss.Seat.Id == seatId && ss.Status == ESeatStatus.Available)));

            return areSeatsAvailable;
        }

        public async Task<IEnumerable<Seat>> GetAvailableSeatsBySessionIdAsync(Guid sessionId, Guid hallId)
        {
            var occupiedSeats = await _repository
               .Query()
               .Where(s => s.SessionSeats.Any(ss => ss.Session.Id == sessionId))
               .Select(s => s.Id)
               .ToListAsync();

            var availableSeats = await _repository
                .Query()
                .Where(seat => seat.HallId == hallId && !occupiedSeats.Contains(seat.Id))
                .ToListAsync();

            return availableSeats;
        }

        public async Task<IEnumerable<Seat>> GetSeatsByHallIdAsync(Guid hallId)
        {
            var seats = await _repository
                .Query()
                .Where(seat => seat.Hall.Id == hallId)
                .ToListAsync();

            return seats;
        }

        public async Task MarkSeatsAsAvailableAsync(Guid sessionId, IEnumerable<Guid> seatIds)
        {
            var sessionSeats = await _repository
                 .Query()
                 .Where(s => s.SessionSeats
                     .Any(ss => ss.Session.Id == sessionId && ss.Status == ESeatStatus.Available))
                 .ToListAsync();

            foreach (var sessionSeat in sessionSeats)
            {
                foreach (var seat in sessionSeat.SessionSeats)
                {
                    seat.Status = ESeatStatus.Available;
                }
            }

            await _repository.SaveChangesAsync();
        }

        public async Task MarkSeatsAsOccupiedAsync(Guid sessionId, IEnumerable<Guid> seatIds)
        {
            var sessionSeats = await _repository
                .Query()
                .Where(ss => ss.SessionSeats
                    .Any(s => s.Session.Id == sessionId && s.Status == ESeatStatus.Occupied))
                .ToListAsync();

            foreach (var sessionSeat in sessionSeats)
            {
                foreach (var seat in sessionSeat.SessionSeats)
                {
                    seat.Status = ESeatStatus.Occupied;
                }
            }

            await _repository.SaveChangesAsync();
        }
    }
}
