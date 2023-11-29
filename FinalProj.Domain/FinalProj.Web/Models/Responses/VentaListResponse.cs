namespace FinalProj.Web.Models.Responses
{
    public class VentaListResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<VentaViewResult> data { get; set; }
    }
    public class VentaViewResult
    {
        public int id { get; set; }
        public int? idUsuario { get; set; }
        public int? idTipoDocumentoVenta { get; set; }
        public string? DocumentoCliente { get; set; }
        public string? NombreCliente { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ImpuestoTotal { get; set; }
        public decimal? Total { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}