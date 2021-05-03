using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Siigo.Corrales.Api.Application.Model;
using Siigo.Corrales.Domain.AggregateModel.ExampleAggregate;
using Siigo.Corrales.Domain.AggregatesModel.CorralesAggregate;

namespace Siigo.Corrales.Api.Application.Queries
{
    // Siigo.Corrales.Apis Architecture comment
    // Creating queries independent of the domain model, the aggregates boundaries and 
    // constraints are completely ignored gives freedom to query any table and column you might need. 
    // This approach provides great flexibility and productivity for the developers creating or updating the queries.
    public class TypeAnimalQueryHandler : IRequestHandler<TypeAnimalQuery, List<TypeAnimal>>
    {
        private readonly ICorralFinder _corralFinder;

        public TypeAnimalQueryHandler(ICorralFinder corralFinder)
        {
            _corralFinder = corralFinder;
        }

        public async Task<List<TypeAnimal>> Handle(TypeAnimalQuery request, CancellationToken cancellationToken)
        {
            var type = await _corralFinder.GetTypeAnimal();
            return type;
        }

        
    }
}
