using pro;
using pro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// base de datos en memoria
// builder.Services.AddDbContext<TareasContext>(p=> p.UseInMemoryDatabase("TareasDB"));

// base de datos con sql server
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbConexion) =>
{
    dbConexion.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbConexion.Database.IsInMemory());
});

app.MapGet("/api/tareas", ([FromServices] TareasContext dbConexion) =>
{
    return Results.Ok(dbConexion.Tareas.Include(p=> p.Categorias).Where(p=> p.PrioridadTarea == pro.Models.Prioridad.Alta));
});

app.Run();
