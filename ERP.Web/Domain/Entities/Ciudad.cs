using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Web.Domain.Entities;
[Table("Ciudades")]
public class Ciudad
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;

    internal static Ciudad Create(string nombre)
    => new() { Nombre = nombre };
}
