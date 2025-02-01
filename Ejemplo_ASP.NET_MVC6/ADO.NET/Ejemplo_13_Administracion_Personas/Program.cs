

using Ejemplo_13_Personas.Services;

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
File.WriteAllText("../../../wwwroot/tabla.html", contenidoDinamicoHtml);

Console.WriteLine(contenidoDinamicoHtml);