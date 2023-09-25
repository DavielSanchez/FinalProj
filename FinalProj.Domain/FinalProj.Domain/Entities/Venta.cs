using FinalProj.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Domain.Entities
{
    public class Venta : BaseEntity
    {

        public int id { get; set; }
        public string? numeroVenta { get; set; }
        public int? idTipoDocumentoVenta { get; set; }
        public int? idUsuario { get; set; }
        public string? DocumentoCliente { get; set; }
        public string? NombreCliente { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ImpuestoTotal { get; set; }
        public decimal? Total { get; set; }
    }
}

// Prueba de push