using Ejemplo_01_0_CRUD_MVC_Simple.Models;

namespace Ejemplo_01_0_CRUD_MVC_Simple.DALs.MemoryDALs;

public class PersonasMemoryDAL : IPersonasDAL
{
    static int GEN=0;
    static public List<PersonaModel> personas = new List<PersonaModel>
    {
        new PersonaModel(){ Id=1,DNI=2343243, Nombre="Esteban"},
        new PersonaModel(){ Id=2,DNI=3343243, Nombre="Betiana"}
    };


    public List<PersonaModel> GetAll()
    {
        return personas;
    }

    public PersonaModel? GetByKey(int id)
    {
        return personas.Where(p => p.Id == id).FirstOrDefault();
    }

    public bool Insert(PersonaModel nuevo)
    {
        nuevo.Id = ++GEN;
        personas.Add(nuevo);

        return true;
    }
    
    public bool Update(PersonaModel actualizar)
    {
        var p = GetByKey(actualizar.Id);

        if (p != null)
        {
            p.DNI = actualizar.DNI;
            p.Nombre = actualizar.Nombre;

            return true;
        }
        return false;
    }

    public void Delete(int id)
    {
        var persona = GetByKey(id);
        if(persona!=null)
            personas.Remove(persona);
    }
}
