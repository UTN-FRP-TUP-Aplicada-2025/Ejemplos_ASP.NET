using Ejemplo_06_CRUD_Razor_server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ejemplo_06_CRUD_Razor_server.common;

public class AppDbContext : DbContext
{
    public DbSet<Respuesta> Respuestas { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración adicional de modelos si es necesario
    }
}

//dotnet ef migrations add InitialCreate