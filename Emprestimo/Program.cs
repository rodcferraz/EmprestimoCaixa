using EmprestimoCaixa;
using EmprestimoCaixa.Domain;
using EmprestimoCaixa.Filters;
using EmprestimoCaixa.Infraestrutura;
using EmprestimoCaixa.Infraestrutura.Data;
using EmprestimoCaixa.Infraestrutura.Interfaces;
using EmprestimoCaixa.Services;
using EmprestimoCaixa.Services.Interfaces;
using EmprestimoCaixa.Services.Interfaces.Juros;
using EmprestimoCaixa.Services.Juros;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minha API",
        Version = "v1",
        Description = "Documentação da API com Swagger"
    });
});

builder.Services.AddDbContext<EmprestimoCaixaDbContext>(options =>
    options.UseSqlite("Data Source=EmprestimoCaixa.db"));

// Cria instância do AppSettings manualmente a partir do ConfigurationRoot
var appSettings = new AppSettings(builder.Configuration);

// Registra como Singleton no DI
builder.Services.AddSingleton(appSettings);
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IProdutoService, ProdutoService>();
builder.Services.AddTransient<IEmprestimoService, EmprestimoService>();
builder.Services.AddTransient<IJurosService, JurosPriceService>();
builder.Services.AddTransient<IJurosFactory, JurosFactory>();
builder.Services.AddScoped<ValidarEmprestimoFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
