using Serilog;
using SmartFinance.API.Middlewares;
using SmartFinance.Application;
using SmartFinance.Infrastructure;
using System;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("---- CONFIG DUMP ----");
foreach (var kv in builder.Configuration.AsEnumerable())
{
    if (kv.Key.Contains("Jwt", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine($"{kv.Key} = {kv.Value}");
    }
}
Console.WriteLine("---------------------");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom service
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationCoreService();


Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/requests.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();
app.UseDeveloperExceptionPage();
Console.WriteLine($"ENV = {builder.Environment.EnvironmentName}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ExceptionErrorHandlingMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
