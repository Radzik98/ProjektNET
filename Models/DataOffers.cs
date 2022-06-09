using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjektNET.Data
{
    public class OfferDBContext : DbContext
    {
        public OfferDBContext (DbContextOptions<OfferDBContext> options)
            : base(options)
        {
        }

        public DbSet<ProjektNET.Models.Offer> Offer => Set<ProjektNET.Models.Offer>();
    }
}