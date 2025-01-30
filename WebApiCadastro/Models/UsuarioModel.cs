using System.ComponentModel.DataAnnotations;
using WebApiCadastro.Enums;

namespace WebApiCadastro.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public Departamento Departamento { get; set; }

        public TipoTrabalho TipoTrabalho { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now.ToLocalTime();

        public DateTime DataAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
