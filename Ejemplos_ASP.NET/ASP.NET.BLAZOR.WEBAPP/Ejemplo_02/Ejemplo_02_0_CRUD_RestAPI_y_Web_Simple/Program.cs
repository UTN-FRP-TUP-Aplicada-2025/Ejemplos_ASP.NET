using Ejemplo_02_0_CRUD_RestAPI_y_Web_Simple.Components;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

#region cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.SetIsOriginAllowed(origin => string.IsNullOrEmpty(origin) || origin == "null")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
#endregion

#region carga en caliente
builder.Services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
{
    options.FileProviders.Add(new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
        builder.Environment.ContentRootPath));
});
#endregion

#region configuracion de restapi y swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(); //este alcanza si solo es restapi
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Ejemplo API",
        Version = "v1"
    });

    //para filtrar los controladores que fueron tagueados con el atributo: [ApiController]
    //sino mapea los controladores de la vista
    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        var controllerActionDescriptor = apiDesc.ActionDescriptor as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;
        return controllerActionDescriptor != null &&
               controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(ApiControllerAttribute), true).Any();
    });
});
#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

#region configuracion api y swagger

//if (app.Environment.IsDevelopment()) //comentar para que corra en modo release
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
#endregion

#region cors
app.UseCors("AllowSpecificOrigins");
#endregion 

app.Run();
