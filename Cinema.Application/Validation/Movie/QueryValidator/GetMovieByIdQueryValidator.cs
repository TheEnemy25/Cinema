using Cinema.Application.Queries.Movie;
using FluentValidation;

namespace Cinema.Application.Validation.Movie.QueryValidator
{
    public class GetMovieByIdQueryValidator : AbstractValidator<GetMovieByIdQuery>
    {
        public GetMovieByIdQueryValidator()
        {
            RuleFor(query => query.Id)
               .NotEmpty().WithMessage("Id is required.")
               .NotEqual(Guid.Empty).WithMessage("Id must not be empty.");
        }
    }
}
