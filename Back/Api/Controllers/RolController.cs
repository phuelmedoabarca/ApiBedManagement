using Domain.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IUsuarioRolRepository _repository;
        public RolController(IUsuarioRolRepository repository)
        {
            _repository = repository;
        }
        [HttpGet()]
        public async Task<ActionResult> GetRoles()
        {
            var response = await _repository.GetListRoles();
            return Ok(response);
        }
    }
}
