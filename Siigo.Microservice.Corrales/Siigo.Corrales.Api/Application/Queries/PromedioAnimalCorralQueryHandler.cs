using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Siigo.Corrales.Api.Application.Model;
using Siigo.Corrales.Domain.AggregateModel.ExampleAggregate;

namespace Siigo.Corrales.Api.Application.Queries
{
    // Siigo.Corrales.Apis Architecture comment
    // Creating queries independent of the domain model, the aggregates boundaries and 
    // constraints are completely ignored gives freedom to query any table and column you might need. 
    // This approach provides great flexibility and productivity for the developers creating or updating the queries.
    public class PromedioAnimalCorralQueryHandler : IRequestHandler<PromedioAnimalCorralQuery, string>
    {
        private readonly ICorralFinder _corralFinder;

        public PromedioAnimalCorralQueryHandler(ICorralFinder corralFinder)
        {
            _corralFinder = corralFinder;
        }

        public async Task<string> Handle(PromedioAnimalCorralQuery request, CancellationToken cancellationToken)
        {
            
            var edad = await _corralFinder.GetPromedio(request.Id);
            return "Promedio de edad es:" + edad;
        }
        
    }
}
