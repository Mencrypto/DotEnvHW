using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 10 * 1024 * 1024;
    options.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(30);
    options.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(30);
    options.Limits.MaxConcurrentConnections = 100;

    options.Listen(IPAddress.Loopback, 8008); // solo localhost
});

var app = builder.Build();

app.MapGet("/", () => "¡Hola Mundo!");

app.Run();

