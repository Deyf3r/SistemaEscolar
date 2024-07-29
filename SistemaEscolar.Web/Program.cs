using Microsoft.EntityFrameworkCore;

using Sistema_Escolar.Data.Context;
using Sistema_Escolar.Data.Interfaces;
using Sistema_Escolar.Data.Repositories.Mocks;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<AgregarEstudiantesContext>(options => options.UseInMemoryDatabase("SistemaEscolar"));

builder.Services.AddScoped<IAgregarEstudiantesRepository, MockAgregarEstudiantesRepository>();

builder.Services.AddDbContext<AgregarMateriasContext>(options => options.UseInMemoryDatabase("SistemaEscolar"));

builder.Services.AddScoped<IMateriasRepository, MockMateriaRepository>();

builder.Services.AddDbContext<ProfesoresContext>(options => options.UseInMemoryDatabase("SistemaEscolar"));

builder.Services.AddScoped<IProfesoresRepository, MockProfesoresRepository>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
