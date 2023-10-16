using Microsoft.EntityFrameworkCore;

namespace FinalProj.Infrastructure.Context
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {
        }
    
        public DbSet<Venta> Ventas { get; set; }
        public object Negocio { get; internal set; }
    }
}
