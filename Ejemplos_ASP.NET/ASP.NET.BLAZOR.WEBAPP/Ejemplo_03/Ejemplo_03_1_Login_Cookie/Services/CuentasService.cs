
using Ejemplo_03_1_Login_Cookie.DALs;
using Ejemplo_03_1_Login_Cookie.DALs.MSSDALs;
using Ejemplo_03_1_Login_Cookie.Models;
using Microsoft.AspNetCore.Identity;

namespace Ejemplo_03_1_Login_Cookie.Services;

public class UsuariosService
{
    private readonly IUsuariosDAL _dao = new UsuariosMSSDAL();
    private readonly PasswordHasher<ApplicationUser> _passwordHasher;

    public UsuariosService(PasswordHasher<ApplicationUser> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    async public Task<bool> VerificarLogin(UsuarioModel usuarioVerificar)
    {
        var usuario = await _dao.GetByKey(usuarioVerificar.Nombre);
        if (usuario == null)
        {
            return false;
        }

        // Necesitas obtener el hash de la contraseña almacenada (si lo tienes)
        // o adaptar tu DAL para que lo haga. Por ahora, asumimos que
        // la contraseña hasheada se almacena en la propiedad 'Clave' del usuario en la base de datos.

        string kk=_passwordHasher.HashPassword(new ApplicationUser { UserName = usuario.Nombre }, usuario.Clave);

        var verificationResult = _passwordHasher.VerifyHashedPassword(
            new ApplicationUser { UserName = usuarioVerificar.Nombre }, // Necesitas un objeto ApplicationUser para el contexto
            kk,//usuario.Clave, // La contraseña hasheada almacenada
            usuarioVerificar.Clave // La contraseña proporcionada por el usuario
        );

        return verificationResult == PasswordVerificationResult.Success;
    }

    async public Task<List<UsuarioModel>> GetAll()
    {
        return await _dao.GetAll();
    }

    async public Task<UsuarioModel?> GetByNombre(string nombre)
    {
        return await _dao.GetByKey(nombre);
    }

    //async public Task<bool> CrearNuevo(UsuarioModel persona)
    //{
    //    // Antes de insertar, hashea la contraseña
    //    var hashedPassword = _passwordHasher.HashPassword(new ApplicationUser { UserName = persona.Nombre }, persona.Clave);
    //    persona.Clave = hashedPassword;
    //    return await _dao.Insert(persona);
    //}

    async public Task<bool> CrearNuevo(UsuarioModel persona)
    {
        var hashedPassword = _passwordHasher.HashPassword(new ApplicationUser { UserName = persona.Nombre }, persona.Clave);
        persona.Clave = hashedPassword; // Guarda el HASH en la base de datos
        return await _dao.Insert(persona);
    }

    async public Task<bool> Actualizar(UsuarioModel persona)
    {
        // Considera si necesitas re-hashear la contraseña aquí si se modifica
        return await _dao.Update(persona);
    }

    async public Task<bool> Eliminar(string nombre)
    {
        return await _dao.Delete(nombre);
    }

    // Método para obtener el hash (si tu DAL no lo hace directamente)
    async public Task<string?> GetPasswordHash(string userName)
    {
        var usuario = await _dao.GetByKey(userName);

        string kk = _passwordHasher.HashPassword(new ApplicationUser { UserName = usuario.Nombre }, usuario.Clave);

        return kk; //usuario?.Clave; // Asumiendo que 'Clave' ahora almacena el hash
    }
}