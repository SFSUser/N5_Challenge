using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Security.Core.Repositories.Command;
using Security.Core.Repositories.Query;

namespace Security.Application.Contracts.Persistence
{
    public interface IUnitOfWork: IDisposable
    {
        public IPermissionsQueryRepository PermissionsQueryRepository { get; }
        public IPermissionsCommandRepository PermissionsCommandRepository { get; }
        public Task Save();
    }
}