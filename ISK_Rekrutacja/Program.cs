using ISK_Rekrutacja;
using ISK_Rekrutacja.DAL;
using ISK_Rekrutacja.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

builder.Services.AddTransient<Seeder>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(Configuration.GetConnectionString("conString"));
});
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IExportService, ExportService>();

var app = builder.Build();

SeedData();

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

void SeedData()
{
    using (var scope = app.Services.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seeder>();
        service.SeedData();
    }
}
