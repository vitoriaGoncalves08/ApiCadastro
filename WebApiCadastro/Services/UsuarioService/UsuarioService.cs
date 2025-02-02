using Microsoft.EntityFrameworkCore;
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

                var usuarioJaExiste = await _context.Usuario
                    .AnyAsync(u => u.Email.ToLower() == novoUsuario.Email.ToLower());

                if (usuarioJaExiste)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Já existe um usuário com este e-mail cadastrado!";
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
            ServiceResponse<List<UsuarioModel>> serviceResponse = new ServiceResponse<List<UsuarioModel>>();

            try
            {
                UsuarioModel usuarioModel = _context.Usuario.FirstOrDefault(usuarioModel => usuarioModel.Id == id);

                if (usuarioModel == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Usuario.Remove(usuarioModel);
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

        public async Task<ServiceResponse<UsuarioModel>> GetUsuarioById(int id)
        {
            ServiceResponse<UsuarioModel> serviceResponse = new ServiceResponse<UsuarioModel>();

            try
            {
                UsuarioModel usuarioModel = _context.Usuario.FirstOrDefault(usuarioModel => usuarioModel.Id == id);

                if (usuarioModel == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = usuarioModel;

            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<UsuarioModel>>> GetUsuarios()
        {
            var serviceResponse = new ServiceResponse<List<UsuarioModel>>();

            try
            {
                serviceResponse.Dados = await _context.Usuario
                    .Where(u => u.Ativo)
                    .ToListAsync();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum usuário ativo encontrado!";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    serviceResponse.Mensagem = "Usuários ativos listados com sucesso!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }


        public async Task<ServiceResponse<List<UsuarioModel>>> InativaUsuario(int id)
        {
            ServiceResponse<List<UsuarioModel>> serviceResponse = new ServiceResponse<List<UsuarioModel>>();

            try
            {
                UsuarioModel usuarioModel = _context.Usuario.FirstOrDefault(usuarioModel => usuarioModel.Id == id);

                if (usuarioModel == null)
                    throw new Exception("Usuário não localizado!");

                usuarioModel.Ativo = false;
                usuarioModel.DataCadastro = DateTime.Now.ToLocalTime();

                _context.Usuario.Update(usuarioModel);
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

        public async Task<ServiceResponse<List<UsuarioModel>>> UpdateUsuario(UsuarioModel editadoUsuario)
        {
            ServiceResponse<List<UsuarioModel>> serviceResponse = new ServiceResponse<List<UsuarioModel>>();

            try
            {
                UsuarioModel usuarioModel = _context.Usuario.AsNoTracking().FirstOrDefault(usuarioModel => usuarioModel.Id == editadoUsuario.Id);

                if (usuarioModel == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                usuarioModel.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Usuario.Update(editadoUsuario);
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
    }
}
