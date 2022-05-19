using MediatR;
using Security.Core.Entities;
using System.Collections.Generic;

namespace Security.Application.Queries
{
    public record GetPermissionsQuery : IRequest<List<Permissions>>
    {

    }
}
