using FinalProj.Domain.Entities;
using FinalProj.Domain.Repository;
using FinalProj.Infrastructure.Context;
using FinalProj.Infrastructure.Core;
using FinalProj.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FinalProj.Infrastructure.Repositories
{
    public class VentaRepository : BaseRepository<Venta>, IVentaRepository
    {
        private readonly SalesContext context;

        public VentaRepository(SalesContext context) : base(context)
        {
            this.context = context;
        }

        public List<Venta> GetVentasByCliente(string Cliente)
        {
            return this.context.Venta.Where(vt => vt.NombreCliente == Cliente
                                             && !vt.Eliminado).ToList();
        }
        public override List<Venta> GetEntities()
        {
            return base.GetEntities().Where(vt => !vt.Eliminado).ToList();
        }

        public override void Save(Venta entity)
        {
            context.Venta.Add(entity);           
            context.SaveChanges();
        }
        public override void Update(Venta entity)
        {
            var ventaToUpdate = base.GetEntity(entity.id);
            ventaToUpdate.id = entity.id;
            ventaToUpdate.numeroVenta = entity.numeroVenta;
            ventaToUpdate.idTipoDocumentoVenta = entity.idTipoDocumentoVenta;
            ventaToUpdate.idUsuario = entity.idUsuario;            
            ventaToUpdate.DocumentoCliente = entity.DocumentoCliente;
            ventaToUpdate.NombreCliente = entity.NombreCliente;
            ventaToUpdate.SubTotal = entity.SubTotal;
            ventaToUpdate.ImpuestoTotal = entity.ImpuestoTotal;           
            ventaToUpdate.Total = entity.Total;     
            
            ventaToUpdate.FechaMod = entity.FechaMod;
            ventaToUpdate.idUsuarioMod = entity.idUsuarioMod;

            context.Venta.Update(ventaToUpdate);
            context.SaveChanges();
        }

    }
}
