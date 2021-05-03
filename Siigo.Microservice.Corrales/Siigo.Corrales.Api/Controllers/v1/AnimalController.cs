using MediatR;
using Microsoft.AspNetCore.Mvc;
using Siigo.Animales.Api.Application.Commands;
using Siigo.Corrales.Api.Application.Queries;
using Siigo.Corrales.Domain.AggregatesModel.AnimalAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Siigo.Corrales.Api.Controllers.v1
{
    [ApiController()]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AnimalController : Controller
    {
        private readonly IMediator _mediator;
        public AnimalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<List<Animal>> Corrales()
        => await this._mediator.Send(new AnimalQuery());

        [HttpPost()]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateAsync([FromBody] AnimalCommand command)
        {
            var process = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(process);
        }

    }
}
