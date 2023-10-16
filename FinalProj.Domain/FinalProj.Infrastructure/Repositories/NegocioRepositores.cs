using FinalProj.Domain.Entities;
using FinalProj.Domain.Repository;
using FinalProj.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProj.Infrastructure.Repositories
{
    public class NegocioRepositores : INegocioRepository
    {
        private readonly SalesContext context;

        public NegocioRepositores(SalesContext context)
        {
            this.context = context;
        }

        public Negocio GetNegocio(int Id)
        {
            return this.context.Negocio.Find(Id);
        }

        public void Remove(Negocio negocio)
        {
            this.context.Negocio = negocio;
        }

        public void Save(Negocio negocio)
        {
            this.context.Negocio = negocio;
        }

        public void Update(Negocio negocio)
        {
            this.context.Negocio.Update(negocio);
        }
        public bool Exists(Expression<Func<Negocio, bool>> filter)
        {
            return this.context.Negocio.Any(filter);
        }

        public List<Negocio> GetNegocio()
        {
            return this.context.Negocio.Where(vt => !vt.Eliminado).Tolist();


        }

    
    }
}
