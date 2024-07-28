using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace pro.Models;

public class Categoria
{
    // [Key]
    public Guid CodigoCategoria {get;set;}
    // [Required]
    // [MaxLength(150)]
    public string Nombre {get;set;} = string.Empty;
    public string Descripcion {get;set;} = string.Empty;
    public int Peso {get;set;}
    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas {get;set;}
}