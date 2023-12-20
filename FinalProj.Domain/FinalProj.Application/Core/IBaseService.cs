using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Application.Core
{
    public interface IBaseService<TDtoAdd, TDtoUpdate, TDtoRemove>
    {
        ServiceResult GetProductos();
        ServiceResult GetProducto(int Id);
        ServiceResult GetProductoByMarca(string Marca, int Id);
        ServiceResult Save(TDtoAdd dtoAdd);
        ServiceResult Update(TDtoUpdate dtoUpdate);
        ServiceResult Remove(TDtoRemove dtoRemove);
    }
}
