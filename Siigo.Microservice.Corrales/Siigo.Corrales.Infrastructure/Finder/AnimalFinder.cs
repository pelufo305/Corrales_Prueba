using DataAbstractions.Dapper;
using Microsoft.Extensions.Configuration;
using Serilog;

using Siigo.Core.Interface;
using Siigo.Corrales.Domain.AggregateModel.ExampleAggregate;
using Siigo.Corrales.Domain.AggregatesModel.AnimalAggregate;
using Siigo.Corrales.Domain.AggregatesModel.CorralesAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Siigo.Corrales.Infrastructure.Finder
{
    public class AnimalFinder : IAnimalFinder
    {
         private readonly IConfiguration _configuration;
        private readonly Serilog.ILogger _logger = Log.ForContext<AnimalFinder>();

        public AnimalFinder( IConfiguration configuration)
        {
  
            _configuration = configuration;

        }

       

        public async Task<List<Animal>> GetAnimals()
        {
            List<Animal> lstanimal = new List<Animal>();

            try
            {
                var connection = _configuration["ConnectionStrings:TenantConnection"];
                var query = "SELECT * FROM Animal";
                using (DataAccessor da = new DataAccessor(new SqlConnection(connection)))
                {
                    var result = await da.QueryAsync<Animal>(query);
                    lstanimal = result.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error");
            }
            return lstanimal;
        }

        public async Task<int> GetCountAnimalByCorral(int id)
        {
            int result = 0;
            try
            {
                var connection = _configuration["ConnectionStrings:TenantConnection"];
                var query = string.Format("SELECT COUNT(*) from Animal where corralcode = {0}", id);
                using (DataAccessor da = new DataAccessor(new SqlConnection(connection)))
                {
                    result = await da.ExecuteScalarAsync<int>(query);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error");
            }
            return result;
        }
    }
}
