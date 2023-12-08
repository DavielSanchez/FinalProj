using FinalProj.Application.Contracts;
using FinalProj.Application.Core;
using FinalProj.Application.DTO_s.Venta;
using FinalProj.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

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
            ServiceResult result = new ServiceResult();

            try
            {
                result = ventaService.Save(ventaAdd);

                if (!result.Success)
                    return BadRequest(result);

            }
            catch (VentaServiceException vsex)
            {

                result.Message = vsex.Message;
                result.Success = false;
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
