using Domain.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComunaController : ControllerBase
    {
        private readonly IComunaRepository _repository;
        public ComunaController(IComunaRepository repository)
        {
            _repository = repository;
        }
        [HttpGet()]
        public async Task<ActionResult> GetComunas()
        {
            var response = await _repository.GetListComuna();
            return Ok(response);
        }
    }
}
