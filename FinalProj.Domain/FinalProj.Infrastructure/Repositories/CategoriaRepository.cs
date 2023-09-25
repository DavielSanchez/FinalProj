using FinalProj.Domain.Entities;
using FinalProj.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public List<Categoria> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Categoria GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Categoria> GetCategoriasByDescripcion(string descripcion)
        {

            throw new NotImplementedException();
        }

        public List<Categoria> GetCategoriasByEstado(bool esActivo)
        {

            throw new NotImplementedException();
        }

        public List<Categoria> GetCategoriasByFechaRegistro(DateTime fechaRegistro)
        {

            throw new NotImplementedException();
        }


        public List<Categoria> GetCategoriasByProductoId(int idProducto)
        {

            throw new NotImplementedException();
        }


        public void Remove(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Categoria entity)
        {
            throw new NotImplementedException();
        }
    }
}
