using AutoMapper;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Cinema.Infrastructure.Enums;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class SeatService : BaseService<Seat, SeatDto>, ISeatService
    {
        private readonly IMapper _mapper;

        public SeatService(IBaseRepository<Seat> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<bool> AreSeatsAvailableAsync(Guid sessionId, IEnumerable<Guid> seatIds, CancellationToken cancellationToken)
        {
            var areSeatsAvailable = await _repository
                .Query()
                .Where(s => s.Id == sessionId)
                .AnyAsync(session => seatIds.All(seatId => session.SessionSeats.Any(ss => ss.Seat.Id == seatId && ss.Status == ESeatStatus.Available)), cancellationToken);

            return areSeatsAvailable;
        }

        public async Task<IEnumerable<SeatDto>> GetAvailableSeatsBySessionIdAsync(Guid sessionId, Guid hallId, CancellationToken cancellationToken)
        {
            var occupiedSeats = await _repository
               .Query()
               .Where(s => s.SessionSeats.Any(ss => ss.Session.Id == sessionId))
               .Select(s => s.Id)
               .ToListAsync(cancellationToken);

            var availableSeats = await _repository
                .Query()
                .Where(s => s.HallId == hallId && !occupiedSeats.Contains(s.Id))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<SeatDto>>(availableSeats);
        }

        public async Task<IEnumerable<SeatDto>> GetSeatsByHallIdAsync(Guid hallId, CancellationToken cancellationToken)
        {
            var seats = await _repository
                .Query()
                .Where(seat => seat.Hall.Id == hallId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<SeatDto>>(seats);
        }

        public async Task MarkSeatsAsAvailableAsync(Guid sessionId, IEnumerable<Guid> seatIds, CancellationToken cancellationToken)
        {
            var sessionSeats = await _repository
                 .Query()
                 .Where(s => s.SessionSeats
                     .Any(ss => ss.Session.Id == sessionId && ss.Status == ESeatStatus.Available))
                 .ToListAsync(cancellationToken);

            foreach (var sessionSeat in sessionSeats)
            {
                foreach (var seat in sessionSeat.SessionSeats)
                {
                    seat.Status = ESeatStatus.Available;
                }
            }

            await _repository.SaveChangesAsync(cancellationToken);
        }

        public async Task MarkSeatsAsOccupiedAsync(Guid sessionId, IEnumerable<Guid> seatIds, CancellationToken cancellationToken)
        {
            var sessionSeats = await _repository
                .Query()
                .Where(ss => ss.SessionSeats
                    .Any(s => s.Session.Id == sessionId && s.Status == ESeatStatus.Occupied))
                .ToListAsync(cancellationToken);

            foreach (var sessionSeat in sessionSeats)
            {
                foreach (var seat in sessionSeat.SessionSeats)
                {
                    seat.Status = ESeatStatus.Occupied;
                }
            }

            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}
