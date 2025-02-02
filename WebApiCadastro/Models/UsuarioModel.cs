using System.ComponentModel.DataAnnotations;
using WebApiCadastro.Enums;

namespace WebApiCadastro.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Informe seu Nome")]
        [StringLength(80, ErrorMessage = "O nome deve conter até 80 caracteres")]
        [MinLength(2, ErrorMessage = "O nome deve conter pelo menos 2 caracteres")]
        public string Nome { get; set; }

        [EnumDataType(typeof(Departamento), ErrorMessage = "Valor de departamento inválido.")]
        public Departamento Departamento { get; set; }

        [EnumDataType(typeof(TipoTrabalho), ErrorMessage = "Valor de tipo de trabalho inválido.")]
        public TipoTrabalho TipoTrabalho { get; set; }

        public bool Ativo { get; set; } = true;

        public DateTime DataCadastro { get; set; } = DateTime.Now.ToLocalTime();

        public DateTime DataAlteracao { get; set; } = DateTime.Now.ToLocalTime();

        [Required(ErrorMessage = "Informe seu E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
    }
}
