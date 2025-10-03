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

## Adicionar projeto de teste

# Criar diretório do projeto
mkdir MeuProjetoTeste
cd MeuProjetoTeste

# Criar solution
dotnet new sln

# Criar projeto de aplicação
dotnet new console -n MeuProjeto

# Criar projeto de teste (xUnit - recomendado)
dotnet new xunit -n MeuProjeto.Tests

# Ou criar projeto de teste com MSTest
dotnet new mstest -n MeuProjeto.Tests

# Adicionar projetos à solution
dotnet sln add MeuProjeto/MeuProjeto.csproj
dotnet sln add MeuProjeto.Tests/MeuProjeto.Tests.csproj

# Navegar para o projeto de teste
cd MeuProjeto.Tests

# Adicionar referência ao projeto principal
dotnet add reference ../MeuProjeto/MeuProjeto.csproj