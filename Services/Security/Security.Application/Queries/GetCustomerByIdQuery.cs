using MediatR;
using Security.Core.Entities;
using System;

namespace Security.Application.Queries
{

    public class GetCustomerByIdQuery: IRequest<Customer>
    {
        public Int64 Id { get; private set; }
        
        public GetCustomerByIdQuery(Int64 Id)
        {
            this.Id = Id;
        }

    }
}
