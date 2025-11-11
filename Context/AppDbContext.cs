using Estoquismo.Entities;

using Microsoft.EntityFrameworkCore;

namespace Estoquismo.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Equipamentos> Equipamentos { get; set; }
        public DbSet<Tecnicos> Tecnicos { get; set; }
    }
}
