// app/Program.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80); // để chạy được trong container
});

builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles(); // cho phép serve file index.html từ wwwroot
app.MapGet("/", () => "Hello from ASP.NET + SignalR + Docker!");
app.MapHub<ChatHub>("/chatHub");

app.Run();
