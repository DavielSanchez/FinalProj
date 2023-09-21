using FinalProj.Domain.Entities;
using FinalProj.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Infrastructure.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        public List<Venta> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Venta GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Venta> GetVentasByCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public List<Venta> GetVentasByClienteAndDate(int idCliente, DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public List<Venta> GetVentasByDate(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public List<Venta> GetVentasByProducto(int idProducto)
        {
            throw new NotImplementedException();
        }

        public List<Venta> GetVentasByProductoAndDate(int idProducto, DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public List<Venta> GetVentasByTotal(decimal total)
        {
            throw new NotImplementedException();
        }

        public void Remove(Venta entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Venta entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Venta entity)
        {
            throw new NotImplementedException();
        }
    }
}
