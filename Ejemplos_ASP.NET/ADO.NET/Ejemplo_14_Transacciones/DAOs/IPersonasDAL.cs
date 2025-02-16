using Ejemplo_13_Personas.Models;
using Ejemplo_14_Transacciones.DAOs;
using Microsoft.Data.SqlClient;

namespace Ejemplo_13_Personas.DALs;

public interface IPersonasDAL : IBaseDAL<PersonaModel, int, SqlTransaction>
{
    Task<List<PersonaModel>> GetAll(ITransaction<SqlTransaction>? transaccion = null);
    Task<PersonaModel?> GetByKey(int id, ITransaction<SqlTransaction>? transaccion = null);
    Task<bool> Insert(PersonaModel nuevo, ITransaction<SqlTransaction>? transaccion = null);
    Task<bool> Update(PersonaModel actualizar, ITransaction<SqlTransaction>? transaccion = null);
    Task<bool> Delete(int id, ITransaction<SqlTransaction>? transaccion = null);

    ITransaction<SqlTransaction> BeginTransaction();
}
