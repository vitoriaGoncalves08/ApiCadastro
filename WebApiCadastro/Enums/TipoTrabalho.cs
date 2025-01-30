using System.Text.Json.Serialization;

namespace WebApiCadastro.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoTrabalho
    {
        HOME,
        HÍBRIDO,
        PRESENCIAL
    }
}
