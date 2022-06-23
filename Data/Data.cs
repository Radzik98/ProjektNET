using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjektNET.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjektNET.Models.Message> Message => Set<ProjektNET.Models.Message>();
        public DbSet<ProjektNET.Models.Offer> Offer => Set<ProjektNET.Models.Offer>();
        public DbSet<ProjektNET.Models.Rate> Rate => Set<ProjektNET.Models.Rate>();
        public DbSet<ProjektNET.Models.User> User => Set<ProjektNET.Models.User>();
    }
}