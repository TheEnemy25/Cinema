using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class ScreenwriterService : BaseService<Screenwriter>, IScreenwriterService
    {
        public ScreenwriterService(IBaseRepository<Screenwriter> repository) : base(repository)
        {
        }

        public Task<IEnumerable<Screenwriter>> GetScreenwritersByMovieAsync(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Screenwriter>> SearchScreenwritersAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}
