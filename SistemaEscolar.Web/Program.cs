using Microsoft.EntityFrameworkCore;
using Sistema_Escolar.Data.Context;
using Sistema_Escolar.Data.Interfaces;
using Sistema_Escolar.Data.Repositories.Mocks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AgregarEstudiantesContext>(options => options.UseInMemoryDatabase("Estudiantes"));

builder.Services.AddScoped<IAgregarEstudiantesRepository, MockAgregarEstudiantes >(); 

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
