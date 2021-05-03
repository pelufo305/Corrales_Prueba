using System.Data;
using DataAbstractions.Dapper;

namespace Siigo.Corrales.Infrastructure
{
    public interface ISqlConnectionFactory
    {
        IDataAccessor GetOpenConnection();
    }
}
