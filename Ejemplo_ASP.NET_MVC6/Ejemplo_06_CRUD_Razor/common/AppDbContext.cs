using Ejemplo_05_CRUD_Razor.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ejemplo_05_CRUD_Razor.common;

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