using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjektNET.Data
{
    public class MessageDbContext : DbContext
    {
        public MessageDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjektNET.Models.Message> Message => Set<ProjektNET.Models.Message>();
    }
}