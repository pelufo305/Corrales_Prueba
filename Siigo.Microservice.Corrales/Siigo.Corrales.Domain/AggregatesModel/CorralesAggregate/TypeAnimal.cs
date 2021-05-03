using Siigo.Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siigo.Corrales.Domain.AggregatesModel.CorralesAggregate
{
    public class TypeAnimal : IAggregateRoot, IDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public TypeAnimal()
        {

        }
    }

    
}
