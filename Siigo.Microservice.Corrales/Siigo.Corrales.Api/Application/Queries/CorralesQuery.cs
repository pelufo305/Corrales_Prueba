using MediatR;
using Siigo.Corrales.Api.Application.Model;
using Siigo.Corrales.Domain.AggregateModel.ExampleAggregate;
using System.Collections.Generic;

namespace Siigo.Corrales.Api.Application.Queries
{
    public class CorralesQuery: IRequest<List<Corral>>
    {

        public CorralesQuery()
        {
         }
    }
}
