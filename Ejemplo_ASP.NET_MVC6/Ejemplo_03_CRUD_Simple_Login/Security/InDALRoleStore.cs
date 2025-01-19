using Ejemplo_03_CRUD_Simple_Login.DALs.MSSDAO;
using Microsoft.AspNetCore.Identity;
using System.Collections.Concurrent;
using System.Data;

namespace Ejemplo_03_CRUD_Simple_Login.Security;

public class InDALRoleStore : IRoleStore<IdentityRole>
{
    //private readonly ConcurrentDictionary<string, IdentityRole> _roles = new();
    CuentasMSSDAL _cuentasDal = new();
    CuentasRolesMSSDAL _cuentasRolesDal = new();
    RolesMSSDAL _rolesDal = new();

    public Task<IdentityResult> CreateAsync(IdentityRole role, CancellationToken cancellationToken)
    {
       // _roles.TryAdd(role.Id, role);
        return Task.FromResult(IdentityResult.Success);
    }

    public Task<IdentityResult> DeleteAsync(IdentityRole role, CancellationToken cancellationToken)
    {
       // _roles.TryRemove(role.Id, out _);
        return Task.FromResult(IdentityResult.Success);
    }

    public Task<IdentityRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
    {
        //_roles.TryGetValue(roleId, out var role);
        //return Task.FromResult(role);
        return Task.FromResult(new IdentityRole{ });
    }

    public Task<IdentityRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
    {
        //var role = _roles.Values.FirstOrDefault(r => r.NormalizedName == normalizedRoleName);
        return Task.FromResult(new IdentityRole { });
    }

    public Task<string> GetNormalizedRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        return Task.FromResult(role.NormalizedName);
    }

    public Task<string> GetRoleIdAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        return Task.FromResult(role.Id);
    }

    public Task<string> GetRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        return Task.FromResult(role.Name);
    }

    public Task SetNormalizedRoleNameAsync(IdentityRole role, string normalizedName, CancellationToken cancellationToken)
    {
        role.NormalizedName = normalizedName;
        return Task.CompletedTask;
    }

    public Task SetRoleNameAsync(IdentityRole role, string roleName, CancellationToken cancellationToken)
    {
        role.Name = roleName;
        return Task.CompletedTask;
    }

    public Task<IdentityResult> UpdateAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        //if (_roles.ContainsKey(role.Id))
        //{
        //    _roles[role.Id] = role;
        //    return Task.FromResult(IdentityResult.Success);
        //}
        return Task.FromResult(IdentityResult.Failed());
    }

    public void Dispose() { }
}
