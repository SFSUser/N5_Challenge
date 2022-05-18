using MediatR;
using Security.Application.Queries;
using Security.Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Security.Application.Handlers.QueryHandlers
{
    public class GetCustomerByEmailHandler : IRequestHandler<GetCustomerByEmailQuery, Customer>
    {
        private readonly IMediator _mediator;

        public GetCustomerByEmailHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Customer> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            var customers = await _mediator.Send(new GetAllCustomerQuery());
            var selectedCustomer = customers.FirstOrDefault(x => x.Email.ToLower().Contains(request.Email.ToLower()));
            return selectedCustomer;
        }
    }
}