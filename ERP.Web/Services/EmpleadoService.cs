using ERP.Web.Data;
using ERP.Web.Domain.Dto;
using ERP.Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ERP.Web.Services
{
    public class EmpleadoService
    {
        private readonly AppDbContext _context;

        public EmpleadoService(AppDbContext context)
        {
            _context = context;
        }
        ///Consultar los Empleados existentes
        public async Task<List<EmpleadoDto>> Consultar(string filtro)
        {
            var empleados = await
                _context.Empleados
                .Include(c => c.DatosPersonales)
                .Where(c => c.DatosPersonales.Nombre.Contains(filtro))
                .Select(
                    c =>
                    new EmpleadoDto()
                    {
                        Id = c.Id,
                        PersonaId = c.PersonaId,
                        Sueldo = c.Sueldo,
                        DatosPersonales = new PersonaDto()
                        {
                            Id = c.DatosPersonales.Id,
                            Nombre = c.DatosPersonales.Nombre,
                            FechaDeNacimiento = c.DatosPersonales.FechaDeNacimiento
                        }
                    }
                )
                .ToListAsync();
            return empleados;
        }

    }
}
