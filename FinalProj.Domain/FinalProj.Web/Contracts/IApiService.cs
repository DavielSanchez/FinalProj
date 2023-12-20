using FinalProj.Web.Models.Response;

namespace FinalProj.Web.Contracts
{
    public interface IApiService
    {
        Task<ProductoListResponse> GetProductos();
        Task<ProductoDetailResponse> GetProducto(int id);
        Task<BaseResponse> SaveProducto(ProductoDTOAdd productoDTOAdd);
        Task<BaseResponse> UpdateVProducto(ProductoDTOUpdate productoDTOUpdate);
    }
}
