using Security.Core.Entities;
using Security.Core.Repositories.Command;
using Security.Infrastructure.Data;
using Security.Infrastructure.Repository.Command.Base;

namespace Security.Infrastructure.Repository.Command
{

    public class CustomerCommandRepository : CommandRepository<Customer>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(SecurityContext context) : base(context)
        {

        }
    }
}