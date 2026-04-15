using Microsoft.EntityFrameworkCore;
using ApiVuelos.Models;

namespace ApiVuelos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vuelo> Vuelos { get; set; }
    }
}
