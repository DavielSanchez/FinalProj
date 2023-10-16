using FinalProj.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FinalProj.Domain.Repository
{
    public interface INegocioRepository
    {
        void Save(Negocio negocio);
        void Update(Negocio negocio);
        void Remove(Negocio negocio);
        List<Negocio> GetNegocio();
        Negocio GetNegocio(int Id);
        bool Exists(Expression<Func<Negocio, bool>> filter);

    }


}
