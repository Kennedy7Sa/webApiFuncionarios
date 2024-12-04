using FuncionarioWebApi.Models;

namespace FuncionarioWebApi.Services.FuncionariosService
{
    public interface IFuncionarioInterface
    {
        Task<ServiceResponse<List<FuncionarioModel>>> listarFuncionarios();
        Task<ServiceResponse<List<FuncionarioModel>>> CriarFuncionario(FuncionarioModel novoFuncionario);

        Task<ServiceResponse<FuncionarioModel>> ListarPorID(int id);

        Task<ServiceResponse<List<FuncionarioModel>>> AtualizarFuncionario(FuncionarioModel funcionarioEditado);

        Task<ServiceResponse<List<FuncionarioModel>>> ExcluirFuncionario(int id);

        Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id);














    }














}
