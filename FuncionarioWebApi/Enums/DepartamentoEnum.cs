using System.Text.Json.Serialization;

namespace FuncionarioWebApi.Enums
{
    //pra converter o numero que vem do banco em texto 
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum //mude de classe para enum (um enum é um enumerador que troca numeros por palavras correspondente)
    {//É UMA LISTA DE OPÇOES 
        RH,
        FINANCEIRO,
        COMPRAS,
        ATENDIMENTO,
        ZELADORIA


    }
}
