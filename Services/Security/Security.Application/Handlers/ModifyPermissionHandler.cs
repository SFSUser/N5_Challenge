using MediatR;
using Security.Application.Commands;
using Security.Application.Contracts.Persistence;
using Security.Application.Mapper;
using Security.Application.Response;
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
        private readonly IUnitOfWork _unitOfWork;
        public ModifyPermissionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                await _unitOfWork.PermissionsCommandRepository.UpdateAsync(PermissionsEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedPermissions = await _unitOfWork.PermissionsQueryRepository.GetPermissionAsync(request.Id);
            var PermissionsResponse = PermissionsMapper.Mapper.Map<PermissionResponse>(modifiedPermissions);

            return PermissionsResponse;
        }
    }
}