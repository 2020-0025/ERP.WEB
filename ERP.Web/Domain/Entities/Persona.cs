using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Web.Domain.Entities;

[Table("Personas")]
public class Persona
{
    [Key]
    public int Id { get; set; }
    public int? CiudadId { get; set; }
    public string Nombre { get; set; } = null!;
    public DateTime? FechaDeNacimiento { get; set; }

    [ForeignKey(nameof(CiudadId))]
    public virtual Ciudad? Ciudad { get; set; }

    public static Persona Create(
        string nombre,
        DateTime? fechaNacimiento,
        int? ciudadId = null)
        => new()
        {
            Nombre = nombre,
            FechaDeNacimiento = fechaNacimiento,
            CiudadId = ciudadId
        };


}
