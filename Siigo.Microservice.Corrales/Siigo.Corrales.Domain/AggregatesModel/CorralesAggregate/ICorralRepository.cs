using System.Threading.Tasks;
using Siigo.Core.Domain.SeedWork;

namespace Siigo.Corrales.Domain.AggregateModel.ExampleAggregate
{



    public interface ICorralRepository : IRepository<Corral>
    {
        public Task<bool> Create(Corral corral);
    }
}
