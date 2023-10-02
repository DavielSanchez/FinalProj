using FinalProj.Domain.Entities;
using FinalProj.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FinalProj.Infrastructure.Interfaces
{
    public interface IVentaRepository : IRepositoryBase<Venta>
    {
        // Aqui van los metodos exclusivos de la entidad Venta.
        List<Venta> GetVentasByIDCliente (int idCliente);
        List<Venta> GetVentasByProducto (int idProducto);
        bool Exists(Expression<Func<Venta, bool>> filter);

    }
}

