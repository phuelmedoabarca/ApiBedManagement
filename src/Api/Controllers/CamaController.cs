using Domain.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CamaController : ControllerBase
    {
        private readonly ICamaRepository _repository;
        public CamaController(ICamaRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("salaId")]
        public async Task<ActionResult> GetCamas(int salaId)
        {
            var response = await _repository.GetListBySala(salaId);
            return Ok(response);
        }
        [HttpGet("unidadId")]
        public async Task<ActionResult> GetCamasByUnidad(int unidadId)
        {
            var response = await _repository.GetCountCamasByUnidad(unidadId);
            return Ok(response);
        }
    }
}
