using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers.Base
{
    public class CinemaControllerBase : ControllerBase
    {
        protected readonly IMediator _mediator;

        public CinemaControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}