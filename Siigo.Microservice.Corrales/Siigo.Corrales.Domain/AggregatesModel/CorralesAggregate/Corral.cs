using Siigo.Core.Domain.SeedWork;

namespace Siigo.Corrales.Domain.AggregateModel.ExampleAggregate
{
    public class Corral: IAggregateRoot, IDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int limit { get; set; }
        public int typecode { get; set; }

        public Corral()
        {
          
        }
    }
}
