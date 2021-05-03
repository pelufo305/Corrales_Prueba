using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Siigo.Corrales.Domain.AggregateModel.ExampleAggregate;

namespace Siigo.Corrales.Api.Application.Commands
{
    /// <summary>
    /// Handler which processes the command when
    /// customer executes cancel order from app
    /// </summary>
    public class CorralCommandHandler : IRequestHandler<CorralCommand, string>
    {
        private readonly ICorralRepository _corralRepository;

        // Add any injected repository/helper/util 
        // or any class needed to handle the command
        public CorralCommandHandler(ICorralRepository corralRepository)
        {
            _corralRepository = corralRepository;
        }

        public async Task<string> Handle(CorralCommand request, CancellationToken cancellationToken)
        {

            Corral corral = new Corral();
            corral.id  = request.Id;
            corral.name = request.Name;
            corral.limit = request.Limit;
            corral.typecode = request.TypeCode;
            var example = await _corralRepository.Create(corral);
            if (example)
            {
                return $"Se registro correctamente el corral";
            }
            else
            {
                return $" NO Se registro correctamente el corral";
            }
        }
    }
}
