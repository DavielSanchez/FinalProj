using FinalProj.API.Models.Core;

namespace FinalProj.API.Models.Modules.Venta
{
    public abstract class VentaBaseModel : ModelBase
    {
        public string? numeroVenta { get; set; }
        public int idUsuario { get; set; }
        public int idTipoDocumentoVenta { get; set; }
        public string? DocumentoCliente { get; set; }
        public string? NombreCliente { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ImpuestoTotal { get; set; }
        public decimal? Total { get; set; }
    }
}
