using System;

namespace FinalProj.Infrastructure.Models
{
    public class VentaDocTypeModel
    {
        public int id { get; set; }
        public int? idTipoDocumentoVenta { get; set; }
        public string? TipoDocumento { get; set; }
        public string? DocumentoCliente { get; set; }
        public string? NombreCliente { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ImpuestoTotal { get; set; }
        public decimal? Total { get; set; }

        public DateTime? FechaRegistro { get; set; }
    }
}
