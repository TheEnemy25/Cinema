using Cinema.Application.Commands.Actor;
using FluentValidation;

namespace Cinema.Application.Validation.Actor.CommandValidator
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(command => command.FullName)
                .NotEmpty()
                .WithMessage("Full name is required.")
                .MaximumLength(50)
                .WithMessage("Full name must not exceed 50 characters.");

            RuleFor(command => command.Image)
                .NotEmpty()
                .WithMessage("Image is required.");

            RuleFor(command => command.Biography)
                .NotEmpty()
                .WithMessage("Biography is required.");

            RuleFor(command => command.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth is required.");
        }
    }
}
