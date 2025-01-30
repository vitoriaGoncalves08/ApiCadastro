using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCadastro.Models;
using WebApiCadastro.Services.UsuarioService;

namespace WebApiCadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;

        public UsuarioController(IUsuarioInterface usuarioInterface) {
            _usuarioInterface = usuarioInterface;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<UsuarioModel>>>> CreateUsuario(UsuarioModel novoUsuario)
        {
            return Ok(await _usuarioInterface.CreateUsuario(novoUsuario));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<UsuarioModel>>>> GetUsuarios()
        {
            return Ok(await _usuarioInterface.GetUsuarios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<UsuarioModel>>> GetUsuarioById(int id)
        {
            ServiceResponse<UsuarioModel> serviceResponse = await _usuarioInterface.GetUsuarioById(id);

            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<UsuarioModel>>>> UpdateUsuario(UsuarioModel editadoUsuario)
        {
            ServiceResponse<List<UsuarioModel>> serviceResponse = await _usuarioInterface.UpdateUsuario(editadoUsuario);

            return Ok(serviceResponse);
        }

    }
}
