var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region  identidad

//builder.Services.AddSingleton<UsuarioDAO>();
//builder.Services.AddSingleton<RolDAO>();

builder.Services.AddAuthentication("Cookies")
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
    });

builder.Services.AddAuthorization();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; 
});

#endregion

#region configuración de restapi y swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


#region habilitando session
app.UseAuthorization();
app.UseSession();
#endregion

#region configuración api y swagger
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment()) //comentar para que corra en modo release
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
#endregion

app.Run();
