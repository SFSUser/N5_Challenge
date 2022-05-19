using MediatR;
using Security.Application.Queries;
using Security.Core.Entities;
using Security.Core.Repositories.Query;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Security.Application.Handlers.QueryHandlers
{
    public class GetPermissionsHandler : IRequestHandler<GetPermissionsQuery, List<Permissions>>
    {
        private readonly IPermissionsQueryRepository _PermissionsQueryRepository;

        public GetPermissionsHandler(IPermissionsQueryRepository PermissionsQueryRepository)
        {
            _PermissionsQueryRepository = PermissionsQueryRepository;
        }
        public async Task<List<Permissions>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            return (List<Permissions>)await _PermissionsQueryRepository.GetPermissionsAsync();
        }
    }
}