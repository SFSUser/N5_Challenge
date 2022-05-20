using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Security.Core.Entities;

namespace Security.Core.Repositories.Command
{
    public interface IPermissionRepository : IDisposable
    {
        IEnumerable<Permissions> GetStudents();
        Permissions RequestPermission(int permissionId);
        void UpdatePermissions(Permissions permission);
        void Save();
    }
}