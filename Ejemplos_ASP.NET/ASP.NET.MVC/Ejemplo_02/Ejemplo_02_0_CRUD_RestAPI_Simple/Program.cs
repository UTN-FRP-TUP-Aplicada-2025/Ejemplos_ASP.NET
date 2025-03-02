using Ejemplo_15_personas_datoslib.DALs.MSSDALs;
using Ejemplo_15_personas_datoslib.Services;

var builder = WebApplication.CreateBuilder(args);


#region creando el contexto
builder.Services.AddSingleton<PersonasMSSDAL>();
builder.Services.AddSingleton<UsuariosMSSDAL>();
builder.Services.AddSingleton<RolesMSSDAL>();
builder.Services.AddSingleton<UsuariosRolesMSSDAL>();
//
builder.Services.AddSingleton<PersonasService>();
builder.Services.AddSingleton<CuentasService>();
builder.Services.AddSingleton<RolesService>();
//
#endregion


#region swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo",
        policy =>
        {
            policy.AllowAnyOrigin() // Permitir cualquier origen
                  .AllowAnyMethod()  // Permitir cualquier método (GET, POST, etc.)
                  .AllowAnyHeader(); // Permitir cualquier encabezado
        });
});
#endregion

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigins", policy =>
//    {
//        policy.SetIsOriginAllowed(origin => string.IsNullOrEmpty(origin) || origin == "null")
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PermitirTodo"); // Aplicar la política de CORS

app.UseAuthorization();

app.MapControllers();





app.Run();
