using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjektNET.Data
{
    public class OfferDbContext : DbContext
    {
        public OfferDbContext (DbContextOptions<OfferDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjektNET.Models.Offer> Offer => Set<ProjektNET.Models.Offer>();
    }
}