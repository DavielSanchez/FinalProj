using FinalProj.Application.DTO_s.Base;
using System;

namespace FinalProj.Application.DTO_s.Venta
{
    public class VentaDTORemove : DTOBase
    {
        public int id { get; set; }
        public bool Eliminado { get; set; }

    }
}
