using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Siigo.Corrales.Api.Application.Commands;
using Siigo.Corrales.Api.Application.Queries;
using Siigo.Corrales.Domain.AggregateModel.ExampleAggregate;
using Siigo.Corrales.Domain.AggregatesModel.CorralesAggregate;

namespace Siigo.Corrales.Api.Controllers.v1
{
    [ApiController()]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CorralController : Controller
    {

        private readonly IMediator _mediator;
        public CorralController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("promedio/{id}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<string> PromedioAnimalCorral(int id)
            => await this._mediator.Send(new PromedioAnimalCorralQuery(id));


        [HttpGet()]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<List<Corral>> Corrales()
        => await this._mediator.Send(new CorralesQuery());


        [HttpPost()]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateAsync([FromBody] CorralCommand command)
        {
            var process = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(process);
        }


        [HttpGet("typeanimal/")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<List<TypeAnimal>> TypeAnimal()
        => await this._mediator.Send(new TypeAnimalQuery());
    }
}
