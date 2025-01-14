using CadasreoIEL.UseCases;
using CadastroIEL.Infrastructure.Interfaces;
using CadastroIEL.Infrastructure.Models;
using CadastroIEL.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));

builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<ICreateUseCase, CreateUseCase>();
builder.Services.AddScoped<IDeleteUseCase, DeleteUseCase>();
builder.Services.AddScoped<IFindUseCase, FindUseCase>();
builder.Services.AddScoped<IGetUseCase, GetUseCase>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
