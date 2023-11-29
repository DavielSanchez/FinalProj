using FinalProj.Domain.Entities;
using FinalProj.Domain.Repository;
using FinalProj.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FinalProj.Infrastructure.Interfaces
{
    public interface IVentaRepository : IBaseRepository<Venta>
    {
        List<Venta> GetVentasByCliente (string Cliente);
        List<VentaDocTypeModel> GetVentasDocTypes();
        List<VentaDocTypeModel> GetVentasByDocTypesId(int doctypeId);

        VentaDocTypeModel GetVentaDocTypeById(int id);

    }
}

