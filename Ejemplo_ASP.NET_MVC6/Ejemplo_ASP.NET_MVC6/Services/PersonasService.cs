using EjemploASP.NET_MVC.DALs;
using EjemploASP.NET_MVC.Models;

namespace EjemploASP.NET_MVC.Services
{
    public class PersonasService
    {
        //IPersonasDAO personasDAO = new PersonasMemoryDAO();
        IPersonasDAO personasDAO = new PersonasMSDAO();

        public List<Persona> GetAll()
        {
            return personasDAO.GetAll();
        }

        public Persona? GetById(int id)
        {
            return personasDAO.GetById(id);
        }

        public void Actualizar(Persona persona)
        {
            personasDAO.Update(persona);
        }

        public void Eliminar(int id)
        {
            personasDAO.Delete(id);
        }
    }
}
