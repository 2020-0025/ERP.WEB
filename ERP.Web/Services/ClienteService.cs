using ERP.Web.Data;
using ERP.Web.Domain.Dto;
using ERP.Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ERP.Web.Services;

public interface IClienteService
{
    Task<List<ClienteDto>> Consultar(string filtro);
    Task<bool> Crear(ClienteDto request);
    Task<bool> Eliminar(int Id);
    Task<bool> Modificar(ClienteDto request);
}

public class ClienteService : IClienteService
{
    private readonly AppDbContext _context;
    public ClienteService(AppDbContext context)
    {
        _context = context;
    }
    ///Consultar los clientes existentes
    public async Task<List<ClienteDto>> Consultar(string filtro)
    {
        var clientes = await
            _context.Clientes
            .Include(c => c.DatosPersonales)
            .Where(c => c.DatosPersonales.Nombre.Contains(filtro))
            .Select(
                c =>
                new ClienteDto()
                {
                    Id = c.Id,
                    PersonaId = c.PersonaId,
                    LimiteDeCredito = c.LimiteDeCredito,
                    DatosPersonales = new PersonaDto()
                    {
                        Id = c.DatosPersonales.Id,
                        Nombre = c.DatosPersonales.Nombre,
                        FechaDeNacimiento = c.DatosPersonales.FechaDeNacimiento
                    }
                }
            )
            .ToListAsync();
        return clientes;
    }
    public async Task<bool> Crear(ClienteDto request)
    {
        var cliente = Cliente.Create(
            request.DatosPersonales.Nombre,
            request.DatosPersonales.FechaDeNacimiento,
            request.LimiteDeCredito
        );
        _context.Clientes.Add(cliente);
        ;
        return (await _context.SaveChangesAsync()) > 0;
    }
    public async Task<bool> Modificar(ClienteDto request)
    {
        //1. Busco el cliente
        var cliente = await _context.Clientes
            .Include(c=>c.DatosPersonales)
            .FirstOrDefaultAsync(c => c.Id == request.Id);
        //2. Modifico el cliente
        cliente!.DatosPersonales.Nombre = request.DatosPersonales.Nombre;
        cliente!.DatosPersonales.FechaDeNacimiento = request.DatosPersonales.FechaDeNacimiento;
        cliente!.LimiteDeCredito = request.LimiteDeCredito;
        //Guardo los cambios
        return (await _context.SaveChangesAsync()) > 0;
    }
    public async Task<bool> Eliminar(int Id)
    {
        var cliente = await _context.Clientes
            .FirstOrDefaultAsync(c => c.Id == Id);

        _context.Clientes.Remove(cliente!);

        return (await _context.SaveChangesAsync()) > 0;
    }
}
