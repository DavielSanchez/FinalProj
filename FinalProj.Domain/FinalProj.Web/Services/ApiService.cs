// ApiService.cs
using FinalProj.Application.Contracts;
using FinalProj.Application.DTO_s.Venta;
using FinalProj.Web.Contracts;
using FinalProj.Web.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.Web.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient httpClient;
        private const string BaseApiUrl = "http://localhost:5240/api/Venta/";
        public ApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<VentaListResponse> GetVentas()
        {
            var apiUrl = $"{BaseApiUrl}GetVentas";
            var apiResponse = await httpClient.GetStringAsync(apiUrl);

            return JsonConvert.DeserializeObject<VentaListResponse>(apiResponse);
        }

        public async Task<VentaDetailResponse> GetVenta(int id)
        {
            var apiUrl = $"{BaseApiUrl}GetVenta?id={id}";
            var apiResponse = await httpClient.GetStringAsync(apiUrl);

            return JsonConvert.DeserializeObject<VentaDetailResponse>(apiResponse);
        }

        public async Task<BaseResponse> SaveVenta(VentaDTOAdd ventaDTOAdd)
        {
            var apiUrl = $"{BaseApiUrl}SaveVenta";

            ventaDTOAdd.ChangeDate = DateTime.Now;
            ventaDTOAdd.ChangeUser = 1;

            var content = JsonConvert.SerializeObject(ventaDTOAdd);

            var response = await httpClient.PostAsync(apiUrl, new StringContent(content, Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<BaseResponse>(responseContent);
        }

        public async Task<BaseResponse> UpdateVenta(VentaDTOUpdate ventaDTOUpdate)
        {
            var apiUrl = $"{BaseApiUrl}UpdateVenta";

            ventaDTOUpdate.ChangeDate = DateTime.Now;
            ventaDTOUpdate.ChangeUser = 1;

            var content = JsonConvert.SerializeObject(ventaDTOUpdate);

            var response = await httpClient.PostAsync(apiUrl, new StringContent(content, Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<BaseResponse>(responseContent);
        }
    }
}
