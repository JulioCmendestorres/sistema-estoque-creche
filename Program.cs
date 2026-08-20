using ESTOQUE_CRECHE.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração do Banco de Dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Avisa ao projeto para ler a sua pasta "Controllers"
builder.Services.AddControllers();

// 3. Configurações para gerar a tela visual do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Ativa o Swagger apenas quando estiver programando (Ambiente de Desenvolvimento)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // Comentado para tirar aquele aviso amarelo do terminal

app.UseAuthorization();

// 5. Mapeia as rotas dos seus Controllers (como o UsuariosController)
app.MapControllers();

app.Run();