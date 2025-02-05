var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();
app.UseDefaultFiles();

app.Use(async (context, next) =>
{
    var env = app.Services.GetRequiredService<IWebHostEnvironment>();
    var fileProvider = env.WebRootFileProvider;
    var contents = fileProvider.GetDirectoryContents("/");

    // Si la solicitud es a la raíz y no existe index.html, listar archivos
    if (context.Request.Path == "/")
    {
        var indexFile = contents.FirstOrDefault(f => f.Name.Equals("index.html", StringComparison.OrdinalIgnoreCase));

        if (indexFile != null)
        {
            context.Response.Redirect("/index.html");
            return;
        }

        context.Response.ContentType = "text/html";
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
        await next(); // Continuar con otros middlewares
    }
});

app.Run();
