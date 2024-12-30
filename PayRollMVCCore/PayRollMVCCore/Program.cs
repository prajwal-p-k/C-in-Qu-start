using Microsoft.EntityFrameworkCore;
using PayRollMVCCore.Data;
using PayRollMVCCore.Services;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Qustartpayroll")));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Authentication>();
builder.Services.AddRouting();
builder.Services.AddSession(options=>options.IdleTimeout = TimeSpan.FromSeconds(60));


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
app.UseSession();
app.UseRouting();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Login}/{id?}");

app.Run();
