using FuncionarioWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FuncionarioWebApi.Data
{
    public class AppDbContext : DbContext
    {//aqui eu especifico as tabelas que serão criadas no banco de dados 
        /* "ConnectionStrings": {
      "ConnectionMysql": "Server=localhost;Port=3306;initial catalog=WebApiLivros;uid=root;pwd=master579"

    }*/


        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
            
        }

        #region "F"
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        #endregion


    }
}
