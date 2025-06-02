using SF.Infrastructure;
using SF.Application;
var builder = WebApplication.CreateBuilder(args);

SF.Infrastructure.DependencyInjection.AddInfrastructure(builder.Services, builder.Configuration);
SF.Application.DependencyInjections.AddApplicationServices(builder.Services);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();