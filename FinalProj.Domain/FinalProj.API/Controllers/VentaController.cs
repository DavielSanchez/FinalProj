using FinalProj.API.Models.Modules.Venta;
using FinalProj.Domain.Entities;
using FinalProj.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProj.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaRepository ventaRepository;

        public VentaController(IVentaRepository ventaRepository)
        {
            this.ventaRepository = ventaRepository;
        }

        [HttpGet("GetVentas")]
        public IActionResult Get()
        {
            var ventas = this.ventaRepository.GetEntities().
                                              Select(vt => new GetVentaModel()
                                              {
                                                  idUsuario = vt.idUsuario,
                                                  idTipoDocumentoVenta = vt.idTipoDocumentoVenta,
                                                  DocumentoCliente = vt.DocumentoCliente,
                                                  NombreCliente = vt.NombreCliente,
                                                  SubTotal = vt.SubTotal,
                                                  ImpuestoTotal = vt.ImpuestoTotal,
                                                  Total = vt.Total

                                              });

            return Ok(ventas);
        }


        [HttpGet("GetVenta")]
        public IActionResult Get(int id)
        {
            var venta = this.ventaRepository.GetEntity(id);

            GetVentaModel ventaModel = new GetVentaModel()
            {
                idTipoDocumentoVenta = venta.idTipoDocumentoVenta,
                DocumentoCliente = venta.DocumentoCliente,
                NombreCliente = venta.NombreCliente,
                SubTotal = venta.SubTotal,
                ImpuestoTotal = venta.ImpuestoTotal,
                Total = venta.Total
            };

            return Ok(venta);
        }

        [HttpPost("SaveVenta")]
        public IActionResult Post([FromBody] VentaAppModel ventaApp)
        {

            this.ventaRepository.Save(new Venta()
            {
                FechaRegistro = ventaApp.ChanageDate,
                idUsuarioCreacion = ventaApp.ChangeUser,
                numeroVenta = ventaApp.numeroVenta,
                idUsuario = ventaApp.idUsuario,
                idTipoDocumentoVenta = ventaApp.idTipoDocumentoVenta,
                DocumentoCliente = ventaApp.DocumentoCliente,
                NombreCliente = ventaApp.NombreCliente,
                SubTotal = ventaApp.SubTotal,
                ImpuestoTotal = ventaApp.ImpuestoTotal,
                Total = ventaApp.Total,

            });

            

            return Ok();
        }

        [HttpPost("UpdateVenta")]
        public IActionResult Put([FromBody] VentaUpdateModel ventaUpdate)
        {

            this.ventaRepository.Update(new Venta()
            {

                FechaMod = ventaUpdate.ChanageDate,
                idUsuarioMod = ventaUpdate.ChangeUser,
                numeroVenta = ventaUpdate.numeroVenta,
                idUsuario = ventaUpdate.idUsuario,
                idTipoDocumentoVenta = ventaUpdate.idTipoDocumentoVenta,
                DocumentoCliente = ventaUpdate.DocumentoCliente,
                NombreCliente = ventaUpdate.NombreCliente,
                SubTotal = ventaUpdate.SubTotal,
                ImpuestoTotal = ventaUpdate.ImpuestoTotal,
                Total = ventaUpdate.Total,
                id = ventaUpdate.id



            });            

            return Ok();
        }


    }
}
