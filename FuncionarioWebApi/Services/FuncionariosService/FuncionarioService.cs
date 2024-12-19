using FuncionarioWebApi.Data;
using FuncionarioWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FuncionarioWebApi.Services.FuncionariosService
{
    //O service respeita e implemente os metodos que vem da interface(contrato)
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly AppDbContext _context;
        public FuncionarioService(AppDbContext context)//injeção de dependecia do context banco de dados 
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> AtualizarFuncionario(FuncionarioModel funcionarioEditado)
        {
            ServiceResponse<List<FuncionarioModel>> resposta = new();
            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == funcionarioEditado.Id);
                if (funcionario == null)
                {
                    resposta.Dados = null;
                    resposta.Mensagem = "Funcionario não encontrado ";
                    resposta.Sucesso = false;

                }
                
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionarioEditado);
                await _context.SaveChangesAsync();

                resposta.Dados = _context.Funcionarios.ToList();


            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Sucesso = false;
            }
            return resposta;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> CriarFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> resposta = new();
            try
            {
                if (novoFuncionario == null)
                {

                    resposta.Mensagem = "informar daods";
                    resposta.Dados = null;
                    resposta.Sucesso = false;
                    return resposta;
                }
                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();

                resposta.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Sucesso = false;
            }

            return resposta;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> ExcluirFuncionario(int id)
        {

            ServiceResponse<List<FuncionarioModel>> resposta = new();
            try
            {


                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);


                if (funcionario == null)
                {
                    resposta.Dados = null;
                    resposta.Mensagem = "Funcionario não encontrado ";
                    resposta.Sucesso = false;

                }
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
                resposta.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Sucesso = false;
            }
            return resposta;

        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> resposta = new();
            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x=>x.Id ==id);
                if (funcionario == null)
                {
                    resposta.Dados = null;
                    resposta.Mensagem = "Funcionario não encontrado ";
                    resposta.Sucesso = false;
                                   
                }
                funcionario.Ativo = false;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();
                
                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync ();

                resposta.Dados = _context.Funcionarios.ToList();

              
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Sucesso = false;
            }
            return resposta;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> listarFuncionarios()
        {
            ServiceResponse<List<FuncionarioModel>> resposta = new();
            try
            {
                resposta.Dados = _context.Funcionarios.ToList();
                if (resposta.Dados.Count == 0)
                {
                    resposta.Mensagem = "Nenhum registro encontrado";
                }

            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Sucesso = false;
            }

            return resposta;

        }

        public async Task<ServiceResponse<FuncionarioModel>> ListarPorID(int id)
        {
            ServiceResponse<FuncionarioModel> resposta = new();
            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (funcionario == null)
                {
                    resposta.Dados = null;
                    resposta.Mensagem = "Funcionario não localizado ";
                    resposta.Sucesso = false;
                }
                resposta.Dados = funcionario;

            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Sucesso = false;
            }

            return resposta;

        }
    }
    }

