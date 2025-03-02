
# signal r

https://learn.microsoft.com/en-us/answers/questions/1613062/reload-the-page-to-restore-functionality-blazor-se?page=1#answers

https://learn.microsoft.com/en-us/answers/questions/1613062/reload-the-page-to-restore-functionality-blazor-se

https://stackoverflow.com/questions/78991856/blazor-server-fix-could-not-reconnect-to-the-server-problem

https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/signalr?view=aspnetcore-3.1#reflect-the-server-side-connection-state-in-the-ui



## Tamplates open source

https://startbootstrap.com/previews/sb-admin-2

https://bootstrapmade.com/nice-admin-bootstrap-admin-html-template/

https://startbootstrap.com/previews/simple-sidebar

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