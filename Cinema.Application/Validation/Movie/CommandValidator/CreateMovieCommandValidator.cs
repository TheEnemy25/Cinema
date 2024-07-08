using Cinema.Application.Commands.Movie;
using FluentValidation;

namespace Cinema.Application.Validation.Movie.CommandValidator
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(command => command.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(50)
                .WithMessage("Title must not exceed 50 characters.");

            RuleFor(command => command.AgeRestriction)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Age is required.");

            RuleFor(command => command.Description)
                .NotEmpty()
                .WithMessage("Description is required.")
                .MaximumLength(1000)
                .WithMessage("Description must not exceed 1000 characters.");

            RuleFor(command => command.ImageLink)
                    .NotEmpty()
                    .WithMessage("Image is required.");

            RuleFor(command => command.TrailerLink)
                    .NotEmpty()
                    .WithMessage("Trailer is required.");

            RuleFor(command => command.Rating)
                    .NotEmpty()
                    .WithMessage("Rating is required.");

            RuleFor(command => command.Duration)
                    .NotEmpty()
                    .WithMessage("Duration is required.");

            RuleFor(command => command.ReleaseDate)
                    .NotEmpty()
                    .WithMessage("Release date is required.");
        }
    }
}
