using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siigo.Corrales.Api.Application.Model
{
    public class CorralModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int limit { get; set; }
        public int typecode { get; set; }

        public CorralModel()
        {

        }
    }
}
