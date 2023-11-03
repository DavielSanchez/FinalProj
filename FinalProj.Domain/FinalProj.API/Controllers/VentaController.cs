using FinalProj.API.Models.Modules.Venta;
using FinalProj.Application.Contracts;
using FinalProj.Application.DTO_s.Venta;
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
        private readonly IVentaService ventaService;

        public VentaController(IVentaService ventaService)
        {
            this.ventaService = ventaService;
        }

        [HttpGet("GetVentas")]
        public IActionResult GetVentas()
        {
            var result = this.ventaService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("GetVenta")]
        public IActionResult GetVenta(int id)
        {
            var result = this.ventaService.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("SaveVenta")]
        public IActionResult Post([FromBody] VentaDTOAdd ventaAdd)
        {
            var result = this.ventaService.Save(ventaAdd);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("UpdateVenta")]
        public IActionResult Put([FromBody] VentaDTOUpdate ventaUpdate)
        {

            var result = this.ventaService.Update(ventaUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpPost("RemoveVenta")]
        public IActionResult Remove([FromBody] VentaDTORemove ventaRemove)
        {
            var result = this.ventaService.Remove(ventaRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


    }
}
