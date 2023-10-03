using System;
namespace FinalProj.Domain.Core
{
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            this.FechaRegistro = DateTime.Now;
            this.FechaMod = DateTime.Now;
            this.FechaElimino = DateTime.Now;
            this.Eliminado = false;
        }

        public DateTime FechaRegistro { get; set; }
        public int idUsuarioCreacion { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? idUsuarioMod { get; set; }
        public int? idUsuarioElimino { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool Eliminado { get; set; }

    }
}
