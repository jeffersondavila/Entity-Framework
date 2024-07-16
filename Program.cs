using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pro;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TareasContext>(p=> p.UseInMemoryDatabase("TareasDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbConexion) =>
{
    dbConexion.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria" + dbConexion.Database.IsInMemory());
});

app.Run();
