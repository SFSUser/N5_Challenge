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
    public class GetPermissionHandler : IRequestHandler<GetPermissionQuery, Permissions>
    {
        private readonly IUnitOfWork _mediator;
        private readonly IPermissionsQueryRepository _repoQuery;

        /*public GetPermissionHandler(IUnitOfWork mediator)
        {
            _mediator = mediator;
        }*/

        public GetPermissionHandler(IPermissionsQueryRepository mediator)
        {
            _repoQuery = mediator;
        }

        public async Task<Permissions> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
        {
            var selectedPermission = await _repoQuery.GetPermissionAsync(request.Id);
            return selectedPermission;
        }
    }
}