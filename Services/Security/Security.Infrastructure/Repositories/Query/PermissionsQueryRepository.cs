using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Security.Core.Entities;
using Security.Core.Repositories.Query;
using Security.Infrastructure.Data;
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
        public PermissionsQueryRepository(IConfiguration configuration, SecurityContext context) 
            : base(configuration, context)
        {

        }

        public async Task<IReadOnlyList<Permissions>> GetPermissionsAsync()
        {
            var me = this;
            try
            {
                return await Task.Factory.StartNew<IReadOnlyList<Permissions>>(() => {
                    return me._context
                        .Permissions
                        .Include(u=>u.PermissionType)
                        .ToList();
                });
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
        
        public async Task<Permissions> GetPermissionAsync(long id)
        {
            var me = this;
            try
            {
                return await Task.Factory.StartNew<Permissions>(() => {
                    return me._context
                        .Permissions
                        .Include(u => u.PermissionType)
                        .FirstOrDefault( e => e.Id == id);
                });
                /*var query = "SELECT * FROM Permisos p WHERE Id = @Id LEFT JOIN TipoPermisos tp on t.TipoPermiso = tp.Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Permissions>(query, parameters));
                }*/
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
    }
}