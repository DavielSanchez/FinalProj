using FinalProj.Application.DTO_s.Venta;
using FinalProj.Web.Models.Responses;

namespace FinalProj.Web.Contracts
{
    public interface IApiService
    {
        Task<VentaListResponse> GetVentas();
        Task<VentaDetailResponse> GetVenta(int id);
        Task<BaseResponse> SaveVenta(VentaDTOAdd ventaDTOAdd);
        Task<BaseResponse> UpdateVenta(VentaDTOUpdate ventaDTOUpdate);

    }
}
