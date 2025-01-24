

## Areas: Estructurando las aplicacións ASP.NET MVC

Las áreas son una característica ASP.NET utilizadas para organizar las funcionalidades relacionadas en un grupo de forma separada:

- Espacio de nombres para el enrutamiento.
- Estructura de carpetas para vistas y páginas Razor.

El uso de <span style="background-color: yellow;">áreas crea una jerarquía para el enrutamiento</span> añadiendo de otro parámetro de ruta, area, a controller y action, o bien a Razor de la página page.

Las áreas ofrecen una manera de <span style="background-color: yellow;">dividir una aplicación web ASP.NET Core en grupos funcionales más pequeños</span>, cada uno con su propio conjunto de páginas Razor, controladores, vistas y modelos. 

Un área es en realidad una estructura dentro de una aplicación. En un proyecto web ASP.NET Core, los componentes lógicos como Páginas, Modelo, Vista y Controlador se mantienen en carpetas diferentes. El runtime de ASP.NET Core usa convenciones de nomenclatura para crear la relación entre estos componentes. Para una aplicación grande, puede ser conveniente dividir la aplicación en distintas áreas de funciones de alto nivel


### Start up
```csharp
app.MapAreaControllerRoute(
    name: "Admin_default",
    areaName: "Admin",
    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "Users_default",
    areaName: "Users",
    pattern: "Users/{controller=Perfil}/{action=Index}/{id?}");
```

### Ejemplo de controlador

```csharp
namespace Ejemplo_05_Areas.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
```

### Estructura del proyecto

```
Ejemplo_05_Areas
|
│   appsettings.Development.json
│   appsettings.json
│   Ejemplo_05_Areas.csproj
│   Ejemplo_05_Areas.csproj.user
│   Program.cs
│   Readme.md
│
├───Areas
│   ├───Admin
│   │   ├───Controllers
│   │   │       DashboardController.cs
│   │   │
│   │   ├───Models
│   │   └───Views
│   │       │   _ViewImports.cshtml
│   │       │   _ViewStart.cshtml
│   │       │
│   │       ├───Dashboard
│   │       │       Index.cshtml
│   │       │
│   │       └───Shared
│   │               Error.cshtml
│   │               _Layout.cshtml
│   │               _Layout.cshtml.css
│   │               _ValidationScriptsPartial.cshtml
│   │
│   └───Users
│       ├───Controllers
│       │       PerfilController.cs
│       │
│       ├───Models
│       └───Views
│           │   _ViewImports.cshtml
│           │   _ViewStart.cshtml
│           │
│           ├───Perfil
│           │       Index.cshtml
│           │
│           └───Shared
│                   Error.cshtml
│                   _Layout.cshtml
│                   _Layout.cshtml.css
│                   _ValidationScriptsPartial.cshtml
│
├───Controllers
│       HomeController.cs
│
├───Models
│       ErrorViewModel.cs
│
├───Views
    │   _ViewImports.cshtml
    │   _ViewStart.cshtml
    │
    ├───Home
    │       Index.cshtml
    │       Privacy.cshtml
    │
    └───Shared
            Error.cshtml
            _Layout.cshtml
            _Layout.cshtml.css
            _ValidationScriptsPartial.cshtml

```

### Definiciones
[Areas ASP.NET- Microsoft](https://learn.microsoft.com/es-es/aspnet/core/mvc/controllers/areas?view=aspnetcore-9.0)

### Ejemplos
[ASPNETCore.DOCs- Areas - Ejemplos](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas)
[ASPNETCore.DOCs- Areas - Ejemplo-1](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/mvc/controllers/areas/60samples/MVCareas/Program.cs)

### Tutoriales
[Ejemplo](https://medium.com/falafel-software/mvc-areas-with-asp-net-core-f15511b8454b)
[El mejor modo de hacer todo](https://sankarsan.wordpress.com/2012/04/14/asp-net-mvc-areasa-better-way-to-structure-the-application/)

### Discusiones
[Beneficios del uso de las areas](https://stackoverflow.com/questions/13069015/what-are-the-goals-and-benefits-of-using-areas)

