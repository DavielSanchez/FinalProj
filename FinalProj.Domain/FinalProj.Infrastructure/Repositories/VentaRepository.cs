using FinalProj.Domain.Entities;
using FinalProj.Infrastructure.Context;
using FinalProj.Infrastructure.Core;
using FinalProj.Infrastructure.Interfaces;
using FinalProj.Infrastructure.Models;
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
        public List<VentaDocTypeModel> GetVentasDocTypes()
        {
            var ventasDocType = (from venta in this.GetEntities()
                                    join tipoDocumento in this.context.TipoDocumentoVenta
                                    on venta.idTipoDocumentoVenta equals tipoDocumento.id
                                    where !venta.Eliminado
                                    select new VentaDocTypeModel()
                                    {
                                        id = venta.id,
                                        idTipoDocumentoVenta = venta.idTipoDocumentoVenta,
                                        DocumentoCliente = venta.DocumentoCliente,
                                        NombreCliente = venta.NombreCliente,
                                        SubTotal = venta.SubTotal,
                                        ImpuestoTotal = venta.ImpuestoTotal,
                                        Total = venta.Total,
                                        FechaRegistro = venta.FechaRegistro,
                                        TipoDocumento = tipoDocumento.Descripcion,
                                    }).ToList();

            return ventasDocType;
        }
        public List<VentaDocTypeModel> GetVentasByDocTypesId(int doctypeId)
        {
            var ventasDocType = (from venta in this.GetEntities()
                                     join tipoDocumento in this.context.TipoDocumentoVenta
                                     on venta.idTipoDocumentoVenta equals tipoDocumento.id
                                     where tipoDocumento.id == doctypeId
                                     where !venta.Eliminado
                                     select new VentaDocTypeModel()
                                     {
                                         id = venta.id,
                                         idTipoDocumentoVenta = venta.idTipoDocumentoVenta,
                                         DocumentoCliente = venta.DocumentoCliente,
                                         NombreCliente = venta.NombreCliente,
                                         SubTotal = venta.SubTotal,
                                         ImpuestoTotal = venta.ImpuestoTotal,
                                         Total = venta.Total,
                                         FechaRegistro = venta.FechaRegistro,
                                         // Nombre del tipo de documento 
                                         TipoDocumento = tipoDocumento.Descripcion,
                                     }).ToList();

            return ventasDocType;
        }
        public VentaDocTypeModel GetVentaDocTypeById(int id)
        {
            return this.GetVentasDocTypes().SingleOrDefault(vt => vt.id == id);
        }
        public override void Save(Venta entity)
        {           
            context.Venta.Add(entity);           
            context.SaveChanges();
        }
        public override void Update(Venta entity)
        {

            Venta venta = this.GetEntity(entity.id);

            venta.id = entity.id;
            venta.numeroVenta = entity.numeroVenta;
            venta.idTipoDocumentoVenta = entity.idTipoDocumentoVenta;
            venta.idUsuario = entity.idUsuario;            
            venta.DocumentoCliente = entity.DocumentoCliente;
            venta.NombreCliente = entity.NombreCliente;
            venta.SubTotal = entity.SubTotal;
            venta.ImpuestoTotal = entity.ImpuestoTotal;           
            venta.Total = entity.Total;     
            
            venta.FechaMod = entity.FechaMod;
            venta.idUsuarioMod = entity.idUsuarioMod;

            context.Venta.Update(venta);
            context.SaveChanges();
        }
        public override void Remove(Venta entity)
        {
            Venta venta = this.GetEntity(entity.id);
            
            venta.id = entity.id;
            venta.Eliminado = entity.Eliminado;
            venta.FechaElimino = entity.FechaElimino;
            venta.idUsuarioElimino = entity.idUsuarioElimino;

            this.context.Venta.Update(venta);
            this.context.SaveChanges();
        }

    }
}
