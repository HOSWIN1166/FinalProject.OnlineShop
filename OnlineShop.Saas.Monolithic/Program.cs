using Microsoft.EntityFrameworkCore;
using OnlineShop.Saas.Monolithic.Models;
using OnlineShop.Saas.Monolithic.Models.Services.Contracts;
using OnlineShop.Saas.Monolithic.Models.Services.Repositories;
using OnlineShop.Saas.Monolithic.Models.Services.Statuses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<OnlineShopDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default")
        ));


builder.Services.AddScoped<IProductRepository<Guid?, bool, RepositoryStatus>, ProductRepository>();
builder.Services.AddScoped<IPersonRepository<Guid?, bool, RepositoryStatus>, PersonRepository>();



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
