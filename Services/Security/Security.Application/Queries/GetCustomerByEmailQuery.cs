using MediatR;
using Security.Core.Entities;

namespace Security.Application.Queries
{

    public class GetCustomerByEmailQuery: IRequest<Customer>
    {
        public string Email { get; private set; }
        
        public GetCustomerByEmailQuery(string email)
        {
            this.Email = email;
        }

    }
}
