## Para adicionar SQLite

dotnet tool install --global dotnet-ef

dotnet add package Microsoft.EntityFrameworkCore.Sqlite


## Para adicionar Migrations

dotnet add package Microsoft.EntityFrameworkCore.Tools

dotnet ef migrations add InitialCreate

dotnet ef database update


## Para injetar SQLite

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db")


## Adicionar swagger

dotnet add package Swashbuckle.AspNetCore

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minha API",
        Version = "v1",
        Description = "Documentação da API com Swagger"
    });
});