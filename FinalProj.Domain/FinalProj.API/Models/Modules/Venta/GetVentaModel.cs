namespace FinalProj.API.Models.Modules.Venta
{
    public class GetVentaModel
    {
        public int idUsuario { get; set; }
        public int? idTipoDocumentoVenta { get; set; }
        public string? DocumentoCliente { get; set; }
        public string? NombreCliente { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ImpuestoTotal { get; set; }
        public decimal? Total { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
