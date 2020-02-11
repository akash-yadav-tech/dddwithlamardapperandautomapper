using System.Data;
using System.Data.SqlClient;
using POC.Core.Configuration;

namespace POC.Infrastructure.Repository.Dapper
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;
        public ConnectionFactory(ISettingsProvider settingsProvider)
        {
            this._connectionString = settingsProvider.Get<string>(SettingKeys.ConnectionString).ToString();
        }

        public IDbConnection Create()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
