using Security.Core.Entities;
using Security.Core.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Security.Core.Repositories.Query
{
    public interface IPermissionsQueryRepository : IQueryRepository<Permissions>
    {
        Task<IReadOnlyList<Permissions>> GetPermissionsAsync();
        Task<Permissions> GetPermissionAsync(Int64 id);
    }
}