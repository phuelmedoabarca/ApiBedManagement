using Domain.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnidadController : ControllerBase
    {
        private readonly IUnidadRepository _repository;
        public UnidadController(IUnidadRepository repository)
        {
            _repository = repository;
        }
        [HttpGet()]
        public async Task<ActionResult> GetUnidades()
        {
            var response = await _repository.GetListUnidad();
            return Ok(response);
        }
    }
}
