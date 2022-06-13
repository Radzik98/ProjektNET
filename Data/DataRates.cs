using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjektNET.Data
{
    public class RateDbContext : DbContext
    {
        public RateDbContext (DbContextOptions<RateDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjektNET.Models.Rate> Rate => Set<ProjektNET.Models.Rate>();
    }
}