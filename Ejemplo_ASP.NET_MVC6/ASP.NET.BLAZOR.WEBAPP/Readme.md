

## Ejemplos ASP.NET Blazor WebAPP


## [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-8.0)


## [Formularios](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/?view=aspnetcore-8.0)

Se admiten formularios HTML estándar. Cree un formulario utilizando la <form>etiqueta HTML normal y especifique un @onsubmitcontrolador para gestionar la solicitud de formulario enviada.


```html
@page "/starship-plain-form"
@inject ILogger<StarshipPlainForm> Logger

<form method="post" @onsubmit="Submit" @formname="starship-plain-form">
    <AntiforgeryToken />
    <div>
        <label>
            Identifier: 
            <InputText @bind-Value="Model!.Id" />
        </label>
    </div>
    <div>
        <button type="submit">Submit</button>
    </div>
</form>

@code {
    [SupplyParameterFromForm]
    private Starship? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    private void Submit() => Logger.LogInformation("Id = {Id}", Model?.Id);

    public class Starship
    {
        public string? Id { get; set; }
    }
}
```

**==Blazor mejora la navegación de páginas y el manejo de formularios al interceptar la solicitud para aplicar la respuesta al DOM existent==**


 ### [EditForm - formularios integrado de Blazor)](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editform?view=aspnetcore-8.0)

 ```html
 @page "/starship-1"
@inject ILogger<Starship1> Logger

<EditForm Model="Model" OnSubmit="Submit" FormName="Starship1">
    <div>
        <label>
            Identifier:
            <InputText @bind-Value="Model!.Id" />
        </label>
    </div>
    <div>
        <button type="submit">Submit</button>
    </div>
</EditForm>

@code {
    [SupplyParameterFromForm]
    private Starship? Model { get; set; }

    protected override void OnInitialized()
    {
        Model ??= new();
    }

    private void Submit() => Logger.LogInformation("Id = {Id}", Model?.Id);

    public class Starship
    {
        public string? Id { get; set; }
    }
}
```


## [Componentes Razor](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/?view=aspnetcore-8.0)

Un componente es una parte autónoma de la interfaz de usuario (UI) con lógica de procesamiento para permitir un comportamiento dinámico. Los componentes se pueden anidar, reutilizar, compartir entre proyectos y utilizar en aplicaciones MVC y Razor Pages.

Los componentes se procesan en una representación en memoria del Modelo de objetos de documento (DOM) del navegador, denominada árbol de procesamiento , que se utiliza para actualizar la interfaz de usuario de una manera flexible y eficiente.

Se diferencia en:

- Vistas Razor , que son páginas de marcado basadas en Razor para aplicaciones MVC.
- Ver componentes , que sirven para representar fragmentos de contenido en lugar de respuestas completas en Razor Pages y aplicaciones MVC.

## [Sintaxis Razor](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-8.0)


https://learn.microsoft.com/en-us/aspnet/core/blazor/components/synchronization-context?view=aspnetcore-8.0