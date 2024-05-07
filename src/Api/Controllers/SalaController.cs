using Domain.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaController : ControllerBase
    {
        private readonly ISalaRepository _repository;
        public SalaController(ISalaRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("unidadId")]
        public async Task<ActionResult> GetSalas(int unidadId)
        {
            var response = await _repository.GetListByUnidad(unidadId);
            return Ok(response);
        }
    }
}
