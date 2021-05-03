using Dapper;
using DataAbstractions.Dapper;
using Microsoft.Extensions.Configuration;
using Serilog;
using Siigo.Core.Domain.SeedWork;
using Siigo.Core.Interface;
using Siigo.Corrales.Domain.AggregateModel.ExampleAggregate;
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
    public class CorralRepository: ICorralRepository
    {
        public IUnitOfWork UnitOfWork { get; }

        private readonly IConfiguration _configuration;
        private readonly Serilog.ILogger _logger = Log.ForContext<CorralRepository>();
        public CorralRepository(IConfiguration configuration)
        {

            _configuration = configuration;

        }
        public async Task<bool> Create(Corral corral)
        {
            bool result = true;
            try
            {
                var connection = _configuration["ConnectionStrings:TenantConnection"];
                var query = "CreateCorral";
                var parameters = new DynamicParameters();
                parameters.Add("@id", corral.id);
                parameters.Add("@name", corral.name);
                parameters.Add("@limit", corral.limit);
                parameters.Add("@typecode", corral.typecode);
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
