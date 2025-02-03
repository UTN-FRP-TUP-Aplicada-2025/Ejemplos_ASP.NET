

## Referencias


temas
https://learn.microsoft.com/en-us/aspnet/core/blazor/components/data-binding?view=aspnetcore-9.0

cada carpeta, admin y public, actua como un área lógica y cada una de esta relacionará los componentes con una funcionalidad especifica 

/Pages
  /Admin
    Dashboard.razor
    Settings.razor
  /Public
    Home.razor
    About.razor


    Evitar el "FOUC" (Flash of Unstyled Content) con media="all"
Este truco asegura que el CSS se cargue antes de renderizar la página.

html
Copy
Edit
<head>
    <link rel="stylesheet" href="/css/style.css" media="all" onload="this.onload=null; this.removeAttribute('media');">
    <noscript><link rel="stylesheet" href="/css/style.css"></noscript>
</head>
?? ¿Cómo funciona?

Primero, el CSS se carga en segundo plano sin bloquear el renderizado.
Cuando termina de cargarse, se aplica automáticamente (onload).
Si JS está deshabilitado, la etiqueta <noscript> carga el CSS normalmente.

https://stackoverflow.com/questions/70630271/eliminating-flash-of-unstyled-content-fouc-in-asp-net-core-5-mvc


https://stackoverflow.com/questions/3221561/eliminate-flash-of-unstyled-content
<!DOCTYPE html>
<html>
<head>
    <title>Bla bla</title>
    <link href="..." rel="stylesheet" />
    <link href="..." rel="stylesheet" />
</head>
<body style="opacity: 0">
    <!-- All HTML content here -->
    <script src="..."></script>
    <script src="..."></script>
    <style>
        body {
            opacity: 1 !important;
        }
    </style>
</body>
</html>
transition: all 1000ms ease-in;