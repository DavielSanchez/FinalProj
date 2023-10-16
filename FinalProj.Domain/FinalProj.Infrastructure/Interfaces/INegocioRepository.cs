using FinalProj.Domain.Entities;
using FinalProj.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FinalProj.Infrastructure.Interfaces
{
    public interface IVentaRepository : IRepositoryBase<Negocio>
    {
        // Aqui van los metodos exclusivos de la entidad Negocio.
        List<Negocio> GetNegocioByIDUsuario(int idUsuario);
        List<Negocio> GetNegocioByCategoria(int idCategoria);
        bool Exists(Expression<Func<Negocio, bool>> filter);

    }

}