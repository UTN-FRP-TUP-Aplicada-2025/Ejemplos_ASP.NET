

using Ejemplo_01_Personas.Contexts;
using Ejemplo_01_Personas.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo_01_Personas.Services;

public class PersonasService
{
    //AppDbContext _db  = new AppDbContext("Server=TSP;Database=Ejemplo_05_0_Roles_Login_DB;Trusted_Connection=True;TrustServerCertificate=true");
    AppDbContext _db = new AppDbContext("workstation id=Ejemplos_ASP_MVC_DB.mssql.somee.com;packet size=4096;user id=fernando-dev_SQLLogin_1;pwd=bfzixu5w6p;data source=Ejemplos_ASP_MVC_DB.mssql.somee.com;persist security info=False;initial catalog=Ejemplos_ASP_MVC_DB;TrustServerCertificate=True");

    async public Task<List<PersonaModel>> GetAll()
    {
        return await _db.Personas.ToListAsync();
    }

    async public Task<PersonaModel?> GetById(int id)
    {
        return await _db.Personas.FindAsync(id);
    }

    async public Task CrearNuevo(PersonaModel objeto)
    {
        await _db.Personas.AddAsync(objeto);
        await _db.SaveChangesAsync();
    }

    async public Task Actualizar(PersonaModel objeto)
    {
        _db.Personas.Update(objeto);
        await _db.SaveChangesAsync();
    }

    async public Task Eliminar(int id)
    {
        var objeto = await _db.Personas.FindAsync(id);
        if (objeto != null)
        {
            _db.Personas.Remove(objeto);
            await _db.SaveChangesAsync();
        }
    }
}
