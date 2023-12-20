using FinalProj.Application.Contracts;
using FinalProj.Application.Core;
using FinalProj.Application.DTO_s.Producto;
using FinalProj.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FinalProj.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService productoService;

        public ProductoController(IProductoService productoService)
        {
            this.productoService = productoService;
        }

        [HttpGet("GetProductos")]
        public IActionResult GetProductos()
        {
            var result = this.productoService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("GetProducto")]
        public IActionResult GetProducto(int Id)
        {
            var result = this.productoService.GetProducto(Id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("GetProductoByMarca")]
        public IActionResult GetProductoByMarca(int Id, string Marca)
        {
            var result = this.productoService.GetProductoByMarca(Id, Marca);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("SaveProducto")]
        public IActionResult Post([FromBody] ProductoDTOAdd productoAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = productoService.Save(productoAdd);

                if (!result.Success)
                    return BadRequest(result);

            }
            catch (ProductoServiceException vsex)
            {

                result.Message = vsex.Message;
                result.Success = false;
            }

            return Ok(result);
        }

        [HttpPost("UpdateProducto")]
        public IActionResult Put([FromBody] ProductoDTOUpdate productoUpdate)
        {

            var result = this.productoService.Update(productoUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpPost("RemoveProducto")]
        public IActionResult Remove([FromBody] ProductoDTORemove productoRemove)
        {
            var result = this.productoService.Remove(productoRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


    }
}
