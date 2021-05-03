using MediatR;
using Siigo.Corrales.Api.Application.Model;
using Siigo.Corrales.Domain.AggregatesModel.AnimalAggregate;
using Siigo.Corrales.Domain.AggregatesModel.CorralesAggregate;
using System.Collections.Generic;

namespace Siigo.Corrales.Api.Application.Queries
{
    public class AnimalQuery : IRequest<List<Animal>>
    {

        public AnimalQuery()
        {
         }
    }
}
