using WebApiCadastro.DataContext;
using WebApiCadastro.Models;

namespace WebApiCadastro.Services.UsuarioService
{
    public class UsuarioService : IUsuarioInterface
    {

        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<UsuarioModel>>> CreateUsuario(UsuarioModel novoUsuario)
        {
            ServiceResponse<List<UsuarioModel>> serviceResponse = new ServiceResponse<List<UsuarioModel>>();

            try
            {
                if (novoUsuario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Dados de usuário vazios!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                novoUsuario.DataCadastro = DateTime.Now.ToLocalTime();
                novoUsuario.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Add(novoUsuario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Usuario.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<UsuarioModel>>> DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<UsuarioModel>> GetUsuarioById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<UsuarioModel>>> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<UsuarioModel>>> InativaUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<UsuarioModel>>> UpdateUsuario(UsuarioModel editadoUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
