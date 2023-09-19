using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IDiscountService : IBaseService<Discount>
    {
        Task<IEnumerable<Discount>> GetDiscountsByMovieAsync(int movieId);
        Task<IEnumerable<Discount>> GetDiscountsByCinemaTheaterAsync(int cinemaTheaterId);
        Task<IEnumerable<Discount>> GetActiveDiscountsAsync();
    }
}
