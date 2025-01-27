var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.UseDefaultFiles();

app.Use(async (context, next) =>
{
    var fileProvider = app.Services.GetRequiredService<IWebHostEnvironment>().WebRootFileProvider;
    var contents = fileProvider.GetDirectoryContents("/");
    if (context.Request.Path == "/")
    {
        context.Response.ContentType = "text/html";

        // Crear una lista de enlaces para cada archivo
        var html = "<h1>Archivos en la raíz:</h1><ul>";
        foreach (var item in contents)
        {
            var name = item.Name;
            var url = "/" + name;
            html += $"<li><a href=\"{url}\">{name}</a></li>";
        }
        html += "</ul>";

        await context.Response.WriteAsync(html);
    }
    else
    {
        await next(); // Continuar con otros middlewares si no es la raíz
    }
});


app.Run();
