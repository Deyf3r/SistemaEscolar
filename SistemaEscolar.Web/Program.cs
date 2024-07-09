using Microsoft.EntityFrameworkCore;
using Sistema_Escolar.Data.Context;
using Sistema_Escolar.Data.Interfaces;
using SistemaEscolar.Data.Repositories.Mocks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SistemaEscolarContext>(options => options.UseInMemoryDatabase("DBEscolar"));

builder.Services.AddScoped<ICursoRepository, MockCursoRepository>();

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
