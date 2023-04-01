using JRS.Repository.MSSQL;
using JRS.Repository;
using JRS.Data;
using Microsoft.EntityFrameworkCore;
using JewelryRentalSystem.Repository.MsSQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<JRSDBContext>();
builder.Services.AddTransient<JRSDBContext>();
builder.Services.AddScoped<JRSDBContext, JRSDBContext>();
builder.Services.AddScoped<IRoleDBRepository, RoleDBRepository>();
builder.Services.AddScoped<IProductDBRepository, ProductDBRepository>();
builder.Services.AddScoped<IUserDBRepository, UserDBRepository>();

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
    pattern: "{controller=Product}/{action=GetAllProducts}/{id?}");

app.Run();
