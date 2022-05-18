using Microsoft.Extensions.Configuration;
using Security.Core.Repositories.Query.Base;
using Security.Infrastructure.Data;

namespace Security.Infrastructure.Repository.Query.Base
{
    public class QueryRepository<T> : DbConnector,  IQueryRepository<T> where T : class
    {
        public QueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }
    }
}