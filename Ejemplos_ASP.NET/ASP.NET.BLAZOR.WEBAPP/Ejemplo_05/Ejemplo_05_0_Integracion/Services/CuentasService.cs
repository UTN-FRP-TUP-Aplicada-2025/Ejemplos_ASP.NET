
using Ejemplo_05_0_Integracion.DALs;
using Ejemplo_05_0_Integracion.DALs.MSSDALs;
using Ejemplo_05_0_Integracion.Models;

namespace Ejemplo_05_0_Integracion.Services;

public class UsuariosService
{
    IUsuariosDAL _dao = new UsuariosMSSDAL();

    async public Task<bool> VerificarLogin(UsuarioModel usuarioVerificar)
    { 
        var usuario = await _dao.GetByKey(usuarioVerificar.Nombre);
        return usuario != null && usuarioVerificar.Clave == usuario.Clave;
    }

    async public Task<List<UsuarioModel>> GetAll()
    {
        return await _dao.GetAll();
    }

    async public Task<UsuarioModel?> GetByNombre(string nombre)
    {
        return await _dao.GetByKey(nombre);
    }

    async public Task<bool> CrearNuevo(UsuarioModel persona)
    {
        return await _dao.Insert(persona);
    }

    async public Task<bool> Actualizar(UsuarioModel persona)
    {
        return await _dao.Update(persona);
    }

    async public Task<bool> Eliminar(string nombre)
    {
        return await _dao.Delete(nombre);
    }
}
