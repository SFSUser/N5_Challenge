using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Security.Infrastructure.Data
{
    public class DbConnector
    {
        private readonly IConfiguration _configuration;

        protected DbConnector(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            //return new SqliteConnection(_connectionString);
            /// <summary>
            /// "Server=TPCCP-DB04\\SCBACK;Database=tpStandardsRegional;Trusted_Connection=True;"
            /// </summary>
            /// <returns></returns>
            string _connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(_connectionString);
        }
    }
}