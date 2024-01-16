using LojaAPI.Data;
using LojaAPI.Entities;
using LojaAPI.Repository.Interfaces;
using LojaAPI.Repository.Repos;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AplicacaoDbContext>(opts => opts.
    UseMySql(builder.Configuration.GetConnectionString("LojaConexao"),
    ServerVersion.AutoDetect(builder.Configuration.
    GetConnectionString("LojaConexao"))));

builder.Services.AddScoped<ICategoriaRepository,CategoriaRepository>();

builder.Services.AddScoped<IProdutoRepository,ProdutoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
