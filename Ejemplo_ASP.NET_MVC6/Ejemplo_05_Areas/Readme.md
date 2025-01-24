

## Areas: Estructurando las aplicacións ASP.NET MVC

Las áreas son una característica ASP.NET utilizadas para organizar las funcionalidades relacionadas en un grupo de forma separada:

- Espacio de nombres para el enrutamiento.
- Estructura de carpetas para vistas y páginas Razor.

El uso de áreas crea una jerarquía para el enrutamiento añadiendo de otro parámetro de ruta, area, a controller y action, o bien a Razor de la página page.

Las áreas ofrecen una manera de dividir una aplicación web ASP.NET Core en grupos funcionales más pequeños, cada uno con su propio conjunto de páginas Razor, controladores, vistas y modelos. 
Un área es en realidad una estructura dentro de una aplicación. En un proyecto web ASP.NET Core,  los componentes lógicos como Páginas, Modelo, Vista y Controlador se mantienen en carpetas diferentes. El runtime de ASP.NET Core usa convenciones de nomenclatura para crear la relación entre estos componentes. Para una aplicación grande, puede ser conveniente dividir la aplicación en distintas áreas de funciones de alto nivel

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

