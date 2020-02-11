using System.Data;

namespace POC.Infrastructure.Repository.Dapper
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
