using System.Text.Json.Serialization;

namespace FuncionarioWebApi.Enums
{
    //pra converter o numero que vem do banco em texto 
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnoEnum
    {
        MANHÃ,
        TARDE,
        NOITE
    }
}
