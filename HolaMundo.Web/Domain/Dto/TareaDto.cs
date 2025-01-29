using System.ComponentModel.DataAnnotations;

namespace HolaMundo.Web.Domain.Dto;

public class TareaDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre de la tarea es obligatorio")]
    public string Nombre { get; set; }
    public DateTime? Fecha { get; set; }
}
