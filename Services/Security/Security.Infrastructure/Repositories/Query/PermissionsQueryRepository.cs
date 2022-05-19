using Dapper;
using Microsoft.Extensions.Configuration;
using Security.Core.Entities;
using Security.Core.Repositories.Query;
using Security.Infrastructure.Repository.Query.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Infrastructure.Repository.Query
{
    public class PermissionsQueryRepository : QueryRepository<Permissions>, IPermissionsQueryRepository
    {
        public PermissionsQueryRepository(IConfiguration configuration) 
            : base(configuration)
        {

        }

        public async Task<IReadOnlyList<Permissions>> GetPermissionsAsync()
        {
            try
            {
                var query = "SELECT * FROM Permisos";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Permissions>(query)).ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
        
        public async Task<Permissions> GetPermissionAsync(long id)
        {
            try
            {
                var query = "SELECT * FROM Permisos WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Permissions>(query, parameters));
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
    }
}