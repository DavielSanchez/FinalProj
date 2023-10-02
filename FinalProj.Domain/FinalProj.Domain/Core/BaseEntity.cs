using System;
namespace FinalProj.Domain.Core
{
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            this.FechaRegistro = DateTime.Now;
            this.FechaModificacion = DateTime.Now;
            this.FechaElimino = DateTime.Now;
            this.Elimino = false;
        }

        public DateTime FechaRegistro { get; set; }
        public int idUsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? idUsuarioModifico { get; set; }
        public int? idUsuarioElimino { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool Elimino { get; set; }

    }
}
