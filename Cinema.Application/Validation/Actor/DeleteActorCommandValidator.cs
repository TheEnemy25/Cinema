using Cinema.Application.Commands.Actor;
using FluentValidation;

namespace Cinema.Application.Validation.Actor
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty()
                .WithMessage("Actor ID is required.");
        }
    }
}
