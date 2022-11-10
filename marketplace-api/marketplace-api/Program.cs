using marketplace_api.Data;
using marketplace_api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var conncetionString = builder.Configuration.GetConnectionString("Sql_Connection");

//-------------Add Entity Services------------------
builder.Services.AddScoped<UserService, UserService>();
// -------------------------------------------------

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>( options =>
{
    options.UseMySql(conncetionString, ServerVersion.AutoDetect(conncetionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAuthorization();

app.MapRazorPages();

app.Run();
