using Siigo.Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siigo.Corrales.Domain.AggregatesModel.AnimalAggregate
{
    public class Animal : IAggregateRoot, IDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int edad { get; set; }
        public int typecode { get; set; }
        public int corralcode { get; set; }
        public bool isdangerous { get; set; }

        public Animal()
        {

        }
    }
}
