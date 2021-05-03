using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Siigo.Corrales.Api.Application.Model;
using Siigo.Corrales.Domain.AggregateModel.ExampleAggregate;
using Siigo.Corrales.Domain.AggregatesModel.AnimalAggregate;
using Siigo.Corrales.Domain.AggregatesModel.CorralesAggregate;

namespace Siigo.Corrales.Api.Application.Queries
{
    // Siigo.Corrales.Apis Architecture comment
    // Creating queries independent of the domain model, the aggregates boundaries and 
    // constraints are completely ignored gives freedom to query any table and column you might need. 
    // This approach provides great flexibility and productivity for the developers creating or updating the queries.
    public class AnimalQueryHandler : IRequestHandler<AnimalQuery, List<Animal>>
    {
        private readonly IAnimalFinder _animalFinder;

        public AnimalQueryHandler(IAnimalFinder animalFinder)
        {
            _animalFinder = animalFinder;
        }

        public async Task<List<Animal>> Handle(AnimalQuery request, CancellationToken cancellationToken)
        {
            var type = await _animalFinder.GetAnimals();
            return type;
        }

        
    }
}
