using Ejemplo_03_1_Login_Cookie.Models;
using Ejemplo_03_1_Login_Cookie.Services;
using Microsoft.AspNetCore.Identity;

namespace Ejemplo_03_1_Login_Cookie;

public class CustomUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>
{
    private readonly UsuariosService _usuariosService;

    public CustomUserStore(UsuariosService usuariosService)
    {
        _usuariosService = usuariosService;
    }

    public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        var usuarioModel = new UsuarioModel { Nombre = user.UserName, Clave = user.PasswordHash }; // Asumiendo que pasas el hash aquí
        var result = await _usuariosService.CrearNuevo(usuarioModel);
        return result ? IdentityResult.Success : IdentityResult.Failed(new IdentityError { Description = "No se pudo crear el usuario." });
    }

    public async Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        var result = await _usuariosService.Eliminar(user.UserName);
        return result ? IdentityResult.Success : IdentityResult.Failed(new IdentityError { Description = "No se pudo eliminar el usuario." });
    }

    public void Dispose()
    {
        // No hay recursos no administrados que liberar en este caso simple
    }

    public async Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        // Asume que tu servicio puede buscar por ID (tendrías que implementarlo en el servicio y DAL)
        // var usuarioModel = await _usuariosService.GetById(userId);
        // if (usuarioModel != null)
        // {
        //     return new ApplicationUser { Id = userId, UserName = usuarioModel.Nombre, PasswordHash = usuarioModel.Clave };
        // }
        throw new NotImplementedException("FindByIdAsync no implementado.");
    }

    public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        var usuarioModel = await _usuariosService.GetByNombre(normalizedUserName);
        if (usuarioModel != null)
        {
            string kk= await _usuariosService.GetPasswordHash(usuarioModel.Nombre);

            return new ApplicationUser { UserName = usuarioModel.Nombre, PasswordHash = kk };// usuarioModel.Clave };
        }
        return null;
    }

    public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.UserName?.ToUpperInvariant());
    }

    public async Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        // Llama a tu servicio para obtener el hash basado en el nombre de usuario


        return await _usuariosService.GetPasswordHash(user.UserName);
        //gg
    }

    public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        // Necesitas una forma de tener un ID para tu ApplicationUser
        // Si tu UsuarioModel tiene un ID, úsalo aquí.
        // Por ahora, usaremos el nombre de usuario como ID (no es ideal para producción).
        return Task.FromResult(user.UserName);
    }

    public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.UserName);
    }

    public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
    {
        // Si tu UsuarioModel tiene una propiedad para el nombre normalizado, actualízala aquí.
        return Task.CompletedTask;
    }

    public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
    {
        // No necesitamos hacer nada aquí, ya que el hashing se hace en el servicio al crear/actualizar
        user.PasswordHash = passwordHash; // Almacena el hash en la propiedad del usuario para su uso posterior
        return Task.CompletedTask;
    }

    public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
    {
        // Si tu UsuarioModel tiene una propiedad para el nombre de usuario, actualízala aquí.
        return Task.CompletedTask;
    }

    public async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        var usuarioModel = new UsuarioModel { Nombre = user.UserName, Clave = user.PasswordHash }; // Considera cómo manejar la actualización de la contraseña
        var result = await _usuariosService.Actualizar(usuarioModel);
        return result ? IdentityResult.Success : IdentityResult.Failed(new IdentityError { Description = "No se pudo actualizar el usuario." });
    }

    public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
    }
}