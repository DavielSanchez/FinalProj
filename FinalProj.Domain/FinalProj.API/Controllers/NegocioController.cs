using FinalProj.Domain.Entities;
using FinalProj.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FinalProj.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioController : ControllerBase
    {
        private readonly INegocioRepository negocioRepository;
        
        public NegocioController(INegocioRepository negocioRepository)
        {
            this.negocioRepository = negocioRepository;
        }

        // GET: api/<NegocioCotroller>
        [HttpGet]
        public IEnumerable<Negocio> Get()
        {
            var negocio = this.negocioRepository.GetNegocio();
            return negocio;

        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }




        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        [HttpPut("{id}")]
        public void Put([FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }



    }

}
