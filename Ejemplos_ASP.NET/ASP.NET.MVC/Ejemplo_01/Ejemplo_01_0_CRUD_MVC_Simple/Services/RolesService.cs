

using Ejemplo_01_0_CRUD_MVC_Simple.Models;
using Ejemplo_01_0_CRUD_MVC_Simple.DALs.MSSDALs;

namespace Ejemplo_01_0_CRUD_MVC_Simple.Services;

public class RolesService
{
    RolesMSSDAL _rolesDao = new();
    async public Task<List<RolModel>> GetAll()
    {
        return await _rolesDao.GetAll();
    }
}
