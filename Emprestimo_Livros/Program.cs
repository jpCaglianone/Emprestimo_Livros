using Emprestimo_Livros.Data;
using Emprestimo_Livros.Repository;
using Emprestimo_Livros.Service;
using Emprestimo_Livros.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Repositories
builder.Services.AddScoped<EmprestimoRepository>();
builder.Services.AddScoped<UsuarioRepository>();    

// Sercices
builder.Services.AddScoped<EmprestimoService>();
builder.Services.AddScoped<ExportarCSVService>();
builder.Services.AddScoped<IUsuarioRegistroService, UsuarioRegistroService>();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.Run();
