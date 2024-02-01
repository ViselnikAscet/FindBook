using System.Configuration;
using FindBook.Infrastructure.EF.MySql.Data;
using FindBook.Infrastructure.EF.MySql.Data.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
var serverVersion = new MySqlServerVersion(new Version(8, 0, 28)); // MySQL sürümünü uygun bir şekilde değiştirin


#region Db Config
try
{
builder.Services.AddDbContext<FindBookContext>(options =>
    options.UseMySql("Server=192.168.10.17;Port=3306;Database=Findbook;User Id=root;Password=FindBook2024!;Convert Zero Datetime=True;", new MySqlServerVersion(new Version(8, 0, 28))));
}
catch (Exception ex)
{
    Console.WriteLine($"Hata: {ex.Message}");
    
    
}

#endregion

#region Dependency Injection
// builder.Services.RegisterEfMysqlRepository(builder.Configuration);
// builder.Services.AddSession();
#endregion


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
