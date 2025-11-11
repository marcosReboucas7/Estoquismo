using Microsoft.EntityFrameworkCore;

namespace Estoquismo.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Entities.Equipamentos> Equipamentos { get; set; }
        public DbSet<Entities.Tecnicos> Tecnicos { get; set; }
    }
}
