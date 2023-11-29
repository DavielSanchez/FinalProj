namespace FinalProj.Web.Models.Responses
{
    public class VentaDetailResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public VentaViewResult data { get; set; }
    }
}