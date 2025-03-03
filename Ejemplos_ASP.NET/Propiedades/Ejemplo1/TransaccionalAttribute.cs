namespace Ejemplo1;

[AttributeUsage(AttributeTargets.Method)]
public class TransaccionalAttribute : Attribute
{
    public int Nivel { get; }

    public TransaccionalAttribute(int nivel)
    {
        Nivel = nivel;
    }
}
