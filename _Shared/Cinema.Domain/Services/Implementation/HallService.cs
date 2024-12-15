using AutoMapper;
using Cinema.Data.Infrastructure;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Cinema.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class HallService : BaseService<Hall, HallDto>, IHallService
    {
        private readonly IMapper _mapper;

        public HallService(IBaseRepository<Hall> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<HallDto>> GetHallsByCinemaTheaterIdAsync(Guid cinemaTheaterId, CancellationToken cancellationToken)
        {
            var hall = await _repository
                .Query()
                .Where(h => h.CinemaTheaterId == cinemaTheaterId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<HallDto>>(hall);
        }

        public async Task<IEnumerable<HallDto>> GetHallsByStatusAsync(EHallStatus status, CancellationToken cancellationToken)
        {
            var hall = await _repository
                .Query()
                .Where(h => h.Status == status)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<HallDto>>(hall);
        }

        public async Task<IEnumerable<HallDto>> GetHallsByTypeAsync(EHallType hallType, CancellationToken cancellationToken)
        {
            var hall = await _repository
                .Query()
                .Where(h => h.HallType == hallType)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<HallDto>>(hall);
        }

        public async Task<IEnumerable<HallDto>> GetHallsWithMoreNormalSeatsAsync(int seatCount, CancellationToken cancellationToken)
        {
            var hall = await _repository
                .Query()
                .Where(h => h.NormalSeatsCount > seatCount)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<HallDto>>(hall);
        }

        public async Task<IEnumerable<HallDto>> GetHallsWithMoreVIPSeatsAsync(int seatCount, CancellationToken cancellationToken)
        {
            var hall = await _repository
                .Query()
                .Where(h => h.VIPSeatsCount > seatCount)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<HallDto>>(hall);
        }
    }
}
