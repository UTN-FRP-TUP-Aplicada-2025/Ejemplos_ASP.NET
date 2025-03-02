
using Ejemplo_15_personas_datoslib.DALs.MSSDALs;
using Ejemplo_15_personas_datoslib.Models;

namespace Ejemplo_15_personas_datoslib.Services;

public class CuentasService
{
    UsuariosMSSDAL _usuariosDao;
    UsuariosRolesMSSDAL _usuarioRolesDao;

    public CuentasService(UsuariosMSSDAL usuariosDao, UsuariosRolesMSSDAL usuariosRolesDao)
    {
        _usuariosDao = usuariosDao;
        _usuarioRolesDao = usuariosRolesDao;
    }

    async public Task<List<UsuarioModel>> GetAll()
    {
        return await _usuariosDao.GetAll();
    }

    async public Task<UsuarioModel> GetByNombre(string nombre)
    {
        return await _usuariosDao.GetByKey(nombre);
    }

    async public Task CrearNuevo(UsuarioModel objeto)
    {
        await _usuariosDao.Insert(objeto);
    }

    async public Task<UsuarioModel> VerificarLogin(UsuarioModel usuario)
    {
        var objeto = await _usuariosDao.GetByKey(usuario.Nombre);
        if (objeto != null && objeto.Clave == usuario.Clave)
        {
            return objeto;
        }
        return null;
    }

    async public Task<List<UsuarioRolModel>> GetRolesByUsuario(string nombreUsuario)
    {
        var usuario = new UsuarioRolModel { NombreUsuario = nombreUsuario.ToUpper(), NombreRol = "%" };
        return await _usuarioRolesDao.GetByUsuario(usuario);
    }

    async public Task Actualizar(UsuarioModel objeto)
    {
        await _usuariosDao.Update(objeto);
    }

    async public Task Eliminar(string nombre)
    {
        var objeto = await GetByNombre(nombre);
        if (objeto != null)
        {
            await _usuariosDao.Delete(nombre);
        }
    }
}