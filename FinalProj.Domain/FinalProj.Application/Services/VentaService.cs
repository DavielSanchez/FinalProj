using FinalProj.Application.Contracts;
using FinalProj.Application.Core;
using FinalProj.Application.DTO_s.Venta;
using FinalProj.Domain.Entities;
using FinalProj.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace FinalProj.Application.Services
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository ventaRepository;
        private readonly ILogger<VentaService> logger;

        public VentaService(IVentaRepository ventaRepository,
                             ILogger<VentaService> logger)
        {
            this.ventaRepository = ventaRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.ventaRepository.GetVentasDocTypes();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error obteniendo las ventas.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.ventaRepository.GetVentaDocTypeById(id);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error obteniendo la venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }


        public ServiceResult Remove(VentaDTORemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Venta venta = new Venta()
                {                    

                    id = dtoRemove.id,
                    Eliminado = dtoRemove.Eliminado,
                    idUsuarioElimino = dtoRemove.ChangeUser,
                    FechaElimino = dtoRemove.ChangeDate

                };

                this.ventaRepository.Remove(venta);

                result.Message = "La venta fue removida correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error removiendo la venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Save(VentaDTOAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                if (dtoAdd.NombreCliente.Length > 20)
                {
                    result.Message = "El nombre del cliente no puede ser mayor a 20 caracteres.";
                    result.Success = false;
                    return result;
                } 

                if(dtoAdd.DocumentoCliente.Length > 10)
                {
                    result.Message = "El documento del cliente no puede ser mayor a 10 caracteres.";
                    result.Success = false;
                    return result;
                }

                if (dtoAdd.SubTotal <= 0)
                {
                    result.Message = "El subtotal no puede ser menor a 0.";
                    result.Success = false;
                    return result;
                }


                Venta venta = new Venta()
                {

                    numeroVenta = dtoAdd.numeroVenta,
                    idTipoDocumentoVenta = dtoAdd.idTipoDocumentoVenta,
                    idUsuario = dtoAdd.idUsuario,
                    DocumentoCliente = dtoAdd.DocumentoCliente,
                    NombreCliente = dtoAdd.NombreCliente,
                    SubTotal = dtoAdd.SubTotal,
                    ImpuestoTotal = dtoAdd.ImpuestoTotal,
                    Total = dtoAdd.Total,

                    FechaRegistro = dtoAdd.ChangeDate,
                    idUsuarioCreacion = dtoAdd.ChangeUser,

                };

                this.ventaRepository.Save(venta);

                result.Message = "La venta fue guardada correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error guardando la venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(VentaDTOUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                if(dtoUpdate.NombreCliente?.Length > 20)
                {
                    result.Message = "El nombre del cliente no puede ser mayor a 20 caracteres.";
                    result.Success = false;
                    return result;
                }

                if (dtoUpdate.DocumentoCliente?.Length > 10)
                {
                    result.Message = "El documento del cliente no puede ser mayor a 10 caracteres.";
                    result.Success = false;
                    return result;
                }

                if(int.TryParse(dtoUpdate.id.ToString(), out int id) == false)
                {
                    result.Message = "El id de la venta no es valido.";
                    result.Success = false;
                    return result;
                }

                Venta venta = new Venta()
                {
                    id = dtoUpdate.id,
                    numeroVenta = dtoUpdate.numeroVenta,
                    idTipoDocumentoVenta = dtoUpdate.idTipoDocumentoVenta,
                    idUsuario = dtoUpdate.idUsuario,
                    DocumentoCliente = dtoUpdate.DocumentoCliente,
                    NombreCliente = dtoUpdate.NombreCliente,
                    SubTotal = dtoUpdate.SubTotal,
                    ImpuestoTotal = dtoUpdate.ImpuestoTotal,
                    Total = dtoUpdate.Total,

                    FechaMod = dtoUpdate.ChangeDate,
                    idUsuarioMod = dtoUpdate.ChangeUser,

                };

                this.ventaRepository.Update(venta);

                result.Message = "La venta fue actualizada correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error actualizando la venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }
}
