using MediatR;
using Security.Application.Contracts.Persistence;
using Security.Application.Queries;
using Security.Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Security.Application.Handlers.QueryHandlers
{
    public class GetPermissionHandler : IRequestHandler<GetPermissionQuery, Permissions>
    {
        private readonly IUnitOfWork _mediator;

        public GetPermissionHandler(IUnitOfWork mediator)
        {
            _mediator = mediator;
        }
        public async Task<Permissions> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
        {
            var selectedPermission = await _mediator.PermissionsQueryRepository.GetPermissionAsync(request.Id);
            return selectedPermission;
        }
    }
}