using FinalProj.Application.Core;
using FinalProj.Application.DTO_s.Venta;
using FinalProj.Application.Exceptions;
using Microsoft.Extensions.Configuration;

namespace FinalProj.Application.Extensions
{
    public static class ValidationVentaExtention
    {
        public static ServiceResult IsVentaValid(this VentaDTOBase ventaDto, IConfiguration configuration)
        {
            ServiceResult result = new ServiceResult();

            if (ventaDto.DocumentoCliente?.Length > 10)
                throw new VentaServiceException(configuration["MensajeValidaciones:documentoClienteLongitud"]);

            if (ventaDto.NombreCliente?.Length > 20)
                throw new VentaServiceException(configuration["MensajeValidaciones:nombreClienteLongitud"]);

            if (ventaDto.numeroVenta?.Length > 6)
                throw new VentaServiceException(configuration["MensajeValidaciones:numeroVentaLongitud"]);


            return result;
        }
    }
}
