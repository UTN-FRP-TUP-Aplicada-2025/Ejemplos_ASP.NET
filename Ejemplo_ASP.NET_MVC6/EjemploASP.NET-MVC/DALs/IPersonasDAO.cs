using EjemploASP.NET_MVC.Models;

namespace EjemploASP.NET_MVC.DALs
{
    public interface IPersonasDAO
    {
        List<Persona> GetAll();
        Persona? GetById(int id);
        void Update(Persona actualizar);

        void Delete(int id);
    }
}
