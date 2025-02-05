using Ejemplo_01_Personas.Models;
using Microsoft.EntityFrameworkCore;


namespace Ejemplo_01_Personas.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<PersonaModel> Personas { get; set; }
        //public DbSet<Otro> Otros { get; set; }

        private readonly string _connectionString;

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=TSP;DatabaseEjemplo_05_0_Roles_Login_DB;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
