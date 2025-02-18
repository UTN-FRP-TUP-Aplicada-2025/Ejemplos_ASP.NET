
using Ejemplo_05_Areas.DALs;
using Ejemplo_05_Areas.DALs.MSSDALs;
using Ejemplo_05_Areas.Models;

namespace Ejemplo_05_0_Integracion.Services;

public class UsuariosService
{
    UsuariosMSSDAL _usuariosDao = new UsuariosMSSDAL();

    async public Task<bool> VerificarLogin(UsuarioModel usuarioVerificar)
    { 
        var usuario = await _usuariosDao.GetByKey(usuarioVerificar.Nombre);
        return usuario != null && usuarioVerificar.Clave == usuario.Clave;
    }

    async public Task<List<UsuarioModel>> GetAll()
    {
        return await _usuariosDao.GetAll();
    }

    async public Task<UsuarioModel?> GetByNombre(string nombre)
    {
        return await _usuariosDao.GetByKey(nombre);
    }

    async public Task<bool> CrearNuevo(UsuarioModel persona)
    {
        return await _usuariosDao.Insert(persona);
    }

    async public Task<bool> Actualizar(UsuarioModel persona)
    {
        return await _usuariosDao.Update(persona);
    }

    async public Task<bool> Eliminar(string nombre)
    {
        return await _usuariosDao.Delete(nombre);
    }
}
