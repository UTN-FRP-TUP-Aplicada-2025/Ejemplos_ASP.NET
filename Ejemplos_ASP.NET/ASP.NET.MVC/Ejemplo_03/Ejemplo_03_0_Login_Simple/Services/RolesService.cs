

using Ejemplo_03_0_Login_Simple.Models;
using Ejemplo_03_0_Login_Simple.DALs.MSSDALs;

namespace Ejemplo_03_0_Login_Simple.Services;

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
