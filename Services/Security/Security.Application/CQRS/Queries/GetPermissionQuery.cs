using MediatR;
using Security.Core.Entities;
using System;

namespace Security.Application.CQRS.Queries
{
    /// <summary>
    /// GetPermissionQuery class
    /// </summary>

    public class GetPermissionQuery : IRequest<Permissions>
    {
        public long Id { get; private set; }

        public GetPermissionQuery(long Id)
        {
            this.Id = Id;
        }

    }
}
