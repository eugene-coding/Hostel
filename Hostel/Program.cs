using Core.Interfaces;

using Database;
using Database.Services;

using Hostel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddServerComponents();

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
