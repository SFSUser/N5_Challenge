using MediatR;
using Security.Application.Contracts.Persistence;
using Security.Application.Queries;
using Security.Core.Entities;
using Security.Core.Repositories.Query;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Security.Application.Handlers.QueryHandlers
{
    /// <summary>
    /// GetPermissionHandler class
    /// </summary>
    public class GetPermissionHandler : IRequestHandler<GetPermissionQuery, Permissions>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPermissionsQueryRepository _repoQuery;

        public GetPermissionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repoQuery = unitOfWork?.PermissionsQueryRepository;
        }

        public async Task<Permissions> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
        {
            var selectedPermission = await _repoQuery.GetPermissionAsync(request.Id);
            return selectedPermission;
        }
    }
}