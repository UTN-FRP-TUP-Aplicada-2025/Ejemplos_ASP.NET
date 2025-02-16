


using Ejemplo_13.DALs.MSSDALs;
using Ejemplo_14_Transacciones.DALs.MSSDALs;
using Ejemplo_14_Transacciones.DAOs.MSSDALs;
using Ejemplo_14_Transacciones.Models;

namespace Ejemplo_14_Transacciones.Services;

public class UsuariosService
{
    UsuariosMSSDAL _usuariosDao = new ();
    UsuariosRolesMSSDAL _usuarioRolesDao = new();

    async public Task<List<UsuarioModel>> GetAll()
    {
        return await _usuariosDao.GetAll();
    }

    async public Task CrearUsuario(UsuarioModel u, List<RolModel> r)
    {
        SqlServerTransaction tx = new ();
        try
        {
            await tx.BeginTransaction();

            await _usuariosDao.Insert(u, tx);

            foreach (var rol in r)
            {
                await _usuarioRolesDao.Insert(new UsuarioRolModel
                {
                    NombreUsuario = u.Nombre,
                    NombreRol = rol.Nombre
                }, tx);
            }
            await tx.CommitAsync();
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            throw ex;
        }
    }

    async public Task<List<UsuarioRolModel>> GetRolesByUsuario(string nombreUsuario)
    {
        var usuario = new UsuarioRolModel{NombreUsuario=nombreUsuario.ToUpper(),
                                            NombreRol="%" //todos los roles
                                            };
        return await _usuarioRolesDao.GetByUsuario(usuario);
    }
}
