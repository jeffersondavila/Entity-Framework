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

app.MapGet("/dbconexion", ([FromServices] TareasContext dbConexion) =>
{
    dbConexion.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbConexion.Database.IsInMemory());
});

app.MapGet("/api/tareas", ([FromServices] TareasContext dbConexion) =>
{
    return Results.Ok(dbConexion.Tareas.Include(p=> p.Categorias));
    // return Results.Ok(dbConexion.Tareas.Include(p=> p.Categorias).Where(p=> p.PrioridadTarea == pro.Models.Prioridad.Alta));
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbConexion, [FromBody] Tarea tarea) =>
{
    tarea.CodigoTarea = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;

    await dbConexion.AddAsync(tarea);
    await dbConexion.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/tareas/{codigoTarea}", async ([FromServices] TareasContext dbConexion, [FromBody] Tarea tarea, [FromRoute] Guid codigoTarea) =>
{
    var tareaActual = dbConexion.Tareas.Find(codigoTarea);

    if(tareaActual != null)
    {
        tareaActual.CodigoCategoria = tarea.CodigoCategoria;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcon = tarea.Descripcon;

        await dbConexion.SaveChangesAsync();
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

app.Run();
