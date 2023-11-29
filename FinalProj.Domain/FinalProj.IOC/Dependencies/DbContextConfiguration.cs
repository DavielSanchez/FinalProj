using FinalProj.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProj.IOC.Dependencies
{
    public static class DbContextConfiguration
    {
        public static void ConfigureSalesContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SalesContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
