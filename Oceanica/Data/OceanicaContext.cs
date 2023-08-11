using Microsoft.EntityFrameworkCore;
using OceanicaWebApp.Models;

namespace OceanicaWebApp.Data;

public class OceanicaContext : DbContext
{
    public OceanicaContext(DbContextOptions options) : base(options)
    {
        base.Database.EnsureCreated();
    }

    public DbSet<Vessel> Vessels { get; set; }
    public DbSet<Contract> Contracts { get; set; }
}
