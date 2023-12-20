using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.IOC.Dependencies
{
    public static class ProductoDependencies
    {
        public static void AddProductoDependecy(this IServiceCollection service)
        {
            service.AddScoped<IProductoRepository, ProductoRepository>();
            service.AddTransient<IProductoService, ProductoService>();
        }
    }
}
