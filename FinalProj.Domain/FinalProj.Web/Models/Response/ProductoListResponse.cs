namespace FinalProj.Web.Models.Response
{
    public class ProductoListResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<ProductoViewResult> data { get; set; }
    }

    public class ProductoViewResult
    {
        public int? Id { get; set; }
        public string? CodigoBarra { get; set; }
        public string? Marca { get; set; }
        public string? Descripcion { get; set; }
        public int? IdCategoria { get; set; }
        public int? Stock { get; set; }
        public string? UrlImagen { get; set; }
        public string NombreImagen { get; set; }
        public decimal? Precio { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? IdUsuarioCreacion { get; set; }
    }
}
