using Microsoft.EntityFrameworkCore;
using pro.Models;

namespace pro;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(categoria=>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CodigoCategoria);
            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.Descripcion);
            categoria.Property(p=> p.Peso);
        });

        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=> p.CodigoTarea);
            tarea.HasOne(p=> p.Categorias).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CodigoCategoria);
            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=> p.Descripcon);
            tarea.Property(p=> p.PrioridadTarea);
            tarea.Property(p=> p.FechaCreacion);
        });
    }
}