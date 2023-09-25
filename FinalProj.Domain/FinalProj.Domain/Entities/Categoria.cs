using FinalProj.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Domain.Entities
{
    public class Categoria : BaseEntity
    {

        public int Id { get; set; }
        public String? Descripcion { get; set; }
        public bool? EsActivo { get; set; }

    }
}
