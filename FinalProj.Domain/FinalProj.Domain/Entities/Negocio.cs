using FinalProj.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Domain.Entities
{
    public  class Negocio : BaseEntity
    {
        public int Id { get; set; }
        public string? UrlLogo { get; set; }
        public string? NombreLogo { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public  new string? FechaRegistro { get; set; }
        public string? Telefono { get; set; }
        public decimal? PorcentajeImpuesto { get; set; }
        public string? SimboloMoneda { get; set; }
    }
}
