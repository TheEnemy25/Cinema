using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Cinema.Infrastructure.Enums;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IHallService : IBaseService<Hall, HallDto>
    {
        Task<IEnumerable<HallDto>> GetHallsByTypeAsync(EHallType hallType, CancellationToken cancellationToken = default);
        Task<IEnumerable<HallDto>> GetHallsByStatusAsync(EHallStatus status, CancellationToken cancellationToken = default);
        Task<IEnumerable<HallDto>> GetHallsByCinemaTheaterIdAsync(Guid cinemaTheaterId, CancellationToken cancellationToken = default);
        Task<IEnumerable<HallDto>> GetHallsWithMoreNormalSeatsAsync(int seatCount, CancellationToken cancellationToken = default);
        Task<IEnumerable<HallDto>> GetHallsWithMoreVIPSeatsAsync(int seatCount, CancellationToken cancellationToken = default);

    }
}
