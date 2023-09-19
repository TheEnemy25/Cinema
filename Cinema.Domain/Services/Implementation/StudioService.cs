using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class StudioService : BaseService<Studio>, IStudioService
    {
        public StudioService(IBaseRepository<Studio> repository) : base(repository)
        {
        }

        public Task<IEnumerable<Movie>> GetMoviesByStudioIdAsync(Guid studioId)
        {
            throw new NotImplementedException();
        }
    }
}
