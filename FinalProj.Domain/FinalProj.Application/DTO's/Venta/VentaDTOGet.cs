using System;

namespace FinalProj.Application.DTO_s.Venta
{
    public class VentaDTOGet
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
