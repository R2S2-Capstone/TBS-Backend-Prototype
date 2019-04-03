using Microsoft.EntityFrameworkCore;

namespace TBS_Backend_Prototype.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
