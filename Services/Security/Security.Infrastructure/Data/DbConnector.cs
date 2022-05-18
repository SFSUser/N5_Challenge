using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;

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
            string _connectionString = _configuration.GetConnectionString("DefaultConnection");
            //return new SqliteConnection(_connectionString);
            /// <summary>
            /// "Server=TPCCP-DB04\\SCBACK;Database=tpStandardsRegional;Trusted_Connection=True;"
            /// </summary>
            /// <returns></returns>
            return new SqlConnection("Server=DESKTOP-2I0HQ35\\SQLEXPRESS;Database=DESKTOP-2I0HQ35\\SQLEXPRESS;Trusted_Connection=True");
        }
    }
}