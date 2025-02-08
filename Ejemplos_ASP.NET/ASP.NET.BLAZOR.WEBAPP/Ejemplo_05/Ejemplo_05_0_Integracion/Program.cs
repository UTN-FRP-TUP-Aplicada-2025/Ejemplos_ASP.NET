using Ejemplo_05_0_Integracion.Components;
using Ejemplo_05_0_Integracion.Services;
using Ejemplo_05_0_Integracion.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region servicios
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
#endregion

#region carga en caliente
builder.Services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
{
    options.FileProviders.Add(new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
        builder.Environment.ContentRootPath));
});
#endregion

#region entidades de negocio
builder.Services.AddSingleton(new PersonasService());
builder.Services.AddSingleton<UsuarioService>();
#endregion

#region login - esquema de autentificación por cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token"; //default Cookie
        options.LoginPath = "/admin/login";
        options.AccessDeniedPath = "/admin/access-denied";
        options.ReturnUrlParameter = "returnurl";
        //
        options.Cookie.IsEssential = true;//algunos navegadores bloquean las cookies que no son esenciales
        options.Cookie.MaxAge = null;// TimeSpan.FromMinutes(30);
        //                             //options.IdleTimeout = TimeSpan.FromDays(30); //tiempo de inactividad
        options.Cookie.HttpOnly = true; //evita acceso de javascript
        options.Cookie.SameSite = SameSiteMode.Strict;// Lax para casos como OAuth, OpenID Connect, etc.
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
//necesario para acceder al contexto httpcontext
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SwaggerAccess", policy =>
        policy.RequireAuthenticatedUser());
});

#endregion

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

    //c.AddSecurityDefinition("cookieAuth", new OpenApiSecurityScheme
    //{
    //    Type = SecuritySchemeType.ApiKey,
    //    In = ParameterLocation.Cookie,
    //    Name = "auth_token",
    //    Description = "Autenticación basada en cookies"
    //});

    //c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "cookieAuth" }
    //        },
    //        new List<string>()
    //    }
    //});
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

app.UseRouting();
#region cors - CORS debe declararse antes de UseAuthorization() y MapControllers().
app.UseCors("AllowSpecificOrigins");
#endregion 




app.UseAntiforgery();

/*
//app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

//app.MapWhen(context => context.Request.Path.StartsWithSegments("/admin"), adminApp =>
//{
//    adminApp.UseRouting();
//    adminApp.UseEndpoints(endpoints =>
//    {
//        endpoints.MapRazorComponents<App>()
//                 .AddInteractiveServerRenderMode();
//    });
//});


// Mapear los componentes Razor
//e habilita la renderización interactiva con SignalR, permitiendo que Blazor Server maneje la UI en el servidor.
//En Blazor Server, la lógica del componente se ejecuta en el servidor y se mantiene una conexión en tiempo real con el cliente a través de SignalR.
//Los eventos en la UI (clics, cambios en formularios, etc.) se envían al servidor, se procesan y el DOM se actualiza en el navegador.
//Si esta  AddInteractiveServerRenderMode(), Blazor no sabrá cómo manejar la interacción, y solo podrá renderizar componentes estáticos en el HTML inicial, sin eventos ni interactividad.
*/

#region configuracion api y swagger
//if (app.Environment.IsDevelopment()) //comentar para que corra en modo release
{
   // app.UseSwagger();
   // app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();

/*esto funciona*/
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/swagger") &&
        !context.User.Identity.IsAuthenticated)
    {
        context.Response.Redirect("/admin/login?returnurl=/swagger");
        return;
    }
    await next();
});
app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();// antes de MapRazorComponents

#endregion

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();

//A valid antiforgery token was not provided with the request. Add an antiforgery token, or disable antiforgery validation for this endpoint.
// CSRF (Cross-Site Request Forgery)