using FinalProj.Web.Contracts;
using FinalProj.Web.Models.Response;
using System.Text;

namespace FinalProj.Web.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient httpClient;
        private const string BaseApiUrl = "http://localhost:5240/api/Producto/";
        public ApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ProductoListResponse> GetProductos()
        {
            var apiUrl = $"{BaseApiUrl}GetProductos";
            var apiResponse = await httpClient.GetStringAsync(apiUrl);

            return JsonConvert.DeserializeObject<ProductoListResponse>(apiResponse);
        }

        public async Task<ProductoDetailResponse> GetProducto(int id)
        {
            var apiUrl = $"{BaseApiUrl}GetProducto?id={id}";
            var apiResponse = await httpClient.GetStringAsync(apiUrl);

            return JsonConvert.DeserializeObject<ProductoDetailResponse>(apiResponse);
        }

        public async Task<BaseResponse> SaveProducto(ProductoDTOAdd productoDTOAdd)
        {
            var apiUrl = $"{BaseApiUrl}SaveProducto";

            productoDTOAdd.ChangeDate = DateTime.Now;
            productoDTOAdd.ChangeUser = 1;

            var content = JsonConvert.SerializeObject(productoDTOAdd);

            var response = await httpClient.PostAsync(apiUrl, new StringContent(content, Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<BaseResponse>(responseContent);
        }

        public async Task<BaseResponse> UpdateProducto(ProductoDTOUpdate productoDTOUpdate)
        {
            var apiUrl = $"{BaseApiUrl}UpdateProducto";

            productoDTOUpdate.ChangeDate = DateTime.Now;
            productoDTOUpdate.ChangeUser = 1;

            var content = JsonConvert.SerializeObject(productoDTOUpdate);

            var response = await httpClient.PostAsync(apiUrl, new StringContent(content, Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<BaseResponse>(responseContent);
        }
    }
}
