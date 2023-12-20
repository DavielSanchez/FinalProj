using FinalProj.Application.Core;
using FinalProj.Application.DTO_s.Producto;
using FinalProj.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace FinalProj.Application.Extensions
{
    public static class ValidationProductoExtention
    {
        public static ServiceResult IsProductoValid(this ProductoDTOBase productoDto, IConfiguration configuration)
        {
            ServiceResult result = new ServiceResult();

            if (productoDto.NombreImagen?.Length > 5)
                throw new ProductoServiceException(configuration["MensajeValidaciones:NombreImagenLongitud"]);

            if (productoDto.Marca?.Length > 3)
                throw new ProductoServiceException(configuration["MensajeValidaciones:MarcaLongitud"]);

            if (productoDto.UrlImagen?.Length > 6)
                throw new ProductoServiceException(configuration["MensajeValidaciones:UrlImagenLongitud"]);


            return result;
        }
    }
}
