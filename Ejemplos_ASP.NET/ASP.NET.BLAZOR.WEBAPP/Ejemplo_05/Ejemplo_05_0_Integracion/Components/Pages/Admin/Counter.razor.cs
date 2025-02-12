using Microsoft.AspNetCore.Components;

namespace Ejemplo_05_0_Integracion.Components.Pages.Admin;

public partial class Counter:ComponentBase
{
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
