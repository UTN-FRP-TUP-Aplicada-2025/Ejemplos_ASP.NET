

using Ejemplo_14_Transacciones.Models;
using Ejemplo_14_Transacciones.Services;

//prueba 

async Task pruebaInsertarUsuarioConRoles()
{
    CuentasService _usuariosService = new();
    var usuario = new UsuarioModel { Nombre = "Julieta", Clave = "123" };
    var roles = new List<RolModel> 
    { 
        new RolModel { Nombre = "Encuestador" }, 
        new RolModel { Nombre = "Supervisor" } 
    };
    await _usuariosService.CrearUsuario(usuario, roles);
}


//los metodos debajo generan un fichero html cada uno, tal como lo haria un servicio web ante una consulta
// el metodo representaria la consulta http del cliente http

async Task GenerarPaginaHTMLListadoPersonas()
{
    PersonasService _personaService = new();

    var Models = await _personaService.GetAll();

    // simulando la respuesta a una consulta por un recurso - genera el codigo html dinamicamente.

    var contenidoDinamicoHtml = @"
<html>
<head>
    <script src=""https://code.jquery.com/jquery-3.2.1.slim.min.js"" ></script>
    <script src=""https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js"" ></script>
    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js""></script>
    <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css"" >
   <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css"">
</head>
<body>

<h1>Generando contenido dinámico</h1>

<table class=""table table-dark"">
  <thead>
    <tr>
       <th>Id</th><th>DNI</th><th>Nombre</th><th>DNI</th> 
    </tr>
   </thead>
   <tbody>
";
    foreach (var item in Models)
    {
        contenidoDinamicoHtml +=
    $@"        <tr>
            <td>{item.Id}</td><td>{item.DNI}</td><td>{item.Nombre}</td><td>{item.DNI}</td>
        </tr>";
    }

    contenidoDinamicoHtml +=
    @"<tbody>
   </table>
</body>
</html>";


    //genero la pagina dinamicamente
    File.WriteAllText("../../../wwwroot/personas.html", contenidoDinamicoHtml);

    Console.WriteLine(contenidoDinamicoHtml);
}

async Task GenerarPaginaHTMLListadoUsuariosYRoles()
{


    // simulando la respuesta a una consulta por un recurso - genera el codigo html dinamicamente.

    var contenidoDinamicoHtml = @"
<html>
<head>
    <script src=""https://code.jquery.com/jquery-3.2.1.slim.min.js"" ></script>
    <script src=""https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js"" ></script>
    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js""></script>
    <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css"" >
   <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css"">
</head>
<body>

<h2>Generando contenido dinámico - Usuarios y Roles</h2>

<!--https://getbootstrap.com/docs/5.0/layout/containers/-->

<div class=""container"">

    <div class=""col-12"" >

        <div class=""col-12"" style=""border: 1px solid black;"">
            <div class=""row"" style=""border-bottom: 1 px solid gray;"">
                <div class=""col-4"">
                    Nombre 
                </div>
                <div class=""col-4"">
                    Clave
                </div>
            </div>
            <div class=""row"" style=""border-top: 1px solid gray;"">  
                Roles
            </div>
        </div> <br/>";

    CuentasService _usuariosService = new();
    var Models = await _usuariosService.GetAll();
    foreach (var item in Models)
    {
        contenidoDinamicoHtml +=
$@"
        <div class=""col-12"">
            <div class=""col"" >
                <div class=""row"">
                    <div class=""col-4"">
                        {item.Nombre} 
                    </div>
                    <div class=""col-4"">
                        {item.Clave}
                    </div>
                </div>
                <div class=""row"" style=""border-top: 2px solid black;"">";

        var UsuariosRolesModels = await _usuariosService.GetRolesByUsuario(item.Nombre);
        foreach (var itemRoles in UsuariosRolesModels)
        {
            contenidoDinamicoHtml += itemRoles.NombreRol + " ";
        }
        if (UsuariosRolesModels.Count == 0)
            contenidoDinamicoHtml += "No tiene asignado un rol.";

        contenidoDinamicoHtml +=
        @"
       
                </div><br/>

            </div>
        </div>";
    }

    contenidoDinamicoHtml +=

@"
    <div>
<div>";

    //genero la pagina dinamicamente
    File.WriteAllText("../../../wwwroot/usuarios.html", contenidoDinamicoHtml);

    Console.WriteLine(contenidoDinamicoHtml);
}

//llamando a los métodos.
try
{
    await pruebaInsertarUsuarioConRoles();
}catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
await GenerarPaginaHTMLListadoPersonas();
await GenerarPaginaHTMLListadoUsuariosYRoles();
