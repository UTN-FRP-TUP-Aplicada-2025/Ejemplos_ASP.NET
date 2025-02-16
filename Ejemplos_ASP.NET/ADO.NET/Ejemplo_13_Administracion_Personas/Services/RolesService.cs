

using Ejemplo_13.Models;
using Ejemplo_13.DALs.MSSDALs;

namespace Ejemplo_13.Services;

public class RolesService
{
    RolesMSSDAL _rolesDao = new();
    

    async public Task<List<RolModel>> GetAll()
    {
        return await _rolesDao.GetAll();
    }

    
}
