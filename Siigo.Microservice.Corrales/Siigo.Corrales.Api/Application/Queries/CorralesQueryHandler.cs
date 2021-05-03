using System.Collections.Generic;
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
    public class CorralesQueryHandler : IRequestHandler<CorralesQuery, List<Corral>>
    {
        private readonly ICorralFinder _corralFinder;

        public CorralesQueryHandler(ICorralFinder corralFinder)
        {
            _corralFinder = corralFinder;
        }
        public async Task<List<Corral>> Handle(CorralesQuery request, CancellationToken cancellationToken)
        {
            var corrales = await _corralFinder.GetCorrales();
            return corrales;
        }
    }
}
