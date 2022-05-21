using MediatR;
using Security.Application.Contracts.Persistence;
using Security.Application.CQRS.Commands;
using Security.Application.DTO.Response;
using Security.Application.Mapper;
using Security.Core.Entities;
using Security.Core.Repositories.Command;
using Security.Core.Repositories.Query;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Security.Application.Handlers.CommandHandler
{
    public class ModifyPermissionHandler : IRequestHandler<ModifyPermissionCommand, PermissionResponse>
    {
        private readonly IPermissionsQueryRepository _repoQuery;
        private readonly IPermissionsCommandRepository _repoCommand;
        private readonly IUnitOfWork _unitOfWork;

        public ModifyPermissionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repoQuery = _unitOfWork.PermissionsQueryRepository;
            _repoCommand = _unitOfWork.PermissionsCommandRepository;
        }
        
        public async Task<PermissionResponse> Handle(ModifyPermissionCommand request, CancellationToken cancellationToken)
        {
            var PermissionsEntity = PermissionsMapper.Mapper.Map<Permissions>(request);

            if (PermissionsEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _repoCommand.UpdateAsync(PermissionsEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedPermissions = await _repoQuery.GetPermissionAsync(request.Id);
            var PermissionsResponse = PermissionsMapper.Mapper.Map<PermissionResponse>(modifiedPermissions);

            return PermissionsResponse;
        }
    }
}