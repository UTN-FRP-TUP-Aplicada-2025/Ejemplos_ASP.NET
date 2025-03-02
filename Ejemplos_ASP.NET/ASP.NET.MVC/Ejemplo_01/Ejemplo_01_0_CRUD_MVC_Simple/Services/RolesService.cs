

using Ejemplo_01_0_CRUD_MVC_Simple.Models;
using Ejemplo_01_0_CRUD_MVC_Simple.DALs.MSSDALs;

namespace Ejemplo_01_0_CRUD_MVC_Simple.Services;

public class RolesService
{
    readonly private RolesMSSDAL _rolesDao;

    public RolesService(RolesMSSDAL rolesDao)
    {
        _rolesDao = rolesDao;
    }

    async public Task<List<RolModel>> GetAll()
    {
        return await _rolesDao.GetAll();
    }
}
