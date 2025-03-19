using ERP.Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Web.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<Empleado> Empleados { get; set; } = null!;
    public DbSet<Persona> Personas { get; set; } = null!;
    public DbSet<Ciudad> Ciudades { get; set; } = null!;

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}

public class AppDbContextSeeder(AppDbContext context)
{
    public async Task SeedAsync()
    {
        if (await context.Ciudades.AnyAsync()) 
            return;
        var ciudades = new[]
        {
            Ciudad.Create("Cotuí"),
            Ciudad.Create("Villa la mata."),
            Ciudad.Create("La Bija."),
            Ciudad.Create("Soledad."),
            Ciudad.Create("Los Corozos."),
            Ciudad.Create("Angelina."),
            Ciudad.Create("Pescozon."),
            Ciudad.Create("Barrio Lindo."),
            Ciudad.Create("El Remolino."),
            Ciudad.Create("San Miguel."),
            Ciudad.Create("Fantino.")
        };
        await context.Ciudades.AddRangeAsync(ciudades);
        await context.SaveChangesAsync();
    }
} 