using Cinema.Application.Queries.Actor;
using FluentValidation;

namespace Cinema.Application.Validation.Actor.QueryValidator
{
    internal sealed class GetActorByIdQueryValidator : AbstractValidator<GetActorByIdQuery>
    {
        public GetActorByIdQueryValidator()
        {
            RuleFor(query => query.Id)
               .NotEmpty().WithMessage("Id is required.")
               .NotEqual(Guid.Empty).WithMessage("Id must not be empty.");
        }
    }
}
