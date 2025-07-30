
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApiReynoVerde;
using WebApiReynoVerde.Repositorios;
using WebApiReynoVerde.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAutoMapper(typeof(Program));

//Configuración de la base de datos y el contexto
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer("name=DefaultConnection"));

//Configuracion de Identity
builder.Services.AddIdentityApiEndpoints<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders(); // Añadir esto es buena práctica, si no lo tienes


// Configuración explícita de las opciones de la cookie de autenticación de Identity
// Esto es lo que faltaba para SameSite=None y Secure
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.None; // Permite que la cookie se envíe en solicitudes cross-site
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // ¡Obligatorio con SameSite=None! Solo HTTPS.
    options.Cookie.IsEssential = true; // Marca la cookie como esencial
    options.Cookie.HttpOnly = true;
    // Opcional: puedes ajustar el dominio si es necesario para subdominios
    // options.Cookie.Domain = ".tudominio.com";
});

//Configuración de CORS
var OrigenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(",");
builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(politica =>
    {
        politica.WithOrigins(OrigenesPermitidos).AllowCredentials().AllowAnyHeader().AllowAnyMethod();
    });
}
);

builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();
builder.Services.AddScoped<ICategoriaProductoInicioRepositorio, CategoriaProductoInicioRepositorio >();
builder.Services.AddScoped<ICategoriaProductoInicioServicio, CategoriaProductoInicioServicio>();

var app = builder.Build();
app.MapIdentityApi<IdentityUser>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication(); //Permite obtener la data del usuario autenticado
app.UseAuthorization();
app.MapControllers();
app.Run();
