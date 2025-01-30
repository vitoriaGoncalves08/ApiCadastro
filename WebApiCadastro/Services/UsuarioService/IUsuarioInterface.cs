using WebApiCadastro.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiCadastro.Services.UsuarioService
{
    public interface IUsuarioInterface
    {
        /// Utilizando Task para ser assincrono, para que espere realizar a requisição do banco para seguir com a execução do código
         /// <summary>
         /// Obtém a lista de todos os usuários cadastrados.
         /// </summary>
         /// <returns>
         /// Retorna um <see cref="ServiceResponse{T}"/> contendo uma lista de <see cref="UsuarioModel"/>.
         /// </returns>
         Task<ServiceResponse<List<UsuarioModel>>> GetUsuarios();

        /// <summary>
        /// Cria um novo usuário no banco de dados.
        /// </summary>
        /// <param name="novoUsuario">Objeto contendo os dados do novo usuário a ser criado.</param>
        /// <returns>
        /// Retorna um <see cref="ServiceResponse{T}"/> com a lista atualizada de <see cref="UsuarioModel"/> após a inserção.
        /// </returns>
        Task<ServiceResponse<List<UsuarioModel>>> CreateUsuario(UsuarioModel novoUsuario);

        /// <summary>
        /// Obtém um usuário específico pelo seu identificador (ID).
        /// </summary>
        /// <param name="id">Identificador único do usuário.</param>
        /// <returns>
        /// Retorna um <see cref="ServiceResponse{T}"/> contendo o <see cref="UsuarioModel"/> correspondente ao <paramref name="id"/>.
        /// </returns>
        Task<ServiceResponse<UsuarioModel>> GetUsuarioById(int id);

        /// <summary>
        /// Atualiza as informações de um usuário existente.
        /// </summary>
        /// <param name="editadoUsuario">Objeto <see cref="UsuarioModel"/> com os dados atualizados do usuário.</param>
        /// <returns>
        /// Retorna um <see cref="ServiceResponse{T}"/> contendo a lista atualizada de <see cref="UsuarioModel"/> após a edição.
        /// </returns>
        Task<ServiceResponse<List<UsuarioModel>>> UpdateUsuario(UsuarioModel editadoUsuario);

        /// <summary>
        /// Exclui um usuário do sistema de forma permanente com base no ID informado.
        /// </summary>
        /// <param name="id">Identificador único do usuário a ser excluído.</param>
        /// <returns>
        /// Retorna um <see cref="ServiceResponse{T}"/> contendo a lista atualizada de <see cref="UsuarioModel"/>, 
        /// sem o registro excluído.
        /// </returns>
        Task<ServiceResponse<List<UsuarioModel>>> DeleteUsuario(int id);

        /// <summary>
        /// Inativa um usuário (ao invés de excluir permanentemente), 
        /// tornando-o indisponível para determinadas operações.
        /// </summary>
        /// <param name="id">Identificador único do usuário a ser inativado.</param>
        /// <returns>
        /// Retorna um <see cref="ServiceResponse{T}"/> com a lista de <see cref="UsuarioModel"/> 
        /// após a inativação do usuário.
        /// </returns>
        Task<ServiceResponse<List<UsuarioModel>>> InativaUsuario(int id);
    }
}
