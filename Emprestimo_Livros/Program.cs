using Emprestimo_Livros.Data;
using Emprestimo_Livros.Repository;
using Emprestimo_Livros.Service;
using Emprestimo_Livros.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(session =>
{
    session.Cookie.HttpOnly = true;
    session.Cookie.IsEssential = true;
});

// Repositories
builder.Services.AddScoped<EmprestimoRepository>();
builder.Services.AddScoped<UsuarioRepository>();


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Sercices
builder.Services.AddScoped<EmprestimoService>();
builder.Services.AddScoped<ExportarCSVService>();
builder.Services.AddScoped<IUsuarioRegistroService, UsuarioRegistroService>();
builder.Services.AddScoped<ISenhaService, SenhaService>();
builder.Services.AddScoped<ISessaoInterface, SessaoService>();


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

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
