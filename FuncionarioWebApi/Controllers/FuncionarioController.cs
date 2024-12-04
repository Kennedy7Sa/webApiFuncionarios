using FuncionarioWebApi.Models;
using FuncionarioWebApi.Services.FuncionariosService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace FuncionarioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _ifuncionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)

        {
            _ifuncionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> listarFuncionarios()
        {
            return Ok(await _ifuncionarioInterface.listarFuncionarios());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> ListarPorID(int id)
        {
            ServiceResponse<FuncionarioModel> resposta = await _ifuncionarioInterface.ListarPorID(id);
            return Ok(resposta);
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CriarFuncionario(FuncionarioModel novoFuncionario)
        {
            return Ok(await _ifuncionarioInterface.CriarFuncionario(novoFuncionario));
        }


        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> AtualizarFuncionario(FuncionarioModel funcionarioEditado)
        {
            ServiceResponse<List<FuncionarioModel>> resposta = await _ifuncionarioInterface.AtualizarFuncionario(funcionarioEditado);
            return Ok(resposta);
        }

        [HttpPut("inativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> resposta = await _ifuncionarioInterface.InativaFuncionario(id);
            return Ok(resposta);
        }
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> ExcluirFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> resposta = await _ifuncionarioInterface.ExcluirFuncionario(id);
            return Ok(resposta);
        }
        

    }
}
