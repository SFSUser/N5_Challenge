using MediatR;
using Security.Core.Entities;
using System;

namespace Security.Application.Queries
{

    public class GetPermissionQuery: IRequest<Permissions>
    {
        public Int64 Id { get; private set; }
        
        public GetPermissionQuery(Int64 Id)
        {
            this.Id = Id;
        }

    }
}
