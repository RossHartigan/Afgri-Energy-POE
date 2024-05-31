using AfgriEnergy.Models;
using Microsoft.EntityFrameworkCore;

namespace AfgriEnergy.Data
{
    public class AfgriEnergyContext : DbContext
    {

        public AfgriEnergyContext(DbContextOptions<AfgriEnergyContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}
