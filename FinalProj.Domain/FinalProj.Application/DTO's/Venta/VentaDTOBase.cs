using FinalProj.Application.DTO_s.Base;

namespace FinalProj.Application.DTO_s.Venta
{
    public abstract class VentaDTOBase : DTOBase
    {
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
