
using Ejemplo_05_Areas.DALs.MSSDALs;
using Ejemplo_13_Personas.DALs;

IPersonasDAL _dao = new PersonasMSSDAL();
var Models = _dao.GetAll();

var html =@"
<table>
  <thead>
    <tr>
       <th>Id</th><th>DNI</th><th>Nombre</th><th>DNI</th> 
    </tr>
   </thead>
   <tbody>
";
foreach (var item in Models)
{
    html += $@"
       <td>${item.Id}</td><td>{item.DNI}</td><td>{item.Nombre}</td><td>{item.DNI}</td>";
}

html +=
@"<tbody>
   </table>";

Console.WriteLine(html);