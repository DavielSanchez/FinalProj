using FinalProj.Domain.Entities;
using FinalProj.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Infrastructure.Repositories
{
    public class NegocioReposito : INegocioRepository
    {
        public List<Negocio> GetCategoriabyNegocio(int Negocio)
        {
            throw new NotImplementedException();
        }

        public List<Negocio> GetEntities()
        {
            throw new NotImplementedException();
          
        }

        public Negocio GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Negocio> GetEsActivoByNegocio(int idNegocio, bool EsActivo)
        {
            throw new NotImplementedException();
        }

        public List<Negocio> GetNegociosByUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public List<Negocio> GetStockbyNegocio(int stock, int IdNegocio)
        {
            throw new NotImplementedException();
        }

        public List<Negocio> GeturLImageByNegocio(string urlImama, int IdNegocio)
        {
            throw new NotImplementedException();
        }

        public void Remove(Negocio entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Negocio entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Negocio entity)
        {
            throw new NotImplementedException();
        }
    }
}
