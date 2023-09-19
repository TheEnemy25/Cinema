using Cinema.Data.Entities;
using Cinema.Data.Enums;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IHallService : IBaseService<Hall>
    {
        Task<IEnumerable<Hall>> GetHallsByTypeAsync(EHallType hallType);
        Task<IEnumerable<Hall>> GetHallsByStatusAsync(EHallStatus status);
        Task<IEnumerable<Hall>> GetHallsByCinemaTheaterIdAsync(Guid cinemaTheaterId);
        Task<IEnumerable<Hall>> GetHallsWithMoreNormalSeatsAsync(int seatCount);
        Task<IEnumerable<Hall>> GetHallsWithMoreVIPSeatsAsync(int seatCount);

    }
}
