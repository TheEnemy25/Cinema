using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class ActorService : BaseService<Actor>, IActorService
    {
        public ActorService(IBaseRepository<Actor> repository) : base(repository)
        {
        }

        public async Task<IEnumerable<Actor>> GetActorsByMovieAsync(Guid movieId)
        {
            return await _repository
               .Query()
               .Where(actor => actor.MovieActors.Any(movieActor => movieActor.MovieId == movieId))
               .ToListAsync();
        }

        public async Task<IEnumerable<Actor>> SearchActorsAsync(string query)
        {
            return await _repository
                .Query()
                .Where(actor => actor.FullName.Contains(query))
                .ToListAsync();
        }
    }
}
