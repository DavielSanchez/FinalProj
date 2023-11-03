using FinalProj.Domain.Entities;
using FinalProj.Domain.Repository;
using FinalProj.Infrastructure.Context;
using FinalProj.Infrastructure.Core;
using FinalProj.Infrastructure.Interfaces;
using FinalProj.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinalProj.Infrastructure.Repositories
{
    public class TipoDocumentoVentaRepository : BaseRepository<TipoDocumentoVenta>, ITipoDocumentoVentaRepository
    {
        private readonly SalesContext context;

        public TipoDocumentoVentaRepository(SalesContext context) : base(context)
        {
            this.context = context;
        }


    }
}
