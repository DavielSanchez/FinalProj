using FinalProj.Application.Contracts;
using FinalProj.Application.Core;
using FinalProj.Application.DTO_s.Producto;
using FinalProj.Application.Exceptions;
using FinalProj.Application.Extensions;
using FinalProj.Domain.Entities;
using FinalProj.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace FinalProj.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository ventaRepository;
        private readonly ILogger<ProductoService> logger;
        private readonly IConfiguration configuration;

        public ProductoService(IProductoRepository productoRepository,
                             ILogger<ProductoService> logger, IConfiguration configuration)
        {
            this.productoRepository = productoRepository;
            this.logger = logger;
            this.configuration = configuration;
        }
        public ServiceResult GetProductos()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.productoRepository.GetProductos();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error obteniendo los Productos";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult GetProductoById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.productoRepository.GetProductosById(id);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error obteniendo la venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Remove(ProductoDTORemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Producto venta = new Producto()
                {

                    id = dtoRemove.id,
                    Eliminado = dtoRemove.Eliminado,
                    idUsuarioElimino = dtoRemove.ChangeUser,
                    FechaElimino = dtoRemove.ChangeDate

                };

                this.productoRepository.Remove(producto);

                result.Message = "El producto fue removido correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error removiendo el producto";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Save(ProductoDTOAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var validresult = dtoAdd.IsProductoValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }

                Producto producto = new Producto()
                {

                    CodigoBarra = dtoAdd.CodigoBarra,
                    Marca = dtoAdd.Marca,
                    Descripcion = dtoAdd.Descripcion,
                    IdCategoria = dtoAdd.IdCategoria,
                    Stock = dtoAdd.Stock,
                    UrlImagen = dtoAdd.UrlImagen,
                    NombreImagen = dtoAdd.NombreImagen,
                    Precio = dtoAdd.Precio,
                    EsActivo = dtoAdd.EsActivo,

                    FechaRegistro = dtoAdd.FechaRegistro,
                    IdUsuarioCreacion = dtoAdd.IdUsuarioCreacion,

                };

                this.productoRepository.Save(producto);

                result.Message = "El producto fue guardado correctamente.";
            }
            catch (ProductoServiceException vex)
            {
                result.Success = false;
                result.Message = vex.Message;
                this.logger.LogError($"{result.Message}", vex.ToString());
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error guardando el producto";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Update(ProductoDTOUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                var validresult = dtoUpdate.IsProductoValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }

                Producto producto = new Producto()
                {

                    CodigoBarra = dtoUpdate.CodigoBarra,
                    Marca = dtoUpdate.Marca,
                    Descripcion = dtoUpdate.Descripcion,
                    IdCategoria = dtoUpdate.IdCategoria,
                    Stock = dtoUpdate.Stock,
                    UrlImagen = dtoUpdate.UrlImagen,
                    NombreImagen = dtoUpdate.NombreImagen,
                    Precio = dtoUpdate.Precio,
                    EsActivo = dtoUpdate.EsActivo,

                    FechaMod = dtoUpdate.FechaMod,
                    IdUsuarioMod = dtoUpdate.IdUsuarioMod,

                };

                this.ventaRepository.Update(producto);

                result.Message = "El producto fue actualizado correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error actualizando el producto";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }
}
