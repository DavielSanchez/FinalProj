using FinalProj.Application.DTO_s.Producto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Application.Contracts
{
    internal interface IProductoService : IBaseService<ProductoDTOAdd, ProductoDTOUpdate, ProductoDTORemove>
    {

    }
}
