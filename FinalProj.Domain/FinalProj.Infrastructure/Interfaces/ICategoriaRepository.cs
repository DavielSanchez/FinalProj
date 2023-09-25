using FinalProj.Domain.Entities;
using FinalProj.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Infrastructure.Interfaces
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        //metodos exclusivos de la entidad Categoria
        List<Categoria> GetCategoriasByDescripcion(string descripcion);
        List<Categoria> GetCategoriasByEstado(bool esActivo);
        List<Categoria> GetCategoriasByFechaRegistro(DateTime fechaRegistro);
        List<Categoria> GetCategoriasByProductoId(int idProducto);

    }
}
