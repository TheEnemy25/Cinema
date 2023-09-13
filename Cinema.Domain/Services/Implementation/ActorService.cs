using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class ActorService : BaseService<Actor>, IActorService
    {
        public ActorService(IBaseRepository<Actor> repository) : base(repository)
        {
        }

        public Task<IEnumerable<Actor>> GetActorsByCountryAsync(int countryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Actor>> GetActorsByMovieAsync(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Actor>> SearchActorsAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}
