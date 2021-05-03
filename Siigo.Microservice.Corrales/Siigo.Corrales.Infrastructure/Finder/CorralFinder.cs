using DataAbstractions.Dapper;
using Microsoft.Extensions.Configuration;
using Serilog;

using Siigo.Core.Interface;
using Siigo.Corrales.Domain.AggregateModel.ExampleAggregate;
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
    public class CorralFinder : ICorralFinder
    {
         private readonly IConfiguration _configuration;
        private readonly Serilog.ILogger _logger = Log.ForContext<CorralFinder>();

        public CorralFinder( IConfiguration configuration)
        {
  
            _configuration = configuration;

        }

        public async Task<Corral> GetByID(int id)
        {
            Corral corral = new Corral();

            try
            {
                var connection = _configuration["ConnectionStrings:TenantConnection"];
                var query = string.Format("SELECT * FROM Corral where id ={0}", id);
                using (DataAccessor da = new DataAccessor(new SqlConnection(connection)))
                {
                    var result = await da.QueryAsync<Corral>(query);
                    corral = result.First();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error");
            }
            return corral;
        }

        public async Task<List<Corral>> GetCorrales()
        {
            List<Corral> lstcorral = new List<Corral>();

            try
            {
                var connection = _configuration["ConnectionStrings:TenantConnection"];
                var query = "SELECT * FROM Corral";
                using (DataAccessor da = new DataAccessor(new SqlConnection(connection)))
                {
                    var result = await da.QueryAsync<Corral>(query);
                    lstcorral= result.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error");
            }
            return lstcorral;
        }

        public async Task<int> GetPromedio( int id)
        {
            int result = 0;
            try
            {
                var connection = _configuration["ConnectionStrings:TenantConnection"];
                var query = string.Format("SELECT AVG(edad) from Animal  JOIN Corral ON Corral.id = Animal.corralcode where corralcode = {0}", id);
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

        public async Task<List<TypeAnimal>> GetTypeAnimal()
        {
            List<TypeAnimal> lsttype = new List<TypeAnimal>();

            try
            {
                var connection = _configuration["ConnectionStrings:TenantConnection"];
                var query = "SELECT * FROM type_animal";
                using (DataAccessor da = new DataAccessor(new SqlConnection(connection)))
                {
                    var result = await da.QueryAsync<TypeAnimal>(query);
                    lsttype = result.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error");
            }
            return lsttype;
        }
    }
}
