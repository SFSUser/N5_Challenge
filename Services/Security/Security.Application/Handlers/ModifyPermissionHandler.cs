using MediatR;
using Security.Application.Commands;
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
        private readonly IPermissionsCommandRepository _PermissionsCommandRepository;
        private readonly IPermissionsQueryRepository _PermissionsQueryRepository;
        public ModifyPermissionHandler(IPermissionsCommandRepository PermissionsRepository, IPermissionsQueryRepository PermissionsQueryRepository)
        {
            _PermissionsCommandRepository = PermissionsRepository;
            _PermissionsQueryRepository = PermissionsQueryRepository;
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
                await _PermissionsCommandRepository.UpdateAsync(PermissionsEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedPermissions = await _PermissionsQueryRepository.GetPermissionAsync(request.Id);
            var PermissionsResponse = PermissionsMapper.Mapper.Map<PermissionResponse>(modifiedPermissions);

            return PermissionsResponse;
        }
    }
}