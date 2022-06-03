using Microsoft.EntityFrameworkCore;

namespace ProjektNET.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext (DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjektNET.Models.Customer> Customer => Set<ProjektNET.Models.Customer>();
    }
}