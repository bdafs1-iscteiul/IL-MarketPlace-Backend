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

builder.Services.AddCors(options =>
{   
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();//Deviamos mudor os Any para apenas os necessarios
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseCors();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
