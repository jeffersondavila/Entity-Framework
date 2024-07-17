using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pro;

var builder = WebApplication.CreateBuilder(args);

// base de datos en memoria
// builder.Services.AddDbContext<TareasContext>(p=> p.UseInMemoryDatabase("TareasDB"));

// base de datos con sql server
builder.Services.AddSqlServer<TareasContext>("Data Source=LAPTOP-07NSNMOC;Initial Catalog=TareasDb;user id=sa;password=loc@del@rea;TrustServerCertificate=True");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbConexion) =>
{
    dbConexion.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbConexion.Database.IsInMemory());
});

app.Run();
