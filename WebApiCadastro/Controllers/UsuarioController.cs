using Azure;
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
            var response = await _usuarioInterface.CreateUsuario(novoUsuario);
            if (!response.Sucesso)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<UsuarioModel>>>> GetUsuarios()
        {
            var response = await _usuarioInterface.GetUsuarios();

            if (!response.Sucesso || response.Dados == null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<UsuarioModel>>> GetUsuarioById(int id)
        {
            ServiceResponse<UsuarioModel> serviceResponse = await _usuarioInterface.GetUsuarioById(id);

            if (!serviceResponse.Sucesso || serviceResponse.Dados == null)
                return NotFound(serviceResponse);

            return Ok(serviceResponse);
        }

        [HttpPut("inativaUsuario")]
        public async Task<ActionResult<ServiceResponse<List<UsuarioModel>>>> InativaUsuario(int id)
        {
            ServiceResponse<List<UsuarioModel>> serviceResponse = await _usuarioInterface.InativaUsuario(id);

            if (!serviceResponse.Sucesso || serviceResponse.Dados == null)
                return NotFound(serviceResponse);

            return Ok(serviceResponse);

        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<UsuarioModel>>>> UpdateUsuario(UsuarioModel editadoUsuario)
        {
            ServiceResponse<List<UsuarioModel>> serviceResponse = await _usuarioInterface.UpdateUsuario(editadoUsuario);

            if (!serviceResponse.Sucesso)
                return BadRequest(serviceResponse);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<UsuarioModel>>>> DeleteUsuario(int id)
        {
            ServiceResponse<List<UsuarioModel>> serviceResponse = await _usuarioInterface.DeleteUsuario(id);

            if (!serviceResponse.Sucesso)
                return NotFound(serviceResponse);

            return Ok(serviceResponse);
        }
    }
}
