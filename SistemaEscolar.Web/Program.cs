using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Data.Context;
using SistemaEscolar.Data.Repositories.Db;
using SistemaEscolar.Data.Repositories.Mocks;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<UsuariosContext>(options => options.UseInMemoryDatabase("EscuelaDB"));

builder.Services.AddScoped<IUsuarioRepository, MockUsuarioRepository>();

// Add services to the container.
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
