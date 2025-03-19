using ERP.Web.Data;
using ERP.Web.Domain.Dto;
using Microsoft.EntityFrameworkCore;

namespace ERP.Web.Services;

public interface ICiudadService
{
    Task<List<CiudadDto>> Consultar();
}
public class CiudadService : ICiudadService
{
    private readonly AppDbContext _context;
    public CiudadService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<CiudadDto>> Consultar()
    {
        var ciudades = await _context.Ciudades
            .Select(c => new CiudadDto()
            {
                Id = c.Id,
                Nombre = c.Nombre
            })
            .ToListAsync();
        return ciudades;
    }
}