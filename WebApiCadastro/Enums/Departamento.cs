using System.Text.Json.Serialization;

namespace WebApiCadastro.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Departamento
    {
        RH,
        FINANCEIRO,
        VENDAS,
        TI,
        MARKETING,
        ATENDIMENTO
    }
}
