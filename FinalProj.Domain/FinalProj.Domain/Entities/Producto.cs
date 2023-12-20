using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Domain.Entities
{
    public class Producto
    {
        public int? Id { get; set; }
        public string? CodigoBarra { get; set; }
        public string? Marca { get; set; }
        public string? Descripcion { get; set; }
        public int? IdCategoria { get; set; }
        public int? Stock { get; set; }
        public string? UrlImagen { get; set; }
        public string NombreImagen { get; set; }
        public decimal? Precio { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? IdUsuarioCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
        public DateTime FechaElimino { get; set; }
        public int? IdUsuarioElimino { get; set; }
        public bool? Eliminado { get; set; }
    }
}
