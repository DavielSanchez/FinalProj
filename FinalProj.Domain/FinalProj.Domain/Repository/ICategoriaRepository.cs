using FinalProj.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace FinalProj.Domain.Repository
{
    public interface ICategoriaRepository 
    {
        void Save(Categoria categoria);

        void Update(Categoria categoria);
        void Remove(Categoria categoria);
        List<Categoria> GetCategorias();
        Categoria GetCategoria(int Id);

        bool Exists(Expression<Func<Categoria, bool>> filter);
    }
}
