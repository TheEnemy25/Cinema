using MediatR;

namespace Cinema.Application.Commands.Actor
{
    public record CreateActorCommand() : IRequest<Guid>;

    internal sealed class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, Guid>
    {
        public Task<Guid> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}