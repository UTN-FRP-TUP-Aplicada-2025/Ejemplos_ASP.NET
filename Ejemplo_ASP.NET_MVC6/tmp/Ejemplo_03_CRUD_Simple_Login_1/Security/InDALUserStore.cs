using Ejemplo_03_CRUD_Simple_Login.DALs.MSSDAO;
using Ejemplo_03_CRUD_Simple_Login.Models;

using Microsoft.AspNetCore.Identity;

namespace Ejemplo_03_CRUD_Simple_Login.Security;

public class InDALUserStore : IUserStore<IdentityUser>, IUserPasswordStore<IdentityUser>, IUserRoleStore<IdentityUser>
{
    //static private readonly List<IdentityUser> _users = new();
    //private readonly Dictionary<string, List<string>> _userRoles = new();

    CuentasMSSDAL _cuentasDal = new();
    CuentasRolesMSSDAL _cuentasRolesDal = new();
    RolesMSSDAL _rolesDal = new();

    public Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        //if (_users.Any(u => u.NormalizedUserName == user.NormalizedUserName))
        //{
        //    return Task.FromResult(IdentityResult.Failed(new IdentityError
        //    {
        //        Code = "DuplicateUserName",
        //        Description = "El nombre de usuario ya existe."
        //    }));
        //}

        var cuenta = new CuentaModel
        {
            UUID=user.Id,
            Nombre = user.UserName,
            Clave = user.PasswordHash
        };
        _cuentasDal.Insert(cuenta);

        //_users.Add(user);

        return Task.FromResult(IdentityResult.Success);
    }

    public Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        //_users.Remove(user);

        _cuentasDal.Delete(Convert.ToInt32(user.Id));
        _cuentasRolesDal.Delete(Convert.ToInt32(user.Id));

        //_userRoles.Remove(user.Id);
        return Task.FromResult(IdentityResult.Success);
    }

    public Task<IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        var cuenta = _cuentasDal.GetByUUID( userId );

        if (cuenta == null)
            return Task.FromResult(null as IdentityUser);

        var user = new IdentityUser
        {
            Id = cuenta.UUID,
            UserName = cuenta.Nombre,
            NormalizedUserName = cuenta.Nombre?.ToUpper(),
            PasswordHash = cuenta.Clave
        };
        return Task.FromResult(user);

        //return Task.FromResult(_users.FirstOrDefault(u => u.Id == userId));
    }

    public Task<IdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        var cuenta = _cuentasDal.GetByNombre(normalizedUserName);

        if (cuenta == null)
            return Task.FromResult(null as IdentityUser);

        var user = new IdentityUser
        {
            Id = cuenta.UUID,
            UserName = cuenta.Nombre,
            NormalizedUserName = cuenta.Nombre?.ToUpper(),
            PasswordHash = cuenta.Clave
        };

        return Task.FromResult(user);

        //return Task.FromResult(_users.FirstOrDefault(u => u.NormalizedUserName == normalizedUserName));
    }

    public Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.NormalizedUserName);
    }

    public Task<string> GetPasswordHashAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.PasswordHash);
    }

    public Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.Id);
    }

    public Task<string> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.UserName);
    }

    public Task<bool> HasPasswordAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
    }

    public Task SetNormalizedUserNameAsync(IdentityUser user, string normalizedName, CancellationToken cancellationToken)
    {
        user.NormalizedUserName = normalizedName;
        return Task.CompletedTask;
    }

    public Task SetPasswordHashAsync(IdentityUser user, string passwordHash, CancellationToken cancellationToken)
    {
        user.PasswordHash = passwordHash;
        return Task.CompletedTask;
    }

    public Task SetUserNameAsync(IdentityUser user, string userName, CancellationToken cancellationToken)
    {
        user.UserName = userName;
        return Task.CompletedTask;
    }

    public Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(IdentityResult.Success);
    }

    public void Dispose() { }

    // Implementación de roles
    public Task AddToRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
    {
        //if (!_userRoles.ContainsKey(user.Id))
        //{
        //    _userRoles[user.Id] = new List<string>();
        //}

        //if (!_userRoles[user.Id].Contains(roleName))
        //{
        //    _userRoles[user.Id].Add(roleName);
        //}

        var cuenta = _cuentasDal.GetByNombre(user.UserName);
        var rol = _rolesDal.GetByNombre(roleName);

        _cuentasRolesDal.Insert(new CuentaRolModel { IdCuenta = cuenta.Id, IdRol = rol.Id });

        return Task.CompletedTask;
    }

    public Task RemoveFromRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
    {
        //if (_userRoles.ContainsKey(user.Id) && _userRoles[user.Id].Contains(roleName))
        //{
        //    _userRoles[user.Id].Remove(roleName);
        //}

        var cuenta = _cuentasDal.GetByNombre(user.UserName);
        var rol = _rolesDal.GetByNombre(roleName);

        return Task.CompletedTask;
    }

    public Task<IList<string>> GetRolesAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        //if (_userRoles.ContainsKey(user.Id))
        //{
        //    return Task.FromResult((IList<string>)_userRoles[user.Id]);
        //}

        return Task.FromResult<IList<string>>(new List<string>());
    }

    public Task<bool> IsInRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
    {
        //return Task.FromResult(_userRoles.ContainsKey(user.Id) && _userRoles[user.Id].Contains(roleName));

        return Task.FromResult(true);
    }

    public Task<IList<IdentityUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
    {
        //var usersInRole = _users.Where(u => _userRoles.ContainsKey(u.Id) && _userRoles[u.Id].Contains(roleName)).ToList();
        //return Task.FromResult((IList<IdentityUser>)usersInRole);

        return Task.FromResult<IList<IdentityUser>>(new List<IdentityUser>());
    }
}