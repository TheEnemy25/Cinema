using Cinema.Application.Commands.Movie;
using FluentValidation;

namespace Cinema.Application.Validation.Movie.CommandValidator
{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(m => m.Id)
               .NotEmpty()
               .WithMessage("Movie ID is required.");
        }
    }
}
