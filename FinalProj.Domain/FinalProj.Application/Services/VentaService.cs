using FinalProj.Application.Contracts;
using FinalProj.Application.Core;
using FinalProj.Application.DTO_s.Venta;
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
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository ventaRepository;
        private readonly ILogger<VentaService> logger;
        private readonly IConfiguration configuration;

        public VentaService(IVentaRepository ventaRepository,
                             ILogger<VentaService> logger, IConfiguration configuration)
        {
            this.ventaRepository = ventaRepository;
            this.logger = logger;
            this.configuration = configuration;
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
                var validresult = dtoAdd.IsVentaValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
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
            catch (VentaServiceException vex)
            {
                result.Success = false;
                result.Message = vex.Message;
                this.logger.LogError($"{result.Message}", vex.ToString());
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

                var validresult = dtoUpdate.IsVentaValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
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
