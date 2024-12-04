using System.Reflection.Metadata.Ecma335;

namespace FuncionarioWebApi.Models
{
    /// <summary>
    /// Classe para trabalhar a resposta da api 
    /// </summary>
    public class ServiceResponse<T> //dados genericos , pra usar em  outras classes com dados diferentes 
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty; // pra ja começar como string vazia 
            public bool Sucesso { get; set; } = true;//ja inicia verdadeiro

    }
}
