using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siigo.Corrales.Domain.AggregatesModel.AnimalAggregate
{
    public interface IAnimalFinder
    {
        Task<List<Animal>> GetAnimals();
        Task<int> GetCountAnimalByCorral(int id);

    }
}
