using EjemploASP.NET_MVC.Models;

namespace EjemploASP.NET_MVC.DALs
{
    public class PersonasMemoryDAO : IPersonasDAO
    {
        static public List<Persona> personas = new List<Persona>
        {
            new Persona(){ Id=1,DNI=2343243, Nombre="Esteban"},
            new Persona(){ Id=2,DNI=3343243, Nombre="Betiana"}
        };


        public List<Persona> GetAll()
        {
            return personas;
        }

        public Persona? GetById(int id)
        {
            return personas.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(Persona actualizar)
        {
            var p = GetById(actualizar.Id);

            if (p != null)
            {
                p.DNI = actualizar.DNI;
                p.Nombre = actualizar.Nombre;
            }

        }

        public void Delete(int id)
        {
            var persona = GetById(id);
            if(persona!=null)
                personas.Remove(persona);
        }
    }
}
