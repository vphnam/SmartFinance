using Serilog;
using SmartFinance.API.Configurations;
using SmartFinance.API.Middlewares;
using SmartFinance.Application;
using SmartFinance.Infrastructure;
using System;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});
builder.Services.AddAuthenticationConfiguration(builder.Configuration);
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
app.UseCors("AllowFrontend");
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ExceptionErrorHandlingMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
