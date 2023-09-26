using FinalProj.Domain.Entities;
using FinalProj.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Infrastructure.Interfaces
{
    public interface IVentaRepository : IRepositoryBase<Venta>
    {
        // Aqui van los metodos exclusivos de la entidad Venta.
        List<Venta> GetVentasByCliente (int idCliente);
        List<Venta> GetVentasByDate (DateTime fecha);
        List<Venta> GetVentasByProducto (int idProducto);
        List<Venta> GetVentasByProductoAndDate (int idProducto, DateTime fecha);
        List<Venta> GetVentasByClienteAndDate (int idCliente, DateTime fecha);
        List<Venta> GetVentasByTotal (decimal total);       

    }
}

// Prueba de push a mi branch.