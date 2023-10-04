using FinalProj.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FinalProj.Infrastructure.Context;
using FinalProj.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace FinalProj.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SalesContext context;

        public CategoriaRepository(SalesContext context)
        {
            this.context = context;
        }

        public void Save(Categoria categoria)
        {
            this.context.Categoria.Add(categoria);
        }

        public void Update(Categoria categoria)
        {
            this.context.Categoria.Update(categoria);
        }

        public void Remove(Categoria categoria)
        {
            this.context.Categoria.Remove(categoria);
        }

        public List<Categoria> GetCategorias()
        {
            return this.context.Categoria.Where(st => !st.Eliminado).ToList();
        }

        public Categoria GetCategoria(int Id)
        {
            return this.context.Categoria.Find(Id);
        }

        public bool Exists(Expression<Func<Categoria, bool>> filter)
        {
            return this.context.Categoria.Any(filter);
        }
    }
}
