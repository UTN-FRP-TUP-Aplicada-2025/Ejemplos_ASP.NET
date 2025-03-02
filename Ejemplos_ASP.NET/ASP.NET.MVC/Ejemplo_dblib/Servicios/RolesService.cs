

using Ejemplo_15_personas_datoslib.Models;
using Ejemplo_15_personas_datoslib.DALs.MSSDALs;

namespace Ejemplo_15_personas_datoslib.Services;

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
