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
            this.context.Venta.Remove(venta);
        }

        public void Save(Venta venta)
        {
            this.context.Venta.Add(venta);
        }

        public void Update(Venta venta)
        {
            this.context.Venta.Update(venta);
        }

        public bool Exists(Expression<Func<Venta, bool>> filter)
        {
            return this.context.Venta.Any(filter);

        }

        public List<Venta> GetVentas()
        {
            return this.context.Venta.Where(vt => !vt.Eliminado).ToList();
        }

        public Venta GetVenta(int Id)
        {
            return this.context.Venta.Find(Id);
        }

    }
}
