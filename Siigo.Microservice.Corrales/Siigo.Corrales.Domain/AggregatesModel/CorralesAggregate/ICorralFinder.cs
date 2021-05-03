using System.Collections.Generic;
using System.Threading.Tasks;
using Siigo.Core.Domain.SeedWork;
using Siigo.Corrales.Domain.AggregatesModel.CorralesAggregate;

namespace Siigo.Corrales.Domain.AggregateModel.ExampleAggregate
{
    public interface ICorralFinder{

        Task<List<Corral>> GetCorrales();
        Task<int> GetPromedio( int id);
        Task<Corral> GetByID(int id);
        Task<List<TypeAnimal>> GetTypeAnimal();



    }
}
