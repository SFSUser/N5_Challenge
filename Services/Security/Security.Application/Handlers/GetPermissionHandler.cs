using MediatR;
using Security.Application.Queries;
using Security.Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Security.Application.Handlers.QueryHandlers
{
    public class GetPermissionHandler : IRequestHandler<GetPermissionQuery, Permissions>
    {
        private readonly IMediator _mediator;

        public GetPermissionHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Permissions> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
        {
            var permissions = await _mediator.Send(new GetPermissionsQuery());
            var selectedPermission = permissions.FirstOrDefault(x => x.Id == request.Id);
            return selectedPermission;
        }
    }
}