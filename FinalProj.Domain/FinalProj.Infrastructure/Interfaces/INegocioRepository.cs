using FinalProj.Domain.Entities;
using FinalProj.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FinalProj.Infrastructure.Interfaces
{
    public interface INegocioRepository : IRepositoryBase<Negocio>
    {
        List<Negocio> GetNegociosByUsuario(int idUsuario);
        List<Negocio> GetStockbyNegocio(int stock, int IdNegocio);
        List<Negocio> GeturLImageByNegocio(string urlImama, int IdNegocio);
        List<Negocio> GetEsActivoByNegocio(int idNegocio, bool EsActivo);
        List<Negocio> GetCategoriabyNegocio(int Negocio);




    }
