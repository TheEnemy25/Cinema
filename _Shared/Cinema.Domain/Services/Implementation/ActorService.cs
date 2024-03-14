using AutoMapper;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class ActorService : BaseService<Actor, ActorDto>, IActorService
    {
        private readonly IMapper _mapper;

        public ActorService(IBaseRepository<Actor> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<ActorDto>> GetActorsByMovieAsync(Guid movieId, CancellationToken cancellationToken = default)
        {
            var actors = await _repository
                .Query()
                .Where(actors => actors.MovieActors.Any(movieActor => movieActor.MovieId == movieId))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ActorDto>>(actors);
        }

        public async Task<IEnumerable<ActorDto>> SearchActorsAsync(string query, CancellationToken cancellationToken = default)
        {
            var actors = await _repository
                .Query()
                .Where(actor => actor.FullName.Contains(query))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ActorDto>>(actors);
        }

        public async Task<bool> CheckIfExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.Query().Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            return entity is not null;
        }
    }
}