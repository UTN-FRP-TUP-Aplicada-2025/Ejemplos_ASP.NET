using Ejemplo_15_personas_datoslib.DALs;
using Ejemplo_15_personas_datoslib.DALs.MSSDALs;
using Ejemplo_15_personas_datoslib.Services;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


#region creando el contexto
builder.Services.AddTransient<SqlConnection>(sp =>
{
    var configuration = sp.GetService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("CadenaConexion");
    return new SqlConnection(connectionString);
});

//La conexi�n se mantiene viva solo durante la duraci�n de una solicitud HTTP.
//Es m�s eficiente en aplicaciones con m�ltiples solicitudes simult�neas.
builder.Services.AddScoped<ITransaction<SqlTransaction>, SqlServerTransaction>();

builder.Services.AddScoped<PersonasMSSDAL>();
builder.Services.AddScoped<UsuariosMSSDAL>();
builder.Services.AddScoped<RolesMSSDAL>();
builder.Services.AddScoped<UsuariosRolesMSSDAL>();
//
builder.Services.AddScoped<PersonasService>();
builder.Services.AddScoped<CuentasService>();
builder.Services.AddScoped<RolesService>();
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
                  .AllowAnyMethod()  // Permitir cualquier m�todo (GET, POST, etc.)
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

app.UseCors("PermitirTodo"); // Aplicar la pol�tica de CORS

app.UseAuthorization();

app.MapControllers();





app.Run();
