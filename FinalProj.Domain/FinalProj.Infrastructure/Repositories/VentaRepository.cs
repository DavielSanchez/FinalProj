using FinalProj.Domain.Entities;
using FinalProj.Domain.Repository;
using FinalProj.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FinalProj.Infrastructure.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        private readonly SalesContext context;

        public VentaRepository(SalesContext context)
        {
            this.context = context;
        }

        public void Remove(Venta venta)
        {
            this.context.Ventas.Remove(venta);
        }

        public void Save(Venta venta)
        {
            this.context.Ventas.Add(venta);
        }

        public void Update(Venta venta)
        {
            this.context.Ventas.Update(venta);
        }

        public bool Exists(Expression<Func<Venta, bool>> filter)
        {
            return this.context.Ventas.Any(filter);

        }

        public List<Venta> GetVentas()
        {
            return this.context.Ventas.Where(vt => !vt.Elimino).ToList();
        }

        public Venta GetVenta(int Id)
        {
            return this.context.Ventas.Find(Id);
        }

    }
}
