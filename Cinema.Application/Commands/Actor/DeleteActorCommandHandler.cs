using Cinema.Domain.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Commands.Actor
{
    public record DeleteActorCommand(Guid Id) : IRequest;

    internal sealed class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand>
    {
        private readonly IActorService _actorService;
        private readonly ILogger<DeleteActorCommandHandler> _logger;

        public DeleteActorCommandHandler(IActorService actorService, ILogger<DeleteActorCommandHandler> logger)
        {
            _actorService = actorService;
            _logger = logger;
        }

        public async Task Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
            var actor = request.Id;

            _logger.LogInformation($"Deletion of actor with id {actor} begins");

            await _actorService.DeleteAsync(actor, cancellationToken);

            _logger.LogInformation($"Actor with id {actor} was successfully deleted");
        }
    }
}
