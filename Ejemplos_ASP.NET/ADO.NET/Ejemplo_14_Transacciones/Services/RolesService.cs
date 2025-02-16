

using Ejemplo_14_Transacciones.Models;
using Ejemplo_14_Transacciones.DALs.MSSDALs;

namespace Ejemplo_14_Transacciones.Services;

public class RolesService
{
    RolesMSSDAL _rolesDao = new();
    

    async public Task<List<RolModel>> GetAll()
    {
        return await _rolesDao.GetAll();
    }

    
}
