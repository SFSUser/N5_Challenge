using Microsoft.EntityFrameworkCore;
using Security.Core.Entities;

namespace Security.Infrastructure.Data
{
    public class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base (options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
