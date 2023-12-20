using FinalProj.Domain.Entities;
using FinalProj.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Infrastructure.Interfaces
{
    public interface IProductoRepository : IBaseRepository<Producto>
    {
        List<Producto> GetProductos();
        List<Producto> GetProducto(int Id);
        List<Producto> GetProductoByMarca(string Marca);

    }
}
