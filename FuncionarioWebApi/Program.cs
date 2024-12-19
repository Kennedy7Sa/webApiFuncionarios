using FuncionarioWebApi.Data;
using FuncionarioWebApi.Services.FuncionariosService;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//politica de cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("funcionariosApp", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


//para a interface se comunicar com o  service 
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();


//chamando a string de conex�o mysql
var connectionStringMysql = builder.Configuration.GetConnectionString("ConnectionMysql");
builder.Services.AddDbContext<AppDbContext>(option => option.UseMySql(connectionStringMysql, ServerVersion.Parse("8.0.37")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("funcionariosApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
