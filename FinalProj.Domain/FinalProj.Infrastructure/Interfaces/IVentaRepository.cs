using FinalProj.Domain.Entities;
using FinalProj.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FinalProj.Infrastructure.Interfaces
{
    public interface IVentaRepository : IBaseRepository<Venta>
    {
        // Aqui van los metodos exclusivos de la entidad Venta.
        List<Venta> GetVentasByCliente (string Cliente);
        
    }
}

