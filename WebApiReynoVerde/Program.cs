
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApiReynoVerde;
using WebApiReynoVerde.Repositorios;
using WebApiReynoVerde.Servicios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
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
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.None; 
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; 
    options.Cookie.IsEssential = true; 
    options.Cookie.HttpOnly = true;
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

  if (app.Environment.IsDevelopment())
   {
        app.MapOpenApi();
   }

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
