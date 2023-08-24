using Core.Interfaces;

using Database;
using Database.Services;

using Hostel;

using Microsoft.EntityFrameworkCore;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddServerComponents();

builder.Services.AddDbContext<Context>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");

    options.UseSqlServer(connectionString, options =>
    {
        options.EnableRetryOnFailure()
            .MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
    });

    if (builder.Environment.IsDevelopment())
    {
        options.EnableDetailedErrors()
            .EnableSensitiveDataLogging();
    }
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapRazorComponents<App>();

app.Run();
