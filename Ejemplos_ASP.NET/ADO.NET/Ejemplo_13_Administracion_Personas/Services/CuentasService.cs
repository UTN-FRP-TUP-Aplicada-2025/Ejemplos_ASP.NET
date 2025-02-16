

using Ejemplo_13.DALs.MSSDALs;
using Ejemplo_13.Models;

namespace Ejemplo_13.Services;

public class CuentasService
{
    UsuariosMSSDAL _usuariosDao = new ();
    UsuariosRolesMSSDAL _usuarioRolesDao = new();

    async public Task<List<UsuarioModel>> GetAll()
    {
        return await _usuariosDao.GetAll();
    }

    
    async public Task<List<UsuarioRolModel>> GetRolesByUsuario(string nombreUsuario)
    {
        var usuario = new UsuarioRolModel{NombreUsuario=nombreUsuario.ToUpper(),
                                            NombreRol="%" //todos los roles
                                            };
        return await _usuarioRolesDao.GetByUsuario(usuario);
    }
}
