using FinalProj.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Domain.Entities
{
    public class TipoDocumentoVenta : BaseEntity
    {
        public int id { get; set; }
        public string? Descripcion { get; set; }
        public bool EsActivo { get; set; }
    }
}
