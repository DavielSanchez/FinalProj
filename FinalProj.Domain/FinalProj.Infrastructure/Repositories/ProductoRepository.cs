using FinalProj.Domain.Entities;
using FinalProj.Infrastructure.Context;
using FinalProj.Infrastructure.Core;
using FinalProj.Infrastructure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FinalProj.Infrastructure.Repositories
{
    public class ProductoRepository : BaseRepository<Producto>, IProductoRepository
    {
        private readonly SalesContext context;

        public ProductoRepository(SalesContext context) : base(context)
        {
            this.context = context;
        }

        public List<Producto> GetProducto(int Id)
        {
            return this.context.Productos.Where(producto => !(producto.Id != Id)).ToList();
        }
        public List<Producto> GetProductoByMarca(int Id, string Marca)
        {
            return this.context.Productos.Where(producto => !(producto.Marca != Marca)).ToList();
        }
        public override List<Producto> GetEntities()
        {
            return base.GetEntities().Where(producto => producto.Eliminado == false).ToList();
        }

        
        
        public override void Update(Producto entity)
        {

            Producto producto = this.GetEntity((int)entity.Id);

            producto.Id = entity.Id;
            producto.CodigoBarra = entity.CodigoBarra;
            producto.Marca = entity.Marca;
            producto.Descripcion = entity.Descripcion;
            producto.IdCategoria = entity.IdCategoria;
            producto.Stock = entity.Stock;
            producto.UrlImagen = entity.UrlImagen;
            producto.NombreImagen = entity.NombreImagen;
            producto.Precio = entity.Precio;
            producto.EsActivo = entity.EsActivo;

            producto.FechaMod = entity.FechaMod;
            producto.IdUsuarioMod = entity.IdUsuarioMod;

            context.Productos.Update(producto);
            context.SaveChanges();

        }
        public override void Remove(Producto entity)
        {
            Producto producto = this.GetEntity((int)entity.Id);

            producto.Id = entity.Id;
            producto.Eliminado = entity.Eliminado;
            producto.FechaElimino = entity.FechaElimino;
            producto.IdUsuarioElimino = entity.IdUsuarioElimino;

            this.context.Productos.Update(producto);
            this.context.SaveChanges();
        }


    }
}
