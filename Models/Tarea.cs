namespace pro.Models;

public class Tarea
{
    public Guid CodigoTarea {get;set;}
    public Guid CodigoCategoria {get;set;}
    public string Titulo {get;set;}
    public string Descripcon {get;set;}
    public Prioridad PrioridadTarea {get;set;}
    public DateTime FechaCreacion {get;set;}
    public virtual Categoria Categorias {get;set;}
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}