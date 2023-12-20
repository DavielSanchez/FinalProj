namespace FinalProj.Web.Models.Response
{
    public class ProductoDetailResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public ProductoViewResult data { get; set; }
    }
}
