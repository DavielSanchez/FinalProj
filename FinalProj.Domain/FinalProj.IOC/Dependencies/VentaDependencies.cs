using FinalProj.Application.Contracts;
using FinalProj.Application.Services;
using FinalProj.Infrastructure.Interfaces;
using FinalProj.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace FinalProj.IOC.Dependencies
{
    public static class VentaDependencies
    {

        public static void AddVentaDependecy(this IServiceCollection service)
        {
            service.AddScoped<IVentaRepository, VentaRepository>();
            service.AddTransient<IVentaService, VentaService>();
        }

    }
}
