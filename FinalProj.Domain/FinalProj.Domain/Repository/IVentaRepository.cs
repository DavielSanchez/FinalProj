using FinalProj.Domain.Entities;
using FinalProj.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FinalProj.Domain.Repository
{
    public interface IVentaRepository 
    {
        void Save(Venta venta);
        void Update(Venta venta);
        void Remove(Venta venta);
        List<Venta> GetVentas();
        Venta GetVenta(int Id);
        bool Exists(Expression<Func<Venta, bool>> filter);

    }
}

