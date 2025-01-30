namespace WebApiCadastro.Models
{
    public class ServiceResponse<T> //recebe dados genéricos de qualquer model
    {
        public T? Dados { get; set; }

        public String Mensagem { get; set; } = string.Empty;

        public bool Sucesso { get; set; } = true;
    }
}
