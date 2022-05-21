using MediatR;
using Security.Application.Contracts.Persistence;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPermissionsQueryRepository _repo;

        public GetPermissionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repo = unitOfWork.PermissionsQueryRepository;
        }

        public async Task<List<Permissions>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            return (List<Permissions>)await _repo.GetPermissionsAsync();
        }
    }
}