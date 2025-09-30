using EmprestimoCaixa.Infraestrutura;
using EmprestimoCaixa.Infraestrutura.Interfaces;
using EmprestimoCaixa.Services;
using EmprestimoCaixa.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IServiceProduto, ServiceProduto>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
