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
