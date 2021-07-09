using Microsoft.EntityFrameworkCore;
using ApiNet.Entities;

namespace ApiNet.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationRol> ApplicationRol { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
