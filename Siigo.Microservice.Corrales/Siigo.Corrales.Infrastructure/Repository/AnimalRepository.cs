using Dapper;
using DataAbstractions.Dapper;
using Microsoft.Extensions.Configuration;
using Serilog;
using Siigo.Core.Domain.SeedWork;
using Siigo.Core.Interface;
using Siigo.Corrales.Domain.AggregateModel.ExampleAggregate;
using Siigo.Corrales.Domain.AggregatesModel.AnimalAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Siigo.Corrales.Infrastructure.Repository
{
    public class AnimalRepository: IAnimalRepository
    {
        public IUnitOfWork UnitOfWork { get; }

        private readonly IConfiguration _configuration;
        private readonly Serilog.ILogger _logger = Log.ForContext<AnimalRepository>();
        public AnimalRepository(IConfiguration configuration)
        {

            _configuration = configuration;

        }
        public async Task<bool> Create(Animal animal)
        {
            bool result = true;
            try
            {
                var connection = _configuration["ConnectionStrings:TenantConnection"];
                var query = "Createanimal";
                var parameters = new DynamicParameters();
                parameters.Add("@id", animal.id);
                parameters.Add("@name", animal.name);
                parameters.Add("@@edad", animal.edad);
                parameters.Add("@typecode", animal.typecode);
                parameters.Add("@corralcode", animal.corralcode);
                parameters.Add("@isdangerous", animal.isdangerous);
                using (DataAccessor da = new DataAccessor(new SqlConnection(connection)))
                {
                    var operation = await  da.ExecuteAsync(query, parameters, null, null, CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error");
                result = false;
            }
            return result;
        }

       
    }
}
