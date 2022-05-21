using MediatR;
using Security.Core.Entities;
using System.Collections.Generic;

namespace Security.Application.Queries
{
    /// <summary>
    /// GetPermissionQuery class
    /// </summary>
    public record GetPermissionsQuery : IRequest<List<Permissions>>
    {

    }
}
